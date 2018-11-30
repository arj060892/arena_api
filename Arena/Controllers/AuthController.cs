using Arena.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Arena.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private Arena.Models.DB.arena1Context _context = new Models.DB.arena1Context();
        // GET: /<controller>/
        [HttpPost("token")]
        public IActionResult Token([FromBody] Users user)
        {
            var username = user.Username;
            var password = user.Password;
            

            var product = _context.AuthPlayer
                .FromSql("EXECUTE dbo.sp_auth_player {0},{1}", username,password)
                .ToList();

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