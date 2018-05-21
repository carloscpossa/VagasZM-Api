using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.ObjetosDeValorTestes
{
    [TestClass]
    public class SiteTestes
    {
        [TestCategory("Site - Novo Site")]
        [TestMethod]        
        public void DadaUmaURLNulaConstrutorDeveCriarObjetoInvalido()
        {
            Site site = new Site(null);
            Assert.IsFalse(site.IsValid());
        }

        [TestCategory("Site - Novo Site")]
        [TestMethod]
        public void DadaUmaURLVaziaConstrutorDeveCriarObjetoInvalido()
        {
            Site site = new Site("");
            Assert.IsFalse(site.IsValid());
        }

        [TestCategory("Site - Novo Site")]
        [TestMethod]
        public void DadaUmaURLComEspacosEmBrancoConstrutorDeveCriarObjetoInvalido()
        {
            Site site = new Site("      ");
            Assert.IsFalse(site.IsValid());
        }

        [TestCategory("Site - Novo Site")]
        [TestMethod]
        public void DadaUmaURLValidaConstrutorDeveCriarObjetoValido()
        {
            Site site = new Site("www.globo.com");
            Assert.IsTrue(site.IsValid());
        }
    }
}
