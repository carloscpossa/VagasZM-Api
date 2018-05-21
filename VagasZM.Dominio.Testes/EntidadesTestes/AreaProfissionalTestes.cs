using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.EntidadesTestes
{
    [TestClass]
    public class AreaProfissionalTestes
    {
        [TestMethod]
        [TestCategory("AreaProfissional - Nova Area Profissional")]
        public void DadoUmNomeNuloConstrutorDeveRetornarUmAreaProfissionalInvalida()
        {
            AreaProfissional area = new AreaProfissional(null);
            Assert.IsFalse(area.IsValid());
        }

        [TestMethod]
        [TestCategory("AreaProfissional - Nova Area Profissional")]
        public void DadoUmNomeValidoConstrutorDeveRetornarUmaAreaProfissionalValida()
        {
            Nome nome = new Nome("Comercial e Vendas");
            AreaProfissional area = new AreaProfissional(nome);
            Assert.IsTrue(area.IsValid());
            Assert.AreEqual(nome, area.Nome);
        }
    }
}
