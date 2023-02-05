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
        public async Task<ActionResult<List<Character>>> Get(){
            return Ok(await _characterService.GetAllCharacters());
        }

        // Returns a single character with id provided 
        [HttpGet("GetCharacter")]
        public async Task<ActionResult<Character>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}