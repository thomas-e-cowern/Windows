using BookStoreWedApi.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BookStoreWedApi.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private readonly BookStoresDBContext _context;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            BookStoresDBContext context
            ) : base(options, logger, encoder, clock)
        {
            _context = context;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                Console.WriteLine("Authentication Header was not found");
                return AuthenticateResult.Fail("Authentication Header was not found");
            }

            try
            {
                AuthenticationHeaderValue authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                byte[] bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                string[] credetials = Encoding.UTF8.GetString(bytes).Split(" ");
                string email = credetials[0];
                string password = credetials[1];

                User user = _context.User.Where(usr => usr.EmailAddress == email && usr.Password == password).FirstOrDefault();

                if (user == null)
                {
                    return AuthenticateResult.Fail("Invalid username and password...");
                }
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.EmailAddress) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principle = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principle, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
            }
            catch (Exception)
            {
                return AuthenticateResult.Fail("Authentication has failed...");
            }

            return AuthenticateResult.Fail("Something went badly wrong...");
        }
    }
}
