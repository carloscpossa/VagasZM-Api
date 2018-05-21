using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using VagasZM.Compartilhado;
using VagasZM.Dominio.Comandos.CidadeComandos.Saidas;
using VagasZM.Dominio.Repositorios;

namespace VagasZM.Infra.Dados.Repositorios
{
    public class CidadeRepositorio : ICidadeRepositorio
    {
        public IEnumerable<CidadesPorEstadoResultadoComando> RetornaCidadePorEstado(string siglaUf)
        {
            var sql = "select c.nome as cidade                           " +
                      "  from Cidade c                                   " +                     
                      "  where c.uf =@uf                                 ";

            using (var conexaoBd = new SqlConnection(Runtime.StringDeConexao))
            {
                conexaoBd.Open();
                return conexaoBd.Query<CidadesPorEstadoResultadoComando>(sql, new { uf = siglaUf });
            }
        }
    }
}
