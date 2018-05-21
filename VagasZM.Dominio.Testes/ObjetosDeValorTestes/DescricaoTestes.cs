using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.ObjetosDeValorTestes
{
    [TestClass]
    public class DescricaoTestes
    {
        [TestMethod]
        [TestCategory("Descricao - Nova Descricao")]
        public void DadaUmaDescricaoVazioConstrutorDeveRetornarUmObjetoInvalido()
        {
            Descricao descricao = new Descricao("");
            Assert.IsFalse(descricao.IsValid());
        }

        [TestMethod]
        [TestCategory("Descricao - Nova Descricao")]
        public void DadoUmaDescricaoMenorQueDoisCaracteresConstrutorDeveRetornarUmObjetoInvalido()
        {
            Descricao descricao = new Descricao("W");
            Assert.IsFalse(descricao.IsValid());
        }

        [TestMethod]
        [TestCategory("Descricao - Nova Descricao")]
        public void DadoUmaDescricaoMaiorQueCemCaracteresConstrutorDeveRetornarUmObjetoInvalido()
        {
            Descricao descricao = new Descricao("TESTE DE CRIACAO DE DESCRICAO COM MAIS DE CEM CARACTERES DEVE RETORNAR NOTIFICACAO TESTE DE MUITOS CARACTERES CEM CARACTERES");
            Assert.IsFalse(descricao.IsValid());
        }

        [TestMethod]
        [TestCategory("Descricao - Nova Descricao")]
        public void DadaUmaDescricaoValidaMaiorQueDoisEMenorQueCemCaracteresOConstrutorDeveRetornarUmaDescricaoValida()
        {
            Descricao descricao = new Descricao("PRODUTO FORD FOCUS");
            Assert.IsTrue(descricao.IsValid());
            Assert.AreEqual("PRODUTO FORD FOCUS", descricao.descricao);
        }
    }
}
