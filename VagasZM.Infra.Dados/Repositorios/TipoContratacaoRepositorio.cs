using System.Collections.Generic;
using System.Data.SqlClient;
using VagasZM.Compartilhado;
using VagasZM.Dominio.Comandos.TipoContratacaoComandos.Saidas;
using VagasZM.Dominio.Repositorios;
using Dapper;
using System;
using VagasZM.Dominio.Entidades;
using VagasZM.Infra.Dados.Contexto;
using System.Linq;

namespace VagasZM.Infra.Dados.Repositorios
{
    public class TipoContratacaoRepositorio : ITipoContratacaoRepositorio
    {
        private VagasZMDataContext _contexto;
        public TipoContratacaoRepositorio(VagasZMDataContext contexto)
        {
            _contexto = contexto;
        }

        public TipoContratacao BuscaTipoContratacaoPorId(Guid Id)
        {
            return _contexto.TipoContratacao.AsNoTracking().FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<BuscaListaTipoContratacaoResultadoComando> PesquisaTipoContratacao()
        {
            var sql = "select Id, Nome from TipoContratacao order by Nome";
            using (var conexao = new SqlConnection(Runtime.StringDeConexao))
            {
                conexao.Open();
                return conexao.Query<BuscaListaTipoContratacaoResultadoComando>(sql);
            }
        }
    }
}
