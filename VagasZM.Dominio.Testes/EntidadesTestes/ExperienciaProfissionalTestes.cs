using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.EntidadesTestes
{
    [TestClass]
    public class ExperienciaProfissionalTestes
    {
        [TestCategory("ExperienciaProfissional - Nova Experiência Profissional")]
        [TestMethod]
        public void DadoUmNomeDeEmpresaNuloOConstrutorDeveraCriarUmaExperienciaProfissionalInvalida()
        {
            AreaProfissional area = new AreaProfissional(new Nome("Indústria"));
            ExperienciaProfissional experiencia = new ExperienciaProfissional(new DateTime(2007, 10, 01), new DateTime(2013, 07, 31), null, new Nome("Gerente de Produção"), area, new Texto("Gerente"));
            Assert.IsFalse(experiencia.IsValid());
        }

        [TestCategory("ExperienciaProfissional - Nova Experiência Profissional")]
        [TestMethod]
        public void DadoUmNomeDeCargoNuloOConstrutorDeveraCriarUmaExperienciaProfissionalInvalida()
        {
            AreaProfissional area = new AreaProfissional(new Nome("Indústria"));
            ExperienciaProfissional experiencia = new ExperienciaProfissional(new DateTime(2007, 10, 01), new DateTime(2013, 07, 31), new Nome("Bar do João"), null, area, new Texto("Gerente"));
            Assert.IsFalse(experiencia.IsValid());
        }

        [TestCategory("ExperienciaProfissional - Nova Experiência Profissional")]
        [TestMethod]
        public void DadaUmaAreaProfissionalNulaOConstrutorDeveraCriarUmaExperienciaProfissionalInvalida()
        {
            ExperienciaProfissional experiencia = new ExperienciaProfissional(new DateTime(2007, 10, 01), new DateTime(2013, 07, 31), new Nome("Minha Indústria LTDA"), new Nome("Programador de PCP"), null, new Texto("Programador"));
            Assert.IsFalse(experiencia.IsValid());
        }

        [TestCategory("ExperienciaProfissional - Nova Experiência Profissional")]
        [TestMethod]
        public void DadaUmaDataDeTerminoMenorQueADataDeInicioDaExperienciaProfissionalOConstrutorDeveraCriarUmaExperienciaProfissionalInvalida()
        {
            AreaProfissional area = new AreaProfissional(new Nome("Indústria"));
            ExperienciaProfissional experiencia = new ExperienciaProfissional(new DateTime(2007, 10, 01), new DateTime(2006, 07, 31), new Nome("Minha Indústria LTDA"), new Nome("Programador de PCP"), area, new Texto("Programador"));
            Assert.IsFalse(experiencia.IsValid());
        }

        [TestCategory("ExperienciaProfissional - Nova Experiência Profissional")]
        [TestMethod]
        public void DadasTodasInformacoesValidasDaExperienciaOConstrutorDeveraCriarUmaExperienciaProfissionalValida()
        {
            DateTime dataInicio = new DateTime(2007, 10, 01);
            DateTime dataTermino = new DateTime(2009, 07, 31);
            Nome nomeEmpresa = new Nome("Minha Empresa LTDA");
            Nome nomeCargo = new Nome("Desenvolvedor Delphi");
            Texto atividadeExercida = new Texto("Programador");
            AreaProfissional area = new AreaProfissional(new Nome("Informática"));

            ExperienciaProfissional experiencia = new ExperienciaProfissional(dataInicio, dataTermino, nomeEmpresa, nomeCargo, area, atividadeExercida);
            Assert.IsTrue(experiencia.IsValid());

            Assert.AreEqual(dataInicio, experiencia.DataInicio);
            Assert.AreEqual(dataTermino, experiencia.DataTermino);
            Assert.AreEqual(nomeEmpresa, experiencia.Empresa);
            Assert.AreEqual(nomeCargo, experiencia.Cargo);
            Assert.AreEqual(atividadeExercida, experiencia.AtividadeExercida);
            Assert.AreEqual(area, experiencia.Area);
        }
    }
}
