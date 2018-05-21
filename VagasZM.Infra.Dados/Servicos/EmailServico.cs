using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using VagasZM.Dominio.Servicos;

namespace VagasZM.Infra.Dados.Servicos
{
    public class EmailServico : IEmailServico
    {
        public async Task Enviar(string nome, string email, string assunto, string corpo)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("carloscpossa@gmail.com", "Carlos Possa");
            var subject = assunto;
            var to = new EmailAddress(email, nome);
            var plainTextContent = "";
            var htmlContent = corpo;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
