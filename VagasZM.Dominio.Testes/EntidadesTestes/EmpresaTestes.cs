using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.EntidadesTestes
{
    [TestClass]
    public class EmpresaTestes
    {
        private Nome nomeEmpresa;
        private Texto descricaoEmpresa;
        private Nome cidade;
        private Site site;        

        [TestInitialize]
        public void Inicializar()
        {
            nomeEmpresa = new Nome("VAGAS ZONA DA MATA LTDA");
            descricaoEmpresa = new Texto("Empresa de desenvolvimento de software.");
            cidade = new Nome("Belo Horizonte");
            site = new Site("www.vagaszonadamata.com.br");            
        }


        [TestCategory("Empresa - Nova empresa")]
        [TestMethod]
        public void DadoUmNomeNuloOConstrutorDeveRetornarUmaEmpresaInvalida()
        {
            Empresa empresa = new Empresa(null, descricaoEmpresa, cidade, null, site);
            Assert.IsFalse(empresa.IsValid());
        }

        [TestCategory("Empresa - Nova empresa")]
        [TestMethod]
        public void DadaUmaCidadeNulaOConstrutorDeveRetornarUmaEmpresaInvalida()
        {
            Empresa empresa = new Empresa(nomeEmpresa, descricaoEmpresa, null, null, site);
            Assert.IsFalse(empresa.IsValid());
        }
                

        [TestCategory("Empresa - Nova empresa")]
        [TestMethod]
        public void DadosTodosOsDadosValidosConstrutorDeveCriarEmpresaValida()
        {
            Empresa empresa = new Empresa(nomeEmpresa, descricaoEmpresa, cidade, null, site);
            Assert.IsTrue(empresa.IsValid());

            Assert.AreEqual(nomeEmpresa, empresa.NomeEmpresa);
            Assert.AreEqual(descricaoEmpresa, empresa.DescricaoEmpresa);
            Assert.AreEqual(cidade, empresa.Cidade);
            Assert.AreEqual(null, empresa.Logo);
            Assert.AreEqual(site, empresa.Site);            
        }
      
    }
}
