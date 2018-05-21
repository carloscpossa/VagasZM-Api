using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Entradas;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Mapeamento;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Saidas;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;
using VagasZM.Dominio.Repositorios;

namespace VagasZM.Dominio.Testes.ManipuladoresTestes
{
    [TestClass]
    public class VagaEmpregoComandoManipuladorTestes
    {
        private Mock<IVagaEmpregoRepositorio> vagaEmpregoRepositorio;
        private Mock<IEmpresaRepositorio> empresaRepositorio;
        private Mock<IVagaEmpregoComandoMap> vagaEmpregoMap;
        private Mock<IAreaProfissionalRepositorio> areaProfissionalRepositorio;
        private Mock<ITipoContratacaoRepositorio> tipoContratacaoRepositorio;

        private InserirVagaEmpregoComando comandoValido;

        private VagaEmprego vagaEmpregoValida;
        private Empresa empresaValida;
        private AreaProfissional areaProfissionalValida;
        private TipoContratacao tipoContratacaoValida;

        public VagaEmpregoComandoManipuladorTestes()
        {
            vagaEmpregoRepositorio = new Mock<IVagaEmpregoRepositorio>();
            empresaRepositorio = new Mock<IEmpresaRepositorio>();
            vagaEmpregoMap = new Mock<IVagaEmpregoComandoMap>();
            areaProfissionalRepositorio = new Mock<IAreaProfissionalRepositorio>();
            tipoContratacaoRepositorio = new Mock<ITipoContratacaoRepositorio>();

            comandoValido = new InserirVagaEmpregoComando
            {
                AreaProfissionalId = Guid.Parse("6360523F-F3F8-4384-A51F-0280E98E9D08"),
                Cargo = "Analista de Sistemas",
                Beneficios = "Vale transporte, plano de saúde, vale refeição",
                Descricao = "Obrigatório conhecimento de Programação Orientada a Objetos, .NET Framework, .NET Core, EF, Dapper, SQL Server, NoSql (MongoDb ou RavenDb)",
                EmpresaId = Guid.Parse("640dbf6f-bfcb-4290-a059-c71152d479f3"),
                HorarioTrabalho = "Horário flexível",
                Salario = 6000,
                SalarioAcombinar = false,
                TipoContratacaoId = Guid.Parse("8D6B1678-5059-42EB-A8C5-F071E88A70C9")
            };

            empresaValida = new Empresa(new Nome("Empresa Teste LTDA"), new Texto("Empresa de teste"), new Nome("Ressaquinha"), "", new Site("www.empresateste.com.br"));
            areaProfissionalValida = new AreaProfissional(new Nome("Informática"));
            tipoContratacaoValida = new TipoContratacao(new Nome("CLT"));

            vagaEmpregoValida = new VagaEmprego(empresaValida,
                                              new Nome(comandoValido.Cargo),
                                              new Texto(comandoValido.Descricao),
                                              new Texto(comandoValido.Beneficios),
                                              areaProfissionalValida,
                                              new Descricao(comandoValido.HorarioTrabalho),
                                              new DateTime(2500, 12, 31),
                                              comandoValido.SalarioAcombinar,
                                              new NumeroPositivo(comandoValido.Salario),
                                              tipoContratacaoValida);
        }        


        [TestMethod]
        [TestCategory("VagaEmpregoComandoManipuladorTestes - InserirVagaEmpresaComando")]
        public void SeInserirVagaEmpregoComandoForNuloManipularDeveAdicionarNotificacao()
        {            
            var vagaEmpregoManipulador = new VagaEmpregoComandoManipulador(vagaEmpregoRepositorio.Object, 
                                                                           empresaRepositorio.Object, 
                                                                           vagaEmpregoMap.Object,
                                                                           areaProfissionalRepositorio.Object,
                                                                           tipoContratacaoRepositorio.Object);

            Assert.IsNull(vagaEmpregoManipulador.Manipular(null as InserirVagaEmpregoComando));
            Assert.AreNotEqual(0, vagaEmpregoManipulador.Notifications.Count); 
            
            vagaEmpregoRepositorio.Verify(v => v.Adicionar(null), Times.Never);            
            empresaRepositorio.Verify(v => v.BuscaEmpresaPorId(It.Is<Guid>(null)), Times.Never);            
        }

