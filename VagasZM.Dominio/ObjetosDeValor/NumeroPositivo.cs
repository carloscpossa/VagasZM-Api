using FluentValidator;
using VagasZM.Compartilhado.ObjetosDeValor;

namespace VagasZM.Dominio.ObjetosDeValor
{
    public class NumeroPositivo : ObjetoDeValor
    {
        protected NumeroPositivo():base()
        {

        }
        public NumeroPositivo(double valor):this()
        {
            this.Valor = valor;

            new ValidationContract<NumeroPositivo>(this)
                .IsGreaterThan(x => x.Valor, 0.00000001, "O valor informado deve ser positivo");
        }

        public double Valor { get; private set; }
    }
}
