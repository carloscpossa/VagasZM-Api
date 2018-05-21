using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.EntidadesTestes
{
    [TestClass]
    public class TipoContratacaoTestes
    {
        [TestMethod]
        [TestCategory("TipoContratacao = Novo Tipo de Contratacao")]
        public void DadoUmNomeDoTipoDeContratacaoNuloOConstrutorDeeveRetornarUmTipoDeContratacaoInvalido()
        {
            TipoContratacao tipo = new TipoContratacao(null);
            Assert.IsFalse(tipo.IsValid());
        }

        [TestMethod]
        [TestCategory("TipoContratacao = Novo Tipo de Contratacao")]
        public void DadoUmNomeDoTipoDeContratacaoValidoConstrutorDeveRetornarUmTipoDeContratacaoValido()
        {
            Nome nome = new Nome("CLT");
            TipoContratacao tipo = new TipoContratacao(nome);
            Assert.IsTrue(tipo.IsValid());
            Assert.AreEqual(nome, tipo.NomeTipoContratacao);
        }
    }
}
