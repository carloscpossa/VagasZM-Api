using System.Threading.Tasks;

namespace VagasZM.Dominio.Servicos
{
    public interface IEmailServico
    {
        Task Enviar(string nome, string email, string assunto, string corpo);
    }
}
