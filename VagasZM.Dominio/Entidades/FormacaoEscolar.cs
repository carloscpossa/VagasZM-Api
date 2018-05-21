using FluentValidator;
using System;
using VagasZM.Compartilhado.Entidades;
using VagasZM.Dominio.Enumeracoes;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Entidades
{
    public class FormacaoEscolar : Entidade
    {
        
        protected FormacaoEscolar():base()
        {

        }

        public FormacaoEscolar(DateTime dataInicio, DateTime? dataTermino, Nome instituicao, Nome curso, NivelFormacao nivelFormacao) :this()
        {
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            Instituicao = instituicao;
            Curso = curso;
            NivelFormacao = nivelFormacao;

            new ValidationContract<FormacaoEscolar>(this)
                .IsNotNull(Instituicao, "A instituição da formação é de preenchimento obrigatório")
                .IsNotNull(Curso, "O curso é de preenchimento obrigatório");

            if (dataTermino!=null && dataTermino <= dataInicio)
            {
                AddNotification("dataTermino", "A data de término da formação não pode ser menor ou igual a data de início.");
            }
        }

        public DateTime DataInicio { get; private set; }
        public DateTime? DataTermino { get; private set; }
        public Nome Instituicao { get; private set; }
        public Nome Curso { get; private set; }
        public NivelFormacao NivelFormacao { get; private set; }
    }
}
