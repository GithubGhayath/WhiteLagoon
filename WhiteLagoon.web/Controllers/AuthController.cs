using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.web.ViewModels.Login;


namespace WhiteLagoon.web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public AuthController(IUnitOfWork unitOfWork)
        {
            _IUnitOfWork = unitOfWork;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVM request)
        {
            var user = _IUnitOfWork.Users.Get(s => s.Email == request.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View(request);
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isValidPassword)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View(request);
            }

            //  Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            //  Identity
            var identity = new ClaimsIdentity(claims, "Cookies");

            //  Principal
            var principal = new ClaimsPrincipal(identity);

            //  Sign in (COOKIE gets created here)
            await HttpContext.SignInAsync("Cookies", principal);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login");
        }


    }
}
