using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PMProjet.Authentication
{
    internal class AdminAuthHandler : AuthenticationHandler<AdminAuthOptions>
    {
        public AdminAuthHandler(IOptionsMonitor<AdminAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
           // options.
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return AuthenticateResult.NoResult();
        }
    }
}