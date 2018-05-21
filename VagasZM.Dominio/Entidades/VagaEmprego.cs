using FluentValidator;
using System;
using VagasZM.Compartilhado.Entidades;
using VagasZM.Dominio.Enumeracoes;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Entidades
{
    public class VagaEmprego : Entidade
    {
        protected VagaEmprego() : base()
        {
            Salario = new NumeroPositivo(0);
        }
        public VagaEmprego(Empresa empresa, Nome cargo, Texto descricao, Texto beneficios, AreaProfissional areaProfissional, Descricao horarioTrabalho, DateTime dataExpiracao, bool salarioAcombinar, NumeroPositivo salario, TipoContratacao tipoContratacao) : this()
        {

            DataCriacao = DateTime.Now;
            Empresa = empresa;
            Cargo = cargo;
            Descricao = descricao;
            Beneficios = beneficios;            
            AreaProfissional = areaProfissional;
            HorarioTrabalho = horarioTrabalho;            
            DataExpiracao = dataExpiracao;
            SalarioAcombinar = salarioAcombinar;
            Status = StatusVaga.Aberta;
            
            if (!SalarioAcombinar)
            {
                Salario = salario;
            }
            

            TipoContratacao = tipoContratacao;

            new ValidationContract<VagaEmprego>(this)
                .IsNotNull(Empresa, "A empresa dona da vaga de emprego não pode ser nula.")
                .IsNotNull(Cargo, "O cargo relacionado a vaga de emprego não pode ser nulo.")
                .IsNotNull(Descricao, "A Descrição da vaga não pode ser nula.")
                .IsNotNull(AreaProfissional, "A área profissional da vaga não pode ser nula.")
                .IsNotNull(TipoContratacao, "O tipo de contratação da vaga não pode ser nulo")
                .IsGreaterThan(x => x.DataExpiracao, DataCriacao, "A data de expiração não pode ser menor que a data de criação da vaga");

            if (Empresa != null)
            {
                AddNotifications(Empresa.Notifications);
            }

            if (Cargo != null)
            {
                AddNotifications(Cargo.Notifications);
            }

            if (Descricao != null)
            {
                AddNotifications(Descricao.Notifications);
            }

            if (Beneficios != null)
            {
                AddNotifications(Beneficios.Notifications);
            }

            if (AreaProfissional != null)
            {
                AddNotifications(AreaProfissional.Notifications);
            }

            if (HorarioTrabalho != null)
            {
                AddNotifications(HorarioTrabalho.Notifications);
            }

            if (!SalarioAcombinar && Salario != null)
            {
                AddNotifications(Salario.Notifications);
            }

            if (TipoContratacao != null)
            {
                AddNotifications(TipoContratacao.Notifications);
            }

            if (!SalarioAcombinar && Salario == null)
            {
                AddNotification("Salario", "O salário deve ser informado quando a opção de salário a combinar não for selecionada.");
            }            

        }        

        public Empresa Empresa { get; private set; }
        public Nome Cargo { get; private set; }
        public Texto Descricao { get; private set; }
        public Texto Beneficios { get; private set; }        
        public AreaProfissional AreaProfissional { get; private set; }
        public Descricao HorarioTrabalho { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataExpiracao { get; private set; }
        public bool SalarioAcombinar { get; private set; }
        public NumeroPositivo Salario { get; private set; }
        public TipoContratacao TipoContratacao { get; private set; }
        public StatusVaga Status { get; private set; }

        public void Encerrar()
        {
            Status = StatusVaga.Encerrada;
        }
    }
}
