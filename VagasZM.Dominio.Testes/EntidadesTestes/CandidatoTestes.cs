using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.Enumeracoes;
using VagasZM.Dominio.ObjetosDeValor;


namespace VagasZM.Dominio.Testes.EntidadesTestes
{
    [TestClass]
    public class CandidatoTestes
    {        
        [TestCategory("Candidato - Novo Candidato")]
        [TestMethod]
        public void DadoUmEmailNuloOConstrutorDeveRetornarUmCandidatoInvalido()
        {
            Candidato candidato = new Candidato(null, new Nome("Carlos Possa"), new Telefone("3133441678"), new CPF("86267524582"), "88997766", "88997766");
            Assert.IsFalse(candidato.IsValid());
        }

        [TestCategory("Candidato - Novo Candidato")]
        [TestMethod]
        public void DadoUmEmailInvalidoOConstrutorDeveRetornarUmCandidatoInvalido()
        {
            Candidato candidato = new Candidato(new Email(""), new Nome("Carlos Possa"), new Telefone("3133441678"), new CPF("86267524582"), "88997766", "88997766");
            Assert.IsFalse(candidato.IsValid());
        }

        [TestCategory("Candidato - Novo Candidato")]
        [TestMethod]
        public void DadoUmNomeNuloOConstrutorDeveRetornarUmCandidatoInvalido()
        {
            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), null, new Telefone("3133441678"), new CPF("86267524582"), "88997766", "88997766");
            Assert.IsFalse(candidato.IsValid());
        }

        [TestCategory("Candidato - Novo Candidato")]
        [TestMethod]
        public void DadoUmNomeInvalidoOConstrutorDeveRetornarUmCandidatoInvalido()
        {
            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome(""), new Telefone("3133441678"), new CPF("86267524582"), "88997766", "88997766");
            Assert.IsFalse(candidato.IsValid());
        }

        [TestCategory("Candidato - Novo Candidato")]
        [TestMethod]
        public void DadaUmaSenhaNulaOConstrutorDeveRetornarUmCandidatoInvalido()
        {
            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), null, "88997766");
            Assert.IsFalse(candidato.IsValid());
        }

        [TestCategory("Candidato - Novo Candidato")]
        [TestMethod]
        public void DadaUmaSenhaVaziaOConstrutorDeveRetornarUmCandidatoInvalido()
        {
            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "", "");
            Assert.IsFalse(candidato.IsValid());
        }

        [TestCategory("Candidato - Novo Candidato")]
        [TestMethod]
        public void DadaUmaSenhaApenasComEspacosOConstrutorDeveRetornarUmCandidatoInvalido()
        {
            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "     ", "     ");
            Assert.IsFalse(candidato.IsValid());
        }

        [TestCategory("Candidato - Novo Candidato")]
        [TestMethod]
        public void DadaUmaSenhaDiferenteDaConfirmacaoDeSenhaOConstrutorDeveRetornarUmCandidatoInvalido()
        {
            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "98765123", "38765129");
            Assert.IsFalse(candidato.IsValid());
        }

        [TestCategory("Candidato - Novo Candidato")]
        [TestMethod]
        public void DadasTodasAsInformacoesValidasOConstrutorDeveraCriarUmCandidatoValido()
        {
            Email email = new Email("jose_das_couve@hotmail.com");
            Nome nome = new Nome("Joaquim José da Silva Xavier");
            Telefone telefone = new Telefone("3133441678");
            CPF cpf = new CPF("86267524582");

            Candidato candidato = new Candidato(email, nome, telefone, cpf, "98765123", "98765123");
            Assert.IsTrue(candidato.IsValid());

            Assert.AreEqual(email, candidato.Email);
            Assert.AreEqual(nome, candidato.Nome);
            Assert.AreEqual(telefone, candidato.Telefone);
            Assert.AreEqual(cpf, candidato.CPF);

        }

        [TestMethod]
        [TestCategory("Candidato - Autenticacao")]
        public void AutenticadoDeveRetornarFalsoSeASenhaDoCandidatoForNula()
        {
            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "98765123", "98765123");
            Assert.IsFalse(candidato.Autenticado(null));
        }

        [TestMethod]
        [TestCategory("Candidato - Autenticacao")]
        public void AutenticadoDeveRetornarFalsoSeASenhaDoCandidatoForEspacosEmBranco()
        {
            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "98765123", "98765123");
            Assert.IsFalse(candidato.Autenticado("    "));
        }

        [TestMethod]
        [TestCategory("Candidato - Autenticacao")]
        public void AutenticadoDeveRetornarFalsoSeASenhaForDiferenteDaSenhaDoCandidato()
        {
            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "98765123", "98765123");
            Assert.IsFalse(candidato.Autenticado("12345"));
        }

        [TestMethod]
        [TestCategory("Candidato - Autenticacao")]
        public void AutenticadoDeveRetornarVerdadeiroSeASenhaForIgualASenhaDoCandidato()
        {
            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "teste$1234*", "teste$1234*");
            Assert.IsTrue(candidato.Autenticado("teste$1234*"));
        }
        

        [TestMethod]
        [TestCategory("Candidato - Adicionar formacao escolar")]
        public void AdicionarFormacaoDeveAdicionarApenasFormacaoValida()
        {
            FormacaoEscolar formacao1 = new FormacaoEscolar(new DateTime(2001, 2, 1), new DateTime(2004, 12, 1), new Nome("Universidade PResidente Antonio Carlos"), new Nome("Ciência da Computação"), NivelFormacao.GraduacaoCompleta);
            FormacaoEscolar formacaoInvalida = new FormacaoEscolar(new DateTime(2001, 2, 1), null, null, null, NivelFormacao.GraduacaoCompleta);
            FormacaoEscolar formacao2 = new FormacaoEscolar(new DateTime(2013, 3, 1), new DateTime(2014, 11, 1), new Nome("PUC"), new Nome("Desenvolvimento de Aplicações Web"), NivelFormacao.Especializacao);
            FormacaoEscolar formacao3 = new FormacaoEscolar(new DateTime(1998, 2, 1), new DateTime(2000, 12, 1), new Nome("Colegio Qualquer"), new Nome("Ensino Médio"), NivelFormacao.EnsinoMedioCompleto);

            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "teste$1234*", "teste$1234*");
            candidato.AdicionarFormacao(formacao1);
            candidato.AdicionarFormacao(formacaoInvalida);
            candidato.AdicionarFormacao(formacao2);
            candidato.AdicionarFormacao(formacao3);
            candidato.AdicionarFormacao(null);

            Assert.AreEqual(3, candidato.FormacaoEscolar.Count);

            Assert.AreEqual(formacao1, candidato.FormacaoEscolar.ElementAt(0));
            Assert.AreEqual(formacao2, candidato.FormacaoEscolar.ElementAt(1));
            Assert.AreEqual(formacao3, candidato.FormacaoEscolar.ElementAt(2));
        }

        [TestMethod]
        [TestCategory("Candidato - Remover formacao escolar")]
        public void RemoverFormacaoDeveRemoverFormacaoEscolarCasoAMesmaPertencaAoCandidato()
        {
            FormacaoEscolar formacao1 = new FormacaoEscolar(new DateTime(2001, 2, 1), new DateTime(2004, 12, 1), new Nome("Universidade PResidente Antonio Carlos"), new Nome("Ciência da Computação"), NivelFormacao.GraduacaoCompleta);            
            FormacaoEscolar formacao2 = new FormacaoEscolar(new DateTime(2013, 3, 1), new DateTime(2014, 11, 1), new Nome("PUC"), new Nome("Desenvolvimento de Aplicações Web"), NivelFormacao.Especializacao);
            FormacaoEscolar formacao3 = new FormacaoEscolar(new DateTime(1998, 2, 1), new DateTime(2000, 12, 1), new Nome("Colegio Qualquer"), new Nome("Ensino Médio"), NivelFormacao.EnsinoMedioCompleto);
            FormacaoEscolar formacao4 = new FormacaoEscolar(new DateTime(1998, 2, 1), new DateTime(2000, 12, 1), new Nome("Colegio Técnico"), new Nome("Ensino Médio"), NivelFormacao.EnsinoMedioCompleto);
            FormacaoEscolar formacao5 = new FormacaoEscolar(new DateTime(1998, 2, 1), new DateTime(2000, 12, 1), new Nome("Faculdade do Zé"), new Nome("Ensino Médio"), NivelFormacao.EnsinoMedioCompleto);

            Candidato candidato = new Candidato(new Email("jose@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "teste$1234*", "teste$1234*");
            candidato.AdicionarFormacao(formacao1);            
            candidato.AdicionarFormacao(formacao2);
            candidato.AdicionarFormacao(formacao3);
            candidato.AdicionarFormacao(formacao4);
            candidato.AdicionarFormacao(formacao5);

            candidato.RemoverFormacao(formacao1);
            candidato.RemoverFormacao(formacao3);
            candidato.RemoverFormacao(formacao5);

            Assert.AreEqual(2, candidato.FormacaoEscolar.Count);

            Assert.AreEqual(formacao2, candidato.FormacaoEscolar.ElementAt(0));
            Assert.AreEqual(formacao4, candidato.FormacaoEscolar.ElementAt(1));
        }

        [TestMethod]
        [TestCategory("Candidato - Adicionar experiência profissional")]
        public void AdicionarExperienciaDeveAdicionarApenasExperienciaProfissionalValida()
        {
            ExperienciaProfissional experiencia1 = new ExperienciaProfissional(new DateTime(2005, 2, 1), new DateTime(2011, 5, 1), new Nome("Colchoes Insonia"), new Nome("Vendedor"), new AreaProfissional(new Nome("Vendas")), new Texto("Venda de colchoes no estado de Minas Gerais"));
            ExperienciaProfissional experiencia2 = new ExperienciaProfissional(new DateTime(2011, 7, 1), null, new Nome("Empresa Teste"), new Nome("Programador"), new AreaProfissional(new Nome("TI")), new Texto("Programador .NET"));
            ExperienciaProfissional experienciaInvalida = new ExperienciaProfissional(new DateTime(2005, 2, 1), new DateTime(2011, 5, 1), null, new Nome("Vendedor"), new AreaProfissional(new Nome("Vendas")), new Texto("Atividade qualquer"));

            Candidato candidato = new Candidato(new Email("jose_silva@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "teste$1234*", "teste$1234*");

            candidato.AdicionarExperiencia(null);
            candidato.AdicionarExperiencia(experiencia1);
            candidato.AdicionarExperiencia(experiencia2);
            candidato.AdicionarExperiencia(experienciaInvalida);

            Assert.AreEqual(2, candidato.ExperienciaProfissional.Count);

            Assert.AreEqual(experiencia1, candidato.ExperienciaProfissional.ElementAt(0));
            Assert.AreEqual(experiencia2, candidato.ExperienciaProfissional.ElementAt(1));
        }

        [TestMethod]
        [TestCategory("Candidato - Remover experiência profissional")]
        public void RemoverExperienciaDeveRemoverExperienciaProfissionalCasoAMesmaPertencaAoCandidato()
        {
            ExperienciaProfissional experiencia1 = new ExperienciaProfissional(new DateTime(2005, 2, 1), new DateTime(2011, 5, 1), new Nome("Colchoes Insonia"), new Nome("Vendedor"), new AreaProfissional(new Nome("Vendas")), new Texto("Venda de colchoes no estado de Minas Gerais"));
            ExperienciaProfissional experiencia2 = new ExperienciaProfissional(new DateTime(2011, 7, 1), new DateTime(2012, 7, 1), new Nome("Empresa Teste"), new Nome("Programador"), new AreaProfissional(new Nome("TI")), new Texto("Programador .NET"));
            ExperienciaProfissional experiencia3 = new ExperienciaProfissional(new DateTime(2013, 7, 1), new DateTime(2014, 7, 1), new Nome("Empresa Dois"), new Nome("Programador"), new AreaProfissional(new Nome("TI")), new Texto("Programador .NET"));
            ExperienciaProfissional experiencia4 = new ExperienciaProfissional(new DateTime(2015, 7, 1), new DateTime(2017, 7, 1), new Nome("Empresa TTTTT"), new Nome("Programador"), new AreaProfissional(new Nome("TI")), new Texto("Programador .NET"));
            ExperienciaProfissional experiencia5 = new ExperienciaProfissional(new DateTime(2017, 7, 10), null, new Nome("TI Ressaquinha"), new Nome("Programador"), new AreaProfissional(new Nome("TI")), new Texto("Programador .NET"));

            Candidato candidato = new Candidato(new Email("jose_silva@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "teste$1234*", "teste$1234*");

            candidato.AdicionarExperiencia(experiencia1);
            candidato.AdicionarExperiencia(experiencia2);
            candidato.AdicionarExperiencia(experiencia3);
            candidato.AdicionarExperiencia(experiencia4);
            candidato.AdicionarExperiencia(experiencia5);

            candidato.RemoverExperiencia(experiencia1);
            candidato.RemoverExperiencia(experiencia3);
            candidato.RemoverExperiencia(experiencia5);

            Assert.AreEqual(2, candidato.ExperienciaProfissional.Count);

            Assert.AreEqual(experiencia2, candidato.ExperienciaProfissional.ElementAt(0));
            Assert.AreEqual(experiencia4, candidato.ExperienciaProfissional.ElementAt(1));
        }

        [TestMethod]
        [TestCategory("Candidato - Informar Endereco")]
        public void DadoUmEnderecoNuloInformarEnderecoNaoDeveAtribuirNuloParaOEnderecoDoCandidato()
        {
            Candidato candidato = new Candidato(new Email("jose_silva@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "teste$1234*", "teste$1234*");
            candidato.InformarEndereco(null);
            Assert.IsNotNull(candidato.Endereco);
        }

        [TestMethod]
        [TestCategory("Candidato - Informar Endereco")]
        public void DadoUmEnderecoInvalidoInformarEnderecoNaoDeveAtribuirOEnderecoInvalidoParaOCandidato()
        {
            Candidato candidato = new Candidato(new Email("jose_silva@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "teste$1234*", "teste$1234*");
            Endereco endereco = new Endereco("", "94", "", "", "", Estados.SP);
            candidato.InformarEndereco(endereco);
            Assert.AreNotEqual(endereco, candidato.Endereco);
        }

        [TestMethod]
        [TestCategory("Candidato - Informar Endereco")]
        public void DadoUmEnderecoValidoInformarEnderecoDeveAtribuirAoCandidatoOEnderecoInformado()
        {
            Candidato candidato = new Candidato(new Email("jose_silva@hotmail.com"), new Nome("Joaquim José da Silva Xavier"), new Telefone("3133441678"), new CPF("86267524582"), "teste$1234*", "teste$1234*");
            Endereco endereco = new Endereco("Rua José das Couves", "94", "", "Centro", "São João Del Rey", Estados.MG);
            candidato.InformarEndereco(endereco);
            Assert.AreEqual(endereco, candidato.Endereco);
        }
    }
}
