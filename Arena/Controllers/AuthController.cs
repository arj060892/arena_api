using Arena.Models;
using Arena.Models.DB;
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
        // GET: /<controller>/
        [HttpPost("token")]
        public IActionResult Token([FromBody] Users user)
        {
            var username = user.Username;
            var password = user.Password;

            using (var _context = new arena1Context())
            {
                var product = _context.AuthPlayer
                    .FromSql("EXECUTE dbo.sp_auth_player {0},{1}", username, password)
                    .ToList();

                if (product[0].isUserValid > 0)
                {
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

                }
            }

            return BadRequest("wrong request");


            //}
        }
    }
}