using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuotesManagement.API.Models;
using QuotesManagement.Areas.Identity.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuotesManagement.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _confi;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IConfiguration config, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _confi = config;
            _signInManager = signInManager;
            this._userManager = userManager;
        }


        [HttpPost("/api/Auth/Login")]
        public IActionResult Login([FromBody] UserModel user)
        {
            IActionResult response = Unauthorized();

            if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Username or Password cannot be null"
                });
            }
            var loginInfo = new ApplicationUser();
            loginInfo.UserName = user.UserName;


            var isAuthenticated = AuthenticateUser(loginInfo, user.Password);

            if (isAuthenticated.Result)
            {
                var tokenStr = GenerateJWT(loginInfo);



                return new OkObjectResult(new
                {
                    success = true,
                    message = "You are authenticated",
                    token = tokenStr
                });
            }

            return BadRequest(new
            {
                success = false,
                message = "Invalid login credentials"

            });
        }


        [HttpPost("/api/Auth/Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Email))
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Not all data are provided"
                });
            }

            var appUser = new ApplicationUser { UserName = user.UserName, Email = user.Email };
            var result = await _userManager.CreateAsync(appUser, user.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, isPersistent: false);
                return new OkObjectResult(new
                {
                    success = true,
                    message = "Registered Successfully",
                    data = appUser
                });
            }

            return BadRequest(new
            {
                success = false,
                message = "There was an error. Please try again"
            });
        }




        private async Task<bool> AuthenticateUser(ApplicationUser loginInfo, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(loginInfo.UserName, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        private string GenerateJWT(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confi["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _confi["JWT:Issuer"],
                audience: _confi["JWT:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);


            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodeToken;
        }
    }
}
