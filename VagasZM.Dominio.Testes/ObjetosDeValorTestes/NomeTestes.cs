using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.ObjetosDeValorTestes
{
    [TestClass]
    public class NomeTestes
    {
        [TestMethod]
        [TestCategory("Nome - Novo Nome")]
        public void DadoUmNomeVazioConstrutorDeveRetornarUmObjetoInvalido()
        {
            Nome nome = new Nome("");
            Assert.IsFalse(nome.IsValid());
        }

        [TestMethod]
        [TestCategory("Nome - Novo Nome")]
        public void DadoUmNomeMenorQueDoisCaracteresConstrutorDeveRetornarUmObjetoInvalido()
        {
            Nome nome = new Nome("C");
            Assert.IsFalse(nome.IsValid());
        }

        [TestMethod]
        [TestCategory("Nome - Novo Nome")]
        public void DadoUmNomeMaiorQueSessentaCaracteresConstrutorDeveRetornarUmObjetoInvalido()
        {
            Nome nome = new Nome("TESTE DE CRIACAO DE NOMES COM MAIS DE SESSENTA CARACTERES DEVE RETORNAR NOTIFICACAO");
            Assert.IsFalse(nome.IsValid());
        }

        [TestMethod]
        [TestCategory("Nome - Novo Nome")]
        public void DadoUmNomeValidoMaiorQueDoisEMenorQueSessentaCaracteresOConstrutorDeveRetornarUmNomeValido()
        {
            Nome nome = new Nome("JOÃO DAS COUVES DE SOUZA SILVA");
            Assert.IsTrue(nome.IsValid());
            Assert.AreEqual("JOÃO DAS COUVES DE SOUZA SILVA", nome.nome);
        }
    }
}
