using Dapper;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using VagasZM.Compartilhado;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Saidas;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.Repositorios;
using VagasZM.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Data;

namespace VagasZM.Infra.Dados.Repositorios
{
    public class VagaEmpregoRepositorio : IVagaEmpregoRepositorio
    {
        private readonly VagasZMDataContext _contexto;
        public VagaEmpregoRepositorio(VagasZMDataContext contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(VagaEmprego vaga)
        {
            _contexto.VagaEmprego.Add(vaga);
            _contexto.Entry(vaga.AreaProfissional).State = EntityState.Unchanged;
            _contexto.Entry(vaga.TipoContratacao).State = EntityState.Unchanged;
            _contexto.Entry(vaga.Empresa).State = EntityState.Unchanged;
        }

        public NumeroVagasAbertasResultadoComando RetornaQuantidadeVagasAbertas()
        {
            var sql = "select count(v.Id) as  QuantidadeVagasAbertas        " +
                      " from VagaEmprego v                                  " +
                      " where v.Status = 1 and v.DataExpiracao >= GETDATE() ";
                       
            using (var conexaoBd = new SqlConnection(Runtime.StringDeConexao))
            {
                conexaoBd.Open();
                return conexaoBd.Query<NumeroVagasAbertasResultadoComando>(sql).FirstOrDefault();
            }
        }

        public IEnumerable<UltimasVagasEmpregoAbertasResultadoComando> RetornaUltimasVagasAbertas()
        {
            var sql = "select top 5                                                  " +
                      "         v.Cargo,                                             " +
                      "         e.Nome as NomeEmpresa,                               " +
                      "         v.Descricao,                                         " +
                      "         v.Beneficios,                                        " +
                      "         v.HorarioTrabalho,                                   " +
                      "         convert(char(10), v.DataCriacao, 103) DataCriacao,   " +
                      "         case                                                 " +
                      "              when v.SalarioAcombinar = 1 then 'A COMBINAR'   " +
                      "         else                                                 " +
                      "              convert(varchar(20), v.Salario)                 " +
                      "                                                              " +
                      "         end as Salario,                                      " +
                      "         e.Cidade                                             " +
                      "  from VagaEmprego v                                          " +
                      "                                                              " +
                      "       inner                                                  " +
                      "  join Empresa e on (v.Empresa_Id = e.Id)                     " +
                      "  where v.Status = 1 and v.DataExpiracao > GETDATE()          " +
                      "  order by v.DataCriacao desc                                 ";

            using (var conexaoBd = new SqlConnection(Runtime.StringDeConexao))
            {
                conexaoBd.Open();
                return conexaoBd.Query<UltimasVagasEmpregoAbertasResultadoComando>(sql);
            }
        }
        
        public IEnumerable<VagaEmpregoEmpresaResultadoComando> RetornaVagasEmpresa(Guid empresaId, string cargo, string descricao, int? status, double? salarioInicial, double? salarioFinal, Guid? areaProfissionalId, Guid? tipoContratacaoId)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@empresaId", empresaId, DbType.Guid, ParameterDirection.Input);

            var sql = "select v.Id as vagaEmpregoId,                                                    " +
                      "           v.Cargo,                                                              " +
                      "           v.Descricao,                                                          " +
                      "           v.Beneficios,                                                         " +
                      "           v.HorarioTrabalho,                                                    " +
                      "           v.DataCriacao,                                                        " +
                      "           v.DataExpiracao,                                                      " +
                      "           v.SalarioAcombinar,                                                   " +
                      "           v.Salario,                                                            " +                      
                      "           case                                                                  " +
                      "               when v.Status = 1 and v.DataExpiracao > GETDATE() then 'Aberta'   " +
                      "           else                                                                  " +
                      "              'Encerrada'                                                        " +
                      "                                                                                 " +
                      "           end as DescricaoStatus,                                               " +
                      "                                                                                 " +
                      "           v.AreaProfissional_Id,                                                " +
                      "           v.TipoContratacao_Id,                                                 " +
                      "                                                                                 " +
                      "           a.Nome as AreaProfissional,                                           " +
                      "           t.Nome as TipoContratacao                                             " +
                      "                                                                                 " +
                      "    from VagaEmprego v                                                           " +
                      "                                                                                 " +
                      "         inner                                                                   " +
                      "    join AreaProfissional a on (v.AreaProfissional_Id = a.Id)                    " +
                      "                                                                                 " +
                      "  inner                                                                          " +
                      "    join TipoContratacao t on (v.TipoContratacao_Id = t.Id)                      " +
                      "    where v.Empresa_Id = @empresaId                                              ";

            if (!string.IsNullOrEmpty(cargo) && !string.IsNullOrWhiteSpace(cargo))
            {
                sql += " and v.Cargo=@cargo";
                parametros.Add("@cargo", cargo, DbType.String, ParameterDirection.Input);
            }

            if (!string.IsNullOrEmpty(descricao) && !string.IsNullOrWhiteSpace(descricao))
            {
                sql += " and v.Descricao like @descricao";
                parametros.Add("@descricao", "%" + descricao + "%", DbType.String, ParameterDirection.Input);
            }

            if (status == 1)
            {
                sql += " and v.Status=1 and v.DataExpiracao > GETDATE()";
            }

            if (status == 2)
            {
                sql += " and (v.Status=2 or v.DataExpiracao <= GETDATE() )";
            }


            if (salarioInicial!=null && salarioFinal != null)
            {
                sql += " and v.Salario between @salarioInicial and @salarioFinal";
                parametros.Add("@salarioInicial", salarioInicial, DbType.Double, ParameterDirection.Input);
                parametros.Add("@salarioFinal", salarioFinal, DbType.Double, ParameterDirection.Input);
            }

            if (areaProfissionalId != null)
            {
                sql += " and v.AreaProfissional_Id=@areaProfissionalId";
                parametros.Add("@areaProfissionalId", areaProfissionalId, DbType.Guid, ParameterDirection.Input);
            }

            if (tipoContratacaoId != null)
            {
                sql += " and v.TipoContratacao_Id=@tipoContratacaoId";
                parametros.Add("@tipoContratacaoId", tipoContratacaoId, DbType.Guid, ParameterDirection.Input);
            }
                                 
            using (var conexaoBd = new SqlConnection(Runtime.StringDeConexao))
            {
                conexaoBd.Open();

                return conexaoBd.Query<VagaEmpregoEmpresaResultadoComando>(sql, parametros);
            }

        }
    }
}
