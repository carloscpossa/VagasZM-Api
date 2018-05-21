using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace VagasZM.API.Seguranca
{
    public class TokenOptions
    {
        public string Issuer { get; set; }

        public string Subject { get; set; }

        public string Audience { get; set; }

        public DateTime NotBefore { get; set; } = DateTime.UtcNow;

        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        public TimeSpan ValidFor { get; set; } = TimeSpan.FromDays(1);

        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public Func<Task<string>> JtiGenerator =>
          () => Task.FromResult(Guid.NewGuid().ToString());

        public SigningCredentials SigningCredentials { get; set; }

        public bool Validate()
        {
            //if (options == null) throw new ArgumentNullException(nameof(options));

            if (this.ValidFor <= TimeSpan.Zero)
                throw new ArgumentException("O período deve ser maior que zero", nameof(TokenOptions.ValidFor));

            if (this.SigningCredentials == null)
                throw new ArgumentNullException(nameof(TokenOptions.SigningCredentials));

            if (this.JtiGenerator == null)
                throw new ArgumentNullException(nameof(TokenOptions.JtiGenerator));

            return true;
        }

    }
}
