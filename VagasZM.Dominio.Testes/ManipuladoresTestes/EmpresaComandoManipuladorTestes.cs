using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VagasZM.Dominio.Comandos.EmpresaComandos;
using VagasZM.Dominio.Comandos.EmpresaComandos.Entradas;
using VagasZM.Dominio.Comandos.EmpresaComandos.Mapeamento;
using VagasZM.Dominio.Comandos.EmpresaComandos.Saidas;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;
using VagasZM.Dominio.Repositorios;
using VagasZM.Dominio.Servicos;
using VagasZM.Dominio.Recursos;

namespace VagasZM.Dominio.Testes.ManipuladoresTestes
{
    [TestClass]
    public class EmpresaComandoManipuladorTestes
    {
        private Mock<IEmpresaRepositorio> empresaRepositorio;        
        private Mock<IUsuarioEmpresaRepositorio> usuarioEmpresaRepositorio;
        private Mock<IEmpresaComandoMap> empresaComandoMap;
        private Mock<IEmailServico> emailService;

        private Empresa empresaValida;
        private UsuarioEmpresa usuarioValido;

        private InserirEmpresaComando inserirEmpresaComandoValido;
        private InserirEmpresaComando inserirComandoEmpresaInvalida;
        private InserirEmpresaComando inserirComandoUsuarioInvalido;
        
        [TestInitialize]
        public void Inicializa()
        {
            inserirEmpresaComandoValido = new InserirEmpresaComando
            {
                NomeEmpresa = "Empresa Teste LTDA",
                Descricao = "Empresa teste",
                Cidade = "Belo Horizonte",
                site = "www.empresateste.com.br",
                email = "zezinho_araujo@yahoo.com.br",
                nomeUsuario = "Zezinho Araujo",
                senha = "1234",
                confirmacaoSenha = "1234"
            };

            empresaValida = new Empresa(new Nome(inserirEmpresaComandoValido.NomeEmpresa), new Texto(inserirEmpresaComandoValido.Descricao), new Nome(inserirEmpresaComandoValido.Cidade), "", new Site(inserirEmpresaComandoValido.site));
            usuarioValido = new UsuarioEmpresa(empresaValida, new Nome(inserirEmpresaComandoValido.nomeUsuario), new Email(inserirEmpresaComandoValido.email), inserirEmpresaComandoValido.senha, inserirEmpresaComandoValido.confirmacaoSenha);

            empresaRepositorio = new Mock<IEmpresaRepositorio>();            
            usuarioEmpresaRepositorio = new Mock<IUsuarioEmpresaRepositorio>();
            empresaComandoMap = new Mock<IEmpresaComandoMap>();
            emailService = new Mock<IEmailServico>();
           
            inserirComandoEmpresaInvalida = new InserirEmpresaComando
            {
                NomeEmpresa = "",
                Descricao = "Empresa teste",
                Cidade = "Belo Horizonte",
                site = "www.empresateste.com.br",
                email = "zezinho_araujo@yahoo.com.br",
                nomeUsuario = "Zezinho Araujo",
                senha = "1234",
                confirmacaoSenha = "1234"
            };

            inserirComandoUsuarioInvalido = new InserirEmpresaComando
            {
                NomeEmpresa = "Empresa Teste LTDA",
                Descricao = "Empresa teste",
                Cidade = "Belo Horizonte",
                site = "www.empresateste.com.br",
                email = "",
                nomeUsuario = "Zezinho Araujo",
                senha = "1234",
                confirmacaoSenha = "1234"
            };            
        }

        [TestMethod]
        [TestCategory("EmpresaComandoManipuladorTestes - InserirEmpresaComando")]
        public void SeInserirEmpresaComandoForNuloManipularDeveAdicionarNotificacao()
        {
            EmpresaComandoManipulador manipulador = new EmpresaComandoManipulador(empresaRepositorio.Object, usuarioEmpresaRepositorio.Object, empresaComandoMap.Object, emailService.Object);

            Assert.IsNull(manipulador.Manipular(null as InserirEmpresaComando));            
            Assert.AreNotEqual(0, manipulador.Notifications.Count);

            empresaComandoMap.Verify(x => x.CriarEmpresa(null), Times.Never);
            empresaRepositorio.Verify(x => x.Adicionar(null), Times.Never);
            usuarioEmpresaRepositorio.Verify(x => x.Adicionar(null), Times.Never);            
        }

