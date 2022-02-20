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
    public class MongoCatController : Controller
    {
        private IMongoCatCollection db = new MongoCatCollection();

        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllMongoCats()
        {
            return Ok(await db.GetAllMongoCats());
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMongoCatDetails(string id)
        {
            return Ok(await db.GetMongoCat(id));
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateCat([FromBody] MongoCat mcat)
        {
            if (mcat == null)
            {
                return BadRequest();
            }
            else
            {
                
                await db.InsertMongoCat(mcat);  
                return Created("Created", true);
            }
        }
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCat([FromBody] MongoCat mcat, string id)
        {
            if (mcat == null)
            {
                return BadRequest();
            }
            else
            {
                mcat.Id = new ObjectId(id);
                await db.UpdateMongoCat(mcat);
                return Created("Created", true);
            }
        }
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat(string id)
        {
            await db.DeleteMongoCat(id);
            return NoContent();//>>ok
        }


    }
}
