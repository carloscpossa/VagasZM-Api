using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using VagasZM.Compartilhado;
using VagasZM.Dominio.Comandos.AreaProfissionalComandos.Saidas;
using VagasZM.Dominio.Repositorios;
using System;
using VagasZM.Dominio.Entidades;
using VagasZM.Infra.Dados.Contexto;
using System.Linq;

namespace VagasZM.Infra.Dados.Repositorios
{
    public class AreaProfissionalRepositorio : IAreaProfissionalRepositorio
    {
        private readonly VagasZMDataContext _contexto;
        public AreaProfissionalRepositorio(VagasZMDataContext contexto)
        {
            _contexto = contexto;
        }

        public AreaProfissional BuscaAreaProfissionalPorId(Guid Id)
        {
            return _contexto.AreaProfissional.AsNoTracking().FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<BuscaListaAreaProfisionalResultadoComando> PesquisaAreaProfissional()
        {
            var sql = "select Id, Nome from AreaProfissional order by Nome";
            using (var conexao = new SqlConnection(Runtime.StringDeConexao))
            {
                conexao.Open();
                return conexao.Query<BuscaListaAreaProfisionalResultadoComando>(sql);
            }
        }
    }
}
