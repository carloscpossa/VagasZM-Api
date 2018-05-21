using FluentValidator;
using VagasZM.Compartilhado.Comandos;
using VagasZM.Dominio.Comandos.EmpresaComandos.Entradas;
using VagasZM.Dominio.Comandos.EmpresaComandos.Mapeamento;
using VagasZM.Dominio.Comandos.EmpresaComandos.Saidas;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.Recursos;
using VagasZM.Dominio.Repositorios;
using VagasZM.Dominio.Servicos;

namespace VagasZM.Dominio.Comandos.EmpresaComandos
{
    public class EmpresaComandoManipulador : Notifiable,
        IManipuladorComando<InserirEmpresaComando>
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;        
        private readonly IUsuarioEmpresaRepositorio _usuarioEmpresaRepositorio;
        private readonly IEmpresaComandoMap _empresaComandoMap;
        private readonly IEmailServico _emailServico;

        public EmpresaComandoManipulador(IEmpresaRepositorio empresaRepositorio, IUsuarioEmpresaRepositorio usuarioEmpresaRepositorio, IEmpresaComandoMap empresaComandoMap, IEmailServico emailServico)
        {
            _empresaRepositorio = empresaRepositorio;            
            _usuarioEmpresaRepositorio = usuarioEmpresaRepositorio;
            _empresaComandoMap = empresaComandoMap;
            _emailServico = emailServico;
        }


        public IResultadoComando Manipular(InserirEmpresaComando comando)
        {
            if (comando == null)
            {
                AddNotification("Dados", "Os dados para inclusão da empresa não foram informados corretamente.");
                return null;
            }

            if (_usuarioEmpresaRepositorio.VerificarSeUsuarioExistePorEmail(comando.email))
            {
                AddNotification("Email", "Já existe empresa e usuário associados ao e-mail informado.");
                return null;
            }

            Empresa empresa = _empresaComandoMap.CriarEmpresa(comando);
            UsuarioEmpresa usuario = _empresaComandoMap.CriarUsuario(comando, empresa);

            AddNotifications(empresa.Notifications);
            AddNotifications(usuario.Notifications);

            if (!IsValid())
                return null;

            _empresaRepositorio.Adicionar(empresa);
            _usuarioEmpresaRepositorio.Adicionar(usuario);
            _emailServico.Enviar(usuario.Nome.nome, usuario.Email.EnderecoEmail,
                                 string.Format(EmailTemplates.NovoUsuarioEmpresaAssunto, usuario.Nome.nome),
                                 string.Format(EmailTemplates.NovoUsuarioEmpresaCorpo, usuario.Nome.nome, usuario.Email.EnderecoEmail, empresa.NomeEmpresa.nome));

            return new InserirEmpresaResultadoComando { EmpresaId = empresa.Id };
        }
    }
}
