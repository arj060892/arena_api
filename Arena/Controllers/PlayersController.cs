using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Arena.Models.DB;
using Arena.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arena.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        string lockKey = "E546C8DF278CD5931069B522E695D4F2";
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            var userID = "0";
            if (identity != null)
            {
                userID = EncryptDecrypt.DecryptString(identity.Name, lockKey);
                IEnumerable<Claim> claims = identity.Claims;
                using (var _context = new arena1Context())
                {
                    var playerDtl = _context.PlayerDtls
                        .FromSql("EXECUTE dbo.sp_get_player_dtls {0}", userID)
                        .FirstOrDefault();
                    var json = JsonConvert.SerializeObject(playerDtl);
                    return Ok(json);
                }
            }
            return BadRequest("bad request");
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
