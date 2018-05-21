using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.ObjetosDeValorTestes
{
    [TestClass]
    public class TelefoneTestes
    {
        [TestMethod]
        [TestCategory("Telefone - novo telefone")]
        public void DadoUmTelefoneVazioOConstrutorDeveRetornarUmObjetoInvalido()
        {
            Telefone telefone = new Telefone("");
            Assert.IsFalse(telefone.IsValid());
        }

        [TestMethod]
        [TestCategory("Telefone - novo telefone")]
        public void DadoUmTelefoneSemDDDOConstrutorDeveRetornarUmObjetoInvalido()
        {
            Telefone telefone = new Telefone("34231830");
            Assert.IsFalse(telefone.IsValid());
        }

        [TestMethod]
        [TestCategory("Telefone - novo telefone")]
        public void DadoUmTelefoneComTracoConstrutorDeveRetornarUmObjetoInvalido()
        {
            Telefone telefone = new Telefone("313423-1830");
            Assert.IsFalse(telefone.IsValid());
        }

        [TestMethod]
        [TestCategory("Telefone - novo telefone")]
        public void DadoUmTelefoneComParenteseConstrutorDeveRetornarUmObjetoInvalido()
        {
            Telefone telefone = new Telefone("(31)34231830");
            Assert.IsFalse(telefone.IsValid());
        }

        [TestMethod]
        [TestCategory("Telefone - novo telefone")]
        public void DadoUmTelefoneComEspacaoConstrutorDeveRetornarUmObjetoInvalido()
        {
            Telefone telefone = new Telefone("31 34231830");
            Assert.IsFalse(telefone.IsValid());
        }

        [TestMethod]
        [TestCategory("Telefone - novo telefone")]
        public void DadoUmTelefoneComMenosDeDezDigitosConstrutorDeveRetornarUmObjetoInvalido()
        {
            Telefone telefone = new Telefone("334231830");
            Assert.IsFalse(telefone.IsValid());
        }

        [TestMethod]
        [TestCategory("Telefone - novo telefone")]
        public void DadoUmTelefoneComMaisDeOnzeDigitosConstrutorDeveRetornarUmObjetoInvalido()
        {
            Telefone telefone = new Telefone("313422519197");
            Assert.IsFalse(telefone.IsValid());
        }

        [TestMethod]
        [TestCategory("Telefone - novo telefone")]
        public void DadoUmTelefoneFixoSemParenteseSemTracoSemEspacoConstrutorDeveRetornarUmObjetoValido()
        {
            Telefone telefone = new Telefone("3134231830");
            Assert.IsTrue(telefone.IsValid());
            Assert.AreEqual("3134231830", telefone.Numero);
        }

        [TestMethod]
        [TestCategory("Telefone - novo telefone")]
        public void DadoUmTelefoneCelularSemParenteseSemTracoSemEspacoConstrutorDeveRetornarUmObjetoValido()
        {
            Telefone telefone = new Telefone("31993344545");
            Assert.IsTrue(telefone.IsValid());
            Assert.AreEqual("31993344545", telefone.Numero);
        }
    }
}
