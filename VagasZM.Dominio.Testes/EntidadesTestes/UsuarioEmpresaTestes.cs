using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.EntidadesTestes
{
    [TestClass]
    public class UsuarioEmpresaTestes
    {
        private Empresa empresa;
        private Nome nomeContato;
        private Email email;
        private string senha;

        [TestInitialize]
        public void Inicializar()
        {
            empresa = new Empresa(new Nome("VAGAS ZM LTDA"), new Texto("O maior portal de vagas"), new Nome("Belo Horizonte"), null, new Site("www.vagaszonadamata.com.br"));
            nomeContato = new Nome("Leonardo Possa");
            email = new Email("lacpossa@hotmail.com");
            senha = "!sdfljsdf1234";
        }

        [TestCategory("Usuario - Novo Usuario")]
        [TestMethod]
        public void DadaUmaEmpresaNulaOConstrutorDeveRetornarUmUsuarioInvalido()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(null, nomeContato, email, senha, senha);
            Assert.IsFalse(usuario.IsValid());
        }

        [TestCategory("Usuario - Novo Usuario")]
        [TestMethod]
        public void DadoUmEmailNuloOConstrutorDeveRetornarUmUsuarioInvalido()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(empresa, nomeContato, null, senha, senha);
            Assert.IsFalse(usuario.IsValid());
        }

        [TestCategory("Usuario - Novo Usuario")]
        [TestMethod]
        public void DadaUmaSenhaNulaOConstrutorDeveRetornarUmUsuarioInvalido()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(empresa, nomeContato, email, null, null);
            Assert.IsFalse(usuario.IsValid());
        }

        [TestCategory("Usuario - Novo Usuario")]
        [TestMethod]
        public void DadaUmaSenhaVaziaOConstrutorDeveRetornarUmUsuarioInvalido()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(empresa, nomeContato, email, "", "");
            Assert.IsFalse(usuario.IsValid());
        }

        [TestCategory("Usuario - Novo Usuario")]
        [TestMethod]
        public void DadaUmaSenhaComEspacosEmBrancoOConstrutorDeveRetornarUmUsuarioInvalido()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(empresa, nomeContato, email, "   ", "   ");
            Assert.IsFalse(usuario.IsValid());
        }

        [TestCategory("Usuario - Novo Usuario")]
        [TestMethod]
        public void DadaUmaSenhaDiferenteDaConfirmacaoDeSenhaOConstrutorDeveRetornarUmUsuarioInvalido()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(empresa, nomeContato, email, senha, "12345");
            Assert.IsFalse(usuario.IsValid());
        }

        [TestCategory("Usuario - Novo Usuario")]
        [TestMethod]
        public void QuandoTodosOsDadosDoUsuarioEstiveremCorretosOConstrutorDeveCriarUmUsuarioValido()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(empresa, nomeContato, email, senha, senha);
            Assert.IsTrue(usuario.IsValid());

            Assert.AreEqual(empresa, usuario.Empresa);
            Assert.AreEqual(nomeContato, usuario.Nome);
            Assert.AreEqual(email, usuario.Email);
        }

        [TestMethod]
        [TestCategory("Usuario - Autenticacao")]
        public void AutenticadoDeveRetornarFalsoSeASenhaForNula()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(empresa, nomeContato, email, senha, senha);
            Assert.IsFalse(usuario.Autenticado(null));
        }

        [TestMethod]
        [TestCategory("Usuario - Autenticacao")]
        public void AutenticadoDeveRetornarFalsoSeASenhaForEspacosEmBranco()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(empresa, nomeContato, email, senha, senha);
            Assert.IsFalse(usuario.Autenticado("    "));
        }

        [TestMethod]
        [TestCategory("Usuario - Autenticacao")]
        public void AutenticadoDeveRetornarFalsoSeASenhaForDiferenteDaSenhaDoUsuario()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(empresa, nomeContato, email, senha, senha);
            Assert.IsFalse(usuario.Autenticado("12345"));
        }

        [TestMethod]
        [TestCategory("Usuario - Autenticacao")]
        public void AutenticadoDeveRetornarVerdadeiroSeASenhaForIgualASenhaDoUsuario()
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa(empresa, nomeContato, email, "teste$1234*", "teste$1234*");
            Assert.IsTrue(usuario.Autenticado("teste$1234*"));
        }
    }
}
