using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.ObjetosDeValorTestes
{
    [TestClass]
    public class CPFTestes
    {
        [TestCategory("CPF - Novo CPF")]
        [TestMethod]
        public void DadoUmCPFComOnzeZerosOConstrutorDeveRetornarUmCPFInvalido()
        {
            CPF cpf = new CPF("00000000000");
            Assert.IsFalse(cpf.IsValid());
        }

        [TestCategory("CPF - Novo CPF")]
        [TestMethod]
        public void DadoUmCPFComMenosDeOnzeDigitosOConstrutorDeveRetornarUmCPFInvalido()
        {
            CPF cpf = new CPF("0575231980");
            Assert.IsFalse(cpf.IsValid());
        }

        [TestCategory("CPF - Novo CPF")]
        [TestMethod]
        public void DadoUmCPFComMaisDeOnzeDigitosOConstrutorDeveRetornarUmCPFInvalido()
        {
            CPF cpf = new CPF("996564321000");
            Assert.IsFalse(cpf.IsValid());
        }

        [TestCategory("CPF - Novo CPF")]
        [TestMethod]
        public void DadoUmCPFInvalidoOConstrutorDeveRetornarUmCPFInvalido()
        {
            CPF cpf = new CPF("01234567891");
            Assert.IsFalse(cpf.IsValid());
        }

        [TestCategory("CPF - Novo CPF")]
        [TestMethod]
        public void DadoUmCPFVerdadeiroOConstrutorDeveRetornarUmCPFInvalido()
        {
            CPF cpf = new CPF("54489058462");
            Assert.IsTrue(cpf.IsValid());
            Assert.AreEqual("54489058462", cpf.Numero);
        }

    }
}
