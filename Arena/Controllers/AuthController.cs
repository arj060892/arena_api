using Arena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Arena.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        // GET: /<controller>/
        [HttpPost("token")]
        public IActionResult Token([FromBody] Users user)
        {
            var username = user.Username;
            var password = user.Password;


            //if (username=="akh" && password=="af")
            //{
            var claimData = new[] { new Claim(ClaimTypes.Name, username) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdfawefwewrwwefjnwkf"));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer: "mysite.com",
                audience: "mysite.com",
                expires: DateTime.Now.AddMinutes(3),
                claims: claimData,
                signingCredentials: signInCred
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(tokenString);

            //}
            //return BadRequest("wrong request");


            //}
        }
    }
}