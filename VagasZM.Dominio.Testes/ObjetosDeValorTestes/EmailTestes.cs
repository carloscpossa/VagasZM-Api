using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.ObjetosDeValorTestes
{
    [TestClass]
    public class EmailTestes
    {
        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoUmEmailNuloConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email(null);
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoUmEmailVazioConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoUmEmailEmBrancoConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("     ");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoApenasUmaArrobaConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("@");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoMaisDeUmaArrobaConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("carlos@henrique@.com");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoUmEnderecoSemArrobaConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("carlos_cpossa.com.br");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoUmEnderecoQueComecaComArrobaConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("@gmail.com");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoUmEnderecoQueTerminaComArrobaConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("carlos@");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoUmEnderecoComPontoLogoAposArrobaConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("carlos@.gmail");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoUmEnderecoSemPontoAposODominioConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("carlos@gmail");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoEnderecosComCaracteresEspeciaisConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("carlos@gmail#*&.com");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoEnderecoComMaisDe50CaracteresConstrutorDeveRetornarUmObjetoInvalido()
        {
            Email email = new Email("carlos@gmailsldfjgkaldkjgalkglasdkjglakjdghlakdsfgsfglakdfgjlakdfg.com");
            Assert.IsFalse(email.IsValid());
        }

        [TestCategory("Email - Novo Email")]
        [TestMethod]
        public void DadoNomeArrobaDominioNaOrdemCorretaConstrutorDeveRetornarUmObjetoValido()
        {
            Email email1 = new Email("manuel@hotmail.com");
            Email email2 = new Email("manuel_silva@yahoo.com.br");
            Email email3 = new Email("adm.sede@empresaj3.com.br");
            
            Assert.IsTrue(email1.IsValid());
            Assert.IsTrue(email2.IsValid());
            Assert.IsTrue(email3.IsValid());
        }
    }
}
