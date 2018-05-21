using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasZM.Dominio.Comandos.EmpresaComandos.Entradas;
using VagasZM.Dominio.Comandos.EmpresaComandos.Mapeamento;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Dominio.Testes.ComandoMapTestes
{
    [TestClass]
    public class EmpresaComandoMapTestes
    {
        private InserirEmpresaComando comando;
        public EmpresaComandoMapTestes()
        {
            comando = new InserirEmpresaComando
            {
                NomeEmpresa = "Empresa Teste LTDA",
                Descricao = "Empresa teste",
                Cidade = "Belo Horizonte",
                site = "www.empresateste.com.br",
                email = "zezinho_araujo@yahoo.com.br",
                nomeUsuario = "Zezinho Araujo",
                senha = "1234",
                confirmacaoSenha = "1234"
            };
        }

        [TestMethod]
        [TestCategory("EmpresaComandoMapTestes - CriarEmpresa")]
        public void DadoUmInserirEmpresaComandoNuloCriarEmpresaDeveRetornarNulo()
        {
            EmpresaComandoMap map = new EmpresaComandoMap();
            Assert.IsNull(map.CriarEmpresa(null));
        }

        [TestMethod]
        [TestCategory("EmpresaComandoMapTestes - CriarEmpresa")]
        public void DadoUmInserirEmpresaComandoCriarEmpresaDeveRetornarEmpresaComOsMesmosDadosDoComando()
        {            
            EmpresaComandoMap map = new EmpresaComandoMap();
            Empresa empresa = map.CriarEmpresa(comando);

            Assert.AreEqual(comando.NomeEmpresa, empresa.NomeEmpresa.nome);
            Assert.AreEqual(comando.Descricao, empresa.DescricaoEmpresa.Conteudo);
            Assert.AreEqual(comando.Cidade, empresa.Cidade.nome);
            Assert.AreEqual(comando.site, empresa.Site.URL);                                   
        }

        [TestMethod]
        [TestCategory("EmpresaComandoMapTestes - CriarUsuarioEmpresa")]
        public void DadoUmInserirEmpresaComandoNuloCriarUsuarioEmpresaDeveRetornarNulo()
        {
            EmpresaComandoMap map = new EmpresaComandoMap();
            Assert.IsNull(map.CriarUsuario(null, null));
        }

        [TestMethod]
        [TestCategory("EmpresaComandoMapTestes - CriarUsuarioEmpresa")]
        public void DadoUmInserirEmpresaComandoCriarEmpresaDeveRetornarUsuarioEmpresaComOsMesmosDadosDoComando()
        {
            EmpresaComandoMap map = new EmpresaComandoMap();
            var empresa = map.CriarEmpresa(comando);
            var usuario = map.CriarUsuario(comando, empresa);

            Assert.AreEqual(empresa, usuario.Empresa);
            Assert.AreEqual(comando.nomeUsuario, usuario.Nome.nome);
            Assert.AreEqual(comando.email, usuario.Email.EnderecoEmail);            
        }

    }
}
