using System.Text.RegularExpressions;
using VagasZM.Compartilhado.ObjetosDeValor;

namespace VagasZM.Dominio.ObjetosDeValor
{
    public class Telefone : ObjetoDeValor
    {
        protected Telefone():base()
        {

        }

        public Telefone(string Numero) : this()
        {
            this.Numero = Numero;
            if (!Validar(this.Numero))
            {
                AddNotification("Telefone", "Telefone inválido. O telefone deve conter apenas dígitos.");
            }
        }

        public string Numero { get; private set; }

        private bool Validar(string numero)
        {
            Regex expressaTelefone = new Regex(@"^[1-9]{2}[2-9][0-9]{3,4}[0-9]{4}$");
            return expressaTelefone.IsMatch(numero);
        }
    }
}
