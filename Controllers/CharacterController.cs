using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MYAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character {Id = 1, Name = "Sam"}
        };
        
        // Returs all the Characters
        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get(){
            return Ok(characters);
        }

        // Returns a single character with id provided
        [HttpGet("GetSingle")]
        public ActionResult<Character> GetSingle(int id){
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }
    }
}