        [TestMethod]
        [TestCategory("EmpresaComandoManipuladorTestes - InserirEmpresaComando")]
        public void SeJaExistirUsuarioParaEmailInformadoNoInserirEmpresaComandoManipularDeveAdicionarNotificacao()
        {
            usuarioEmpresaRepositorio.Setup(u => u.VerificarSeUsuarioExistePorEmail(inserirEmpresaComandoValido.email)).Returns(true);
            empresaComandoMap.Setup(x => x.CriarEmpresa(inserirEmpresaComandoValido)).Returns(empresaValida);
            empresaComandoMap.Setup(x => x.CriarUsuario(inserirEmpresaComandoValido, empresaValida)).Returns(usuarioValido);

            EmpresaComandoManipulador manipulador = new EmpresaComandoManipulador(empresaRepositorio.Object, usuarioEmpresaRepositorio.Object, empresaComandoMap.Object, emailService.Object);


            Assert.IsNull(manipulador.Manipular(inserirEmpresaComandoValido));
            Assert.AreNotEqual(0, manipulador.Notifications.Count);
            
            usuarioEmpresaRepositorio.Verify(v => v.VerificarSeUsuarioExistePorEmail(inserirEmpresaComandoValido.email), Times.Once);
            empresaComandoMap.Verify(v => v.CriarEmpresa(inserirEmpresaComandoValido), Times.Never);
            empresaRepositorio.Verify(x => x.Adicionar(empresaValida), Times.Never);
            usuarioEmpresaRepositorio.Verify(x => x.Adicionar(usuarioValido), Times.Never);

            emailService.Verify(x => x.Enviar(usuarioValido.Nome.nome, 
                                              usuarioValido.Email.EnderecoEmail, 
                                              string.Format(EmailTemplates.NovoUsuarioEmpresaAssunto, usuarioValido.Nome.nome),
                                              string.Format(EmailTemplates.NovoUsuarioEmpresaCorpo, usuarioValido.Nome.nome, usuarioValido.Email.EnderecoEmail, empresaValida.NomeEmpresa.nome)), Times.Never);

        }

        [TestMethod]
        [TestCategory("EmpresaComandoManipuladorTestes - InserirEmpresaComando")]
        public void QuandoOsDadosDaEmpresaForemInvalidosNoInserirEmpresaComandoManipularDeveRetornarNotificacao()
        {
            var empresaInvalida = new Empresa(new Nome(inserirComandoEmpresaInvalida.NomeEmpresa), new Texto(inserirComandoEmpresaInvalida.Descricao), new Nome(inserirComandoEmpresaInvalida.Cidade), "", new Site(inserirComandoEmpresaInvalida.site));
            var usuario = new UsuarioEmpresa(empresaInvalida, new Nome(inserirEmpresaComandoValido.nomeUsuario), new Email(inserirEmpresaComandoValido.email), inserirEmpresaComandoValido.senha, inserirEmpresaComandoValido.confirmacaoSenha);

            empresaComandoMap.Setup(x => x.CriarEmpresa(inserirComandoEmpresaInvalida)).Returns(empresaInvalida);
            empresaComandoMap.Setup(x => x.CriarUsuario(inserirComandoEmpresaInvalida, empresaInvalida)).Returns(usuario);

            EmpresaComandoManipulador manipulador = new EmpresaComandoManipulador(empresaRepositorio.Object, usuarioEmpresaRepositorio.Object, empresaComandoMap.Object, emailService.Object);

            Assert.IsNull(manipulador.Manipular(inserirComandoEmpresaInvalida));
            Assert.AreNotEqual(0, manipulador.Notifications.Count);
            empresaComandoMap.Verify(x => x.CriarEmpresa(inserirComandoEmpresaInvalida), Times.Once);
            empresaComandoMap.Verify(x => x.CriarUsuario(inserirComandoEmpresaInvalida, empresaInvalida), Times.Once);
            empresaRepositorio.Verify(x => x.Adicionar(empresaInvalida), Times.Never);
            usuarioEmpresaRepositorio.Verify(x => x.Adicionar(usuario), Times.Never);

            emailService.Verify(x => x.Enviar(usuario.Nome.nome,
                                              usuario.Email.EnderecoEmail,
                                              string.Format(EmailTemplates.NovoUsuarioEmpresaAssunto, usuario.Nome.nome),
                                              string.Format(EmailTemplates.NovoUsuarioEmpresaCorpo, usuario.Nome.nome, usuario.Email.EnderecoEmail, empresaInvalida.NomeEmpresa.nome)), Times.Never);

        }