        [TestMethod]
        [TestCategory("VagaEmpregoComandoManipuladorTestes - InserirVagaEmpresaComando")]
        public void SeVagaEmpregoCriadaForInvalidaInserirVagaEmpresaComandoManipuladorDeveRetornarNotificacao()
        {
            var vagaEmpregoInvalida = new VagaEmprego(empresaValida,
                                              new Nome(""),
                                              new Texto(comandoValido.Descricao),
                                              new Texto(comandoValido.Beneficios),
                                              areaProfissionalValida,
                                              new Descricao(comandoValido.HorarioTrabalho),
                                              new DateTime(2500, 12, 31),
                                              comandoValido.SalarioAcombinar,
                                              new NumeroPositivo(comandoValido.Salario),
                                              tipoContratacaoValida);

            empresaRepositorio.Setup(x => x.BuscaEmpresaPorId(comandoValido.EmpresaId)).Returns(empresaValida);
            areaProfissionalRepositorio.Setup(x => x.BuscaAreaProfissionalPorId(comandoValido.AreaProfissionalId)).Returns(areaProfissionalValida);
            tipoContratacaoRepositorio.Setup(x => x.BuscaTipoContratacaoPorId(comandoValido.TipoContratacaoId)).Returns(tipoContratacaoValida);

            vagaEmpregoMap.Setup(x => x.CriarVagaEmprego(comandoValido, empresaValida, areaProfissionalValida, tipoContratacaoValida)).Returns(vagaEmpregoInvalida);

            var vagaEmpregoManipulador = new VagaEmpregoComandoManipulador(vagaEmpregoRepositorio.Object,
                                                                           empresaRepositorio.Object,
                                                                           vagaEmpregoMap.Object,
                                                                           areaProfissionalRepositorio.Object,
                                                                           tipoContratacaoRepositorio.Object);

            Assert.IsNull(vagaEmpregoManipulador.Manipular(comandoValido));
            Assert.AreNotEqual(0, vagaEmpregoManipulador.Notifications.Count);
           
            vagaEmpregoMap.Verify(x => x.CriarVagaEmprego(comandoValido, empresaValida, areaProfissionalValida, tipoContratacaoValida), Times.Once);
            vagaEmpregoRepositorio.Verify(x => x.Adicionar(vagaEmpregoInvalida), Times.Never);
        }

        [TestMethod]
        [TestCategory("VagaEmpregoComandoManipuladorTestes - InserirVagaEmpresaComando")]
        public void SeVagaEmpregoForValidaInserirVagaEmpresaComandoManipuladorDeveRetornarInserirVagaEmpregoResultadoComando()
        {
            empresaRepositorio.Setup(x => x.BuscaEmpresaPorId(comandoValido.EmpresaId)).Returns(empresaValida);
            areaProfissionalRepositorio.Setup(x => x.BuscaAreaProfissionalPorId(comandoValido.AreaProfissionalId)).Returns(areaProfissionalValida);
            tipoContratacaoRepositorio.Setup(x => x.BuscaTipoContratacaoPorId(comandoValido.TipoContratacaoId)).Returns(tipoContratacaoValida);

            vagaEmpregoMap.Setup(x => x.CriarVagaEmprego(comandoValido, empresaValida, areaProfissionalValida, tipoContratacaoValida)).Returns(vagaEmpregoValida);

            var vagaEmpregoManipulador = new VagaEmpregoComandoManipulador(vagaEmpregoRepositorio.Object,
                                                                           empresaRepositorio.Object,
                                                                           vagaEmpregoMap.Object,
                                                                           areaProfissionalRepositorio.Object,
                                                                           tipoContratacaoRepositorio.Object);

            InserirVagaEmpregoResultadoComando resultado = vagaEmpregoManipulador.Manipular(comandoValido) as InserirVagaEmpregoResultadoComando;

            Assert.AreEqual(vagaEmpregoValida.Id, resultado.VagaEmpregoId);
            Assert.AreEqual(0, vagaEmpregoManipulador.Notifications.Count);

            empresaRepositorio.Verify(x => x.BuscaEmpresaPorId(comandoValido.EmpresaId), Times.Once);
            areaProfissionalRepositorio.Verify(x => x.BuscaAreaProfissionalPorId(comandoValido.AreaProfissionalId), Times.Once);
            tipoContratacaoRepositorio.Verify(x => x.BuscaTipoContratacaoPorId(comandoValido.TipoContratacaoId), Times.Once);
            vagaEmpregoMap.Verify(x => x.CriarVagaEmprego(comandoValido, empresaValida, areaProfissionalValida, tipoContratacaoValida), Times.Once);
            vagaEmpregoRepositorio.Verify(x => x.Adicionar(vagaEmpregoValida), Times.Once);
        }

    }
}
