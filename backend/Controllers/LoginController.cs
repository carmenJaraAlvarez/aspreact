using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IMongoCatCollection db = new MongoCatCollection();

    
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Credential credential)
        {
            if (credential==null)
            {
                return BadRequest();
            }
            else
            {
                //TODO developer mode
                Console.WriteLine("credential:");
                var token = 1234;
                //await db.GetAllMongoCats();
                return Created("Created", token);
            }
        }

        public class Credential
        {
            private string username;    
            private string password;
        }
    }
}
