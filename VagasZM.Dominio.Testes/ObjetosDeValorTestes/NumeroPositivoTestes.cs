using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.ObjetosDeValorTestes
{
    [TestClass]
    public class NumeroPositivoTestes
    {
        [TestMethod]
        [TestCategory("NumeroPositivo - Novo NumeroPositivo")]
        public void DadoUmNumeroNegativoOConstrutorDeveRetornarObjetoInvalido()
        {
            NumeroPositivo numeroPositivo = new NumeroPositivo(-0.534);
            Assert.IsFalse(numeroPositivo.IsValid());
        }

        [TestMethod]
        [TestCategory("NumeroPositivo - Novo NumeroPositivo")]
        public void DadoONumeroZeroOConstrutorDeveRetornarObjetoInvalido()
        {
            NumeroPositivo numeroPositivo = new NumeroPositivo(0);
            Assert.IsFalse(numeroPositivo.IsValid());
        }

        [TestMethod]
        [TestCategory("NumeroPositivo - Novo NumeroPositivo")]
        public void DadoUmNumeroPositivoOConstrutorDevRetornarObjetoValido()
        {
            NumeroPositivo numeroPositivo = new NumeroPositivo(0.6854);
            Assert.IsTrue(numeroPositivo.IsValid());
        }
    }
}
