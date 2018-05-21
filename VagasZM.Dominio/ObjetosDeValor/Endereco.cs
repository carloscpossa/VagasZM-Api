using FluentValidator;
using VagasZM.Compartilhado.ObjetosDeValor;
using VagasZM.Dominio.Enumeracoes;

namespace VagasZM.Dominio.ObjetosDeValor
{
    public class Endereco : ObjetoDeValor
    {
        protected Endereco()
        {

        }

        public Endereco(string logradouro, string numero, string complemento, string bairro, string cidade, Estados uf) : this()
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;

            new ValidationContract<Endereco>(this)
                .IsRequired(x => x.Logradouro, "O Logradouro é de preenchimento obrigatório")                
                .HasMinLenght(x => x.Logradouro, 2, "O Logradou deve ter no mínimo 2 caracteres")
                .HasMaxLenght(x => x.Logradouro, 60, "O Logradouro deve ter no máximo 60 caracteres")
                .IsRequired(x => x.Numero, "O número do endereço é obrigatório")
                .HasMaxLenght(x => x.Numero, 60, "O númedo do endereço deve ter no máximo 60 caracteres")
                .IsRequired(x => x.Bairro, "O bairro é de preenchimento obrigatório")
                .HasMinLenght(x => x.Bairro, 2, "O bairro deve ter no mínimo 2 caracteres")
                .HasMaxLenght(x => x.Bairro, 60, "O bairro deve ter no máximo 60 caracteres")
                .IsRequired(x => x.Cidade, "A cidade é de preenchimento obrigatório")
                .HasMinLenght(x => x.Cidade, 2, "A cidade deve ter no mínimo dois caracteres")
                .HasMaxLenght(x => x.Cidade, 60, "A cidade deve ter no máximo sessenta caracteres");

            if (string.IsNullOrWhiteSpace(Logradouro))
            {
                AddNotification("Logradouro", "O Logradouro é de preenchimento obrigatório");
            }

            if (string.IsNullOrWhiteSpace(Numero))
            {
                AddNotification("Numero", "O Número é de preenchimento obrigatório");
            }

            if (string.IsNullOrWhiteSpace(Bairro))
            {
                AddNotification("Bairro", "O Bairro é de preenchimento obrigatório");
            }

            if (string.IsNullOrWhiteSpace(Cidade))
            {
                AddNotification("Cidade", "A cidade é de preenchimento obrigatório");
            }
        }
        

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public Estados Uf { get; private set; }
    }
}
