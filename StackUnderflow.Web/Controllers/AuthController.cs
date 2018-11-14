using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StackUnderflow.Business;
using StackUnderflow.Data;
using StackUnderflow.Entities;

namespace StackUnderflow.Web.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private AuthService _AuthService;
        public AuthController(AuthService authService)
        {
            _AuthService = authService;
        }
        
        // GET api/values
        [HttpPost, Route("login")]
        public  IActionResult Login([FromBody]CreateUser user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var validLogin = _AuthService.Login(user).Result;
 
            if (validLogin)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
 
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5001",
                    audience: "http://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
 
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }

        [HttpPost, Route("register")]
        public IActionResult Register([FromBody]CreateUser user)
        {
            return Ok(_AuthService.Register(user));
        }
    }
}