using System;
using System.Data.SqlClient;
using VagasZM.Compartilhado;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.Repositorios;
using VagasZM.Infra.Dados.Contexto;
using Dapper;
using System.Linq;

namespace VagasZM.Infra.Dados.Repositorios
{
    public class UsuarioEmpresaRepositorio : IUsuarioEmpresaRepositorio
    {
        private readonly VagasZMDataContext _contexto;
        public UsuarioEmpresaRepositorio(VagasZMDataContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(UsuarioEmpresa usuario)
        {
            _contexto.UsuarioEmpresa.Add(usuario);
        }

        public UsuarioEmpresa BuscarUsuarioPorEmail(string email)
        {
            return _contexto.UsuarioEmpresa
                        .Include("Empresa")
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Email.EnderecoEmail == email);
        }

        public bool VerificarSeUsuarioExistePorEmail(string email)
        {
            var sql = "select count(Id) from UsuarioEmpresa where Email =@email";

            using (var conexao = new SqlConnection(Runtime.StringDeConexao))
            {
                conexao.Open();
                return conexao
                            .ExecuteScalar<int>(sql, new { email = new DbString { Value = email } }) > 0;

            }
        }
    }
}
