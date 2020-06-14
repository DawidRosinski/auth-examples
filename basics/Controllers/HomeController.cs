using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers
{
    public class HomeController : Controller
    {
        // private readonly IAuthorizationService _authorizationService;

        // public HomeController(IAuthorizationService authorizationService)
        // {
        //     _authorizationService = authorizationService;
        // }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "Claim.DoB")]
        public IActionResult SecretPolicy()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            //Create a user

            //list of claims
            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim(ClaimTypes.Email, "Bob@gmail.com"),
                new Claim("Grandma.Says", "very nice boy"),
                new Claim(ClaimTypes.DateOfBirth, "test"),
            };

            var licenceClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob Foo"),
                new Claim("DrivingLicence", "A+"),
            };

            //create identity
            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
            var licenceIdentity = new ClaimsIdentity(licenceClaims, "Government");

            //user principle
            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenceIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DoStuff(
            [FromServices] IAuthorizationService authorizationService)
        {
            //example how to policy in the middle
            var builder = new AuthorizationPolicyBuilder("Schema");
            var customPolicy = builder.RequireClaim("Hello").Build();

            var authResult = await authorizationService.AuthorizeAsync(HttpContext.User, customPolicy);

            if (authResult.Succeeded)
            {
                //Do stuff
            }

            return View("Index");
        }
    }
}