using Microsoft.AspNetCore;

using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;



namespace Authorization
{
    public class SecurityContext
    {
        private readonly IHttpContextAccessor httpContextAcessor;

        public SecurityContext(IHttpContextAccessor httpContextAcessor) 
        {
            this.httpContextAcessor = httpContextAcessor;
        }

        public void Create()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin")
            };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);


            await HttpContextAccessor.HttpContext.SignInAsync()
        }
    }
}
