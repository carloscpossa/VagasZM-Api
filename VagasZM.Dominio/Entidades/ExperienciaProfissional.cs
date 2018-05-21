using FluentValidator;
using System;
using VagasZM.Compartilhado.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Entidades
{
    public class ExperienciaProfissional : Entidade
    {
        protected ExperienciaProfissional() : base()
        {

        }

        public ExperienciaProfissional(DateTime dataInicio, DateTime? dataTermino, Nome empresa, Nome cargo, AreaProfissional area, Texto atividadeExercida) : this()
        {
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            Empresa = empresa;
            Cargo = cargo;
            Area = area;
            AtividadeExercida = atividadeExercida;

            new ValidationContract<ExperienciaProfissional>(this)
                .IsNotNull(Empresa, "A empresa da experiência profissional é de preenchimento obrigatório")
                .IsNotNull(Cargo, "O cargo da experiência profissional é de preenchimento obrigatório")
                .IsNotNull(Area, "A área da experiência profissional é de preenchimento obrigatório");                

            if (DataTermino!=null && DataTermino < DataInicio)
            {
                AddNotification("DataTermino", "A data de término não pode ser menor que a data de início da experiência profissional");
            }
        }
        

        public DateTime DataInicio { get; private set; }
        public DateTime? DataTermino { get; private set; }
        public Nome Empresa { get; private set; }
        public Nome Cargo { get; private set; }
        public AreaProfissional Area { get; private set; }
        public Texto AtividadeExercida { get; private set; }
    }
}