        [TestMethod]
        [TestCategory("EmpresaComandoManipuladorTestes - InserirEmpresaComando")]
        public void QuandoOsDadosDoUsuarioForemInvalidosNoInserirEmpresaComandoManipularDeveRetornarNotificacao()
        {

            var usuarioInvalido = new UsuarioEmpresa(empresaValida, new Nome(inserirComandoUsuarioInvalido.nomeUsuario), new Email(inserirComandoUsuarioInvalido.email), inserirComandoUsuarioInvalido.senha, inserirComandoUsuarioInvalido.confirmacaoSenha);
            empresaComandoMap.Setup(x => x.CriarEmpresa(inserirComandoUsuarioInvalido)).Returns(empresaValida);
            empresaComandoMap.Setup(x => x.CriarUsuario(inserirComandoUsuarioInvalido, empresaValida)).Returns(usuarioInvalido);

            EmpresaComandoManipulador manipulador = new EmpresaComandoManipulador(empresaRepositorio.Object, usuarioEmpresaRepositorio.Object, empresaComandoMap.Object, emailService.Object);

            Assert.IsNull(manipulador.Manipular(inserirComandoUsuarioInvalido));
            Assert.AreNotEqual(0, manipulador.Notifications.Count);

            empresaComandoMap.Verify(x => x.CriarEmpresa(inserirComandoUsuarioInvalido), Times.Once);
            empresaComandoMap.Verify(x => x.CriarUsuario(inserirComandoUsuarioInvalido, empresaValida), Times.Once);

            empresaRepositorio.Verify(v => v.Adicionar(empresaValida), Times.Never);
            usuarioEmpresaRepositorio.Verify(v => v.Adicionar(usuarioInvalido), Times.Never);

            emailService.Verify(x => x.Enviar(usuarioInvalido.Nome.nome,
                                              usuarioInvalido.Email.EnderecoEmail,
                                              string.Format(EmailTemplates.NovoUsuarioEmpresaAssunto, usuarioInvalido.Nome.nome),
                                              string.Format(EmailTemplates.NovoUsuarioEmpresaCorpo, usuarioInvalido.Nome.nome, usuarioInvalido.Email.EnderecoEmail, empresaValida.NomeEmpresa.nome)), Times.Never);
        }

        [TestMethod]
        [TestCategory("EmpresaComandoManipuladorTestes - InserirEmpresaComando")]
        public void QuandoTodosOsDadosDaEmpreaEDoUsuarioEstiveremCorretosNoInserirEmpresaComandoManipuladorDeveRetornarInserirEmpresaResultadoComando()
        {
            empresaComandoMap.Setup(x => x.CriarEmpresa(inserirEmpresaComandoValido)).Returns(empresaValida);
            empresaComandoMap.Setup(x => x.CriarUsuario(inserirEmpresaComandoValido, empresaValida)).Returns(usuarioValido);

            EmpresaComandoManipulador manipulador = new EmpresaComandoManipulador(empresaRepositorio.Object, usuarioEmpresaRepositorio.Object, empresaComandoMap.Object, emailService.Object);

            InserirEmpresaResultadoComando resultado = manipulador.Manipular(inserirEmpresaComandoValido) as InserirEmpresaResultadoComando;
            Assert.AreEqual(0, manipulador.Notifications.Count);
            Assert.AreEqual(empresaValida.Id, resultado.EmpresaId);

            empresaRepositorio.Verify(x => x.Adicionar(empresaValida), Times.Once);
            usuarioEmpresaRepositorio.Verify(x => x.Adicionar(usuarioValido), Times.Once);

            emailService.Verify(x => x.Enviar(usuarioValido.Nome.nome,
                                              usuarioValido.Email.EnderecoEmail,
                                              string.Format(EmailTemplates.NovoUsuarioEmpresaAssunto, usuarioValido.Nome.nome),
                                              string.Format(EmailTemplates.NovoUsuarioEmpresaCorpo, usuarioValido.Nome.nome, usuarioValido.Email.EnderecoEmail, empresaValida.NomeEmpresa.nome)), Times.Once);
        }

    }
}
