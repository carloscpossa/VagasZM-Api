using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.Enumeracoes;
using VagasZM.Dominio.ObjetosDeValor;


namespace VagasZM.Dominio.Testes.ObjetosDeValorTestes
{
    [TestClass]
    public class EnderecoTestes
    {        

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmLogradouroNuloOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco(null, "94", "", "Centro", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmLogradouroVazioOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("", "94", "", "Centro", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmLogradouroApenasComEspacosOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("      ", "94", "", "Centro", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmLogradouroComMenosDeDoisCaracteresOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("R", "94", "", "Centro", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmLogradouroComMaisDeSessentaCaracteresOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("ENDERECO DA RUA PRINCIAPAL D COM MAIS DE SESSENTA CARACTERES 1234", "94", "", "Centro", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmNumeroDoEnderecoNuloOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", null, "", "Centro", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmNumeroDoEnderecoVazioOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "", "", "Centro", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmNumeroDoEnderecoApenasComEspacosOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "      ", "", "Centro", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmNumeroDoEnderecoMaiorQueSessentaCaracteresOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "NUMERO ENDERECO DA RUA PRINCIAPAL D COM MAIS DE SESSENTA CARACTERES", "", "Centro", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmBairroNuloOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "94", "", null, "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmBairroVazioOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "94", "", "", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }
        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmBairroApenasComEspacosConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "94", "", "        ", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmBairroComMenosDeDoisCaracteresOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "94", "", "B", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadoUmBairroComMaisDeSessentaCaracteresOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "94", "", "Centro Centro Centro Centro Centro Centro Centro Centro Centro", "Ressaquinha", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadaUmaCidadeNulaOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "94", "", "Centro", null, Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadaUmaCidadeVaziaOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "94", "", "Centro", "", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadaUmaCidadeApenasComEspacosOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "94", "", "Centro", "      ", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadaUmaCidadeComMenosDeDoisCaracteresOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "94", "", "Centro", "C", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void DadaUmaCidadeComMaisDeSessentaCaracteresOConstrutorDeveCriarUmEnderecoInvalido()
        {
            Endereco endereco = new Endereco("Rua Principal", "94", "", "Centro", "Cidade Cidade Cidade Cidade Cidade Cidade Cidade Cidade Cidade", Estados.MG);
            Assert.IsFalse(endereco.IsValid());
        }

        [TestMethod]
        [TestCategory("Endereco - Novo Endereco")]
        public void SeTodosOsDadosDoEnderecoEstiveremCorretosOConstrutorDeveCriarUmEnderecoValidoEInicializadoCorretamente()
        {
            Endereco endereco = new Endereco("Estrada de Pitinga", "100", "Praia do Parracho", "Arraial Dajuda", "Porto Seguro", Estados.BA);
            Assert.IsTrue(endereco.IsValid());

            Assert.AreEqual("Estrada de Pitinga", endereco.Logradouro);
            Assert.AreEqual("100", endereco.Numero);
            Assert.AreEqual("Praia do Parracho", endereco.Complemento);
            Assert.AreEqual("Arraial Dajuda", endereco.Bairro);
            Assert.AreEqual("Porto Seguro", endereco.Cidade);
            Assert.AreEqual(Estados.BA, endereco.Uf);
        }
    }
}
