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
        public IActionResult Login(LoginVM request)
        {

            var User = _IUnitOfWork.Users.Get(s => s.Email == request.Email);
                


          
            if (User == null)
                return Unauthorized("Invalid credentials");


          
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, User.Password);


       
            if (!isValidPassword)
                return Unauthorized("Invalid credentials");


            // Step 3: Create claims that represent the authenticated user's identity.
            // These claims will be embedded inside the JWT.
            var claims = new[]
            {
                // Unique identifier for the student
                new Claim(ClaimTypes.NameIdentifier, User.Id.ToString()),


                // Student email address
                new Claim(ClaimTypes.Email, User.Email),


                // Role (Student or Admin) used later for authorization
                 new Claim(ClaimTypes.Role, User.Role)
            };


            // Step 4: Create the symmetric security key used to sign the JWT.
            // This key must match the key used in JWT validation middleware.
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456"));


            // Step 5: Define the signing credentials.
            // This specifies the algorithm used to sign the token.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            // Step 6: Create the JWT token.
            // The token includes issuer, audience, claims, expiration, and signature.
            var token = new JwtSecurityToken(
                issuer: "ClientApi",
                audience: "ClientApiUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );


            // Step 7: Return the serialized JWT token to the client.
            // The client will send this token with future requests.
            var Token = new JwtSecurityTokenHandler().WriteToken(token);


            return RedirectToAction("Index", "Home");
        }


    }
}
