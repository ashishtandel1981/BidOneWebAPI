using BidOneWebAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace BidOneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        
        private readonly string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "persons.json");       

        [HttpPost]
        [Route("AddPerson")]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
            
            // Save the posted data to a JSON file
            string json = JsonConvert.SerializeObject(person, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, json);

            return Ok();
        }

        
    }
}
