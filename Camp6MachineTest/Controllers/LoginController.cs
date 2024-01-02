using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System;
using Camp6MachineTest.Repository;
using Camp6MachineTest.Models;

namespace Camp6MachineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private IConfiguration _Config;
        public LoginController(ILoginRepository loginRepository, IConfiguration Config)
        {
            _loginRepository = loginRepository;
            _Config = Config;

        }
        // get a user
        private LoginTbl Authenticateauser(string username, string password)
        {
            LoginTbl login = _loginRepository.ValidataeUser(username, password);
            if (login != null)
            {
                return login;
            }
            return null;
        }
        //Generate Json web token
        private string GenerateJsonwebtoken(LoginTbl login)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["Jwt:Key"]));
            var Credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            //Generate Token
            var token = new JwtSecurityToken(_Config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: Credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet("{userName}/{password}")]
        public IActionResult Loginuser(string username, string password)
        {
            IActionResult response = Unauthorized();

            //Authenticate the user by Passing Username, password
            LoginTbl dblogin = Authenticateauser(username, password);
            if (dblogin != null)
            {
                var tokenString = GenerateJsonwebtoken(dblogin);
                response = Ok(new
                {
                    uName = dblogin.Username,
                    uPassword = dblogin.Password,
                    LId = dblogin.LId,
                    tokenString = tokenString
                });
            }
            return response;
        }
    }
}
