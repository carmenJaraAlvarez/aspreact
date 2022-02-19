using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_React.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ILogger<CatController> _logger;
        private readonly IConfiguration _configuration;

        public CatController(ILogger<CatController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        // GET: api/<ValuesController>
        //TODO cors for developer mode
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public async Task<Cat> Get()
        {
            var BASE_URL = "https://api.thecatapi.com";
            var CatApiKey = "d96c4da6 - e4ba - 4252 - 89cb - e4c4cc3a3999";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", _configuration[CatApiKey]);

            var resp = await client.GetStringAsync(BASE_URL + "/v1/images/search");
            var cats = JsonSerializer.Deserialize<Cat[]>(resp);
            return cats[0];
        }

       
    }
}
