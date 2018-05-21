using System;
using VagasZM.Dominio.Comandos.EmpresaComandos.Entradas;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Comandos.EmpresaComandos.Mapeamento
{
    public class EmpresaComandoMap : IEmpresaComandoMap
    {
        public Empresa CriarEmpresa(InserirEmpresaComando comando)
        {
            if (comando == null)
                return null;

            return new Empresa(new Nome(comando.NomeEmpresa), new Texto(comando.Descricao), new Nome(comando.Cidade), "", new Site(comando.site));
        }

        public UsuarioEmpresa CriarUsuario(InserirEmpresaComando comando, Empresa empresa)
        {
            if (comando == null)
                return null;

            return new UsuarioEmpresa(empresa, new Nome(comando.nomeUsuario), new Email(comando.email), comando.senha, comando.confirmacaoSenha);
        }
    }
}
