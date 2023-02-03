using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MYAPP.Services.CharacterService;

namespace MYAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {   
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
             _characterService = characterService;
        }

        // Returs all the Characters
        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get(){
            return Ok(_characterService.GetAllCharcters());
        }

        // Returns a single character with id provided 
        [HttpGet("GetCharacter")]
        public ActionResult<Character> GetSingle(int id){
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter){
            return Ok(_characterService.AddCharacter(newCharacter));
        }
    }
}