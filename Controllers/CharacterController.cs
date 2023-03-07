using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MYAPP.Dtos.Character;
using MYAPP.Services.CharacterService;

namespace MYAPP.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {   
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
             _characterService = characterService;
        }
        
        [HttpGet("GetAllCharacters")]// Returs all the Characters
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDtoResponse>>>> Get(){
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("GetSingleCharacterById")]// Returns a single character with id provided 
        public async Task<ActionResult<ServiceResponse<GetCharacterDtoResponse>>> GetSingle(int id){
            var response = await _characterService.GetCharacterById(id);
            if(response.Data == null) return NotFound(response);
            return Ok(response);
        }

        [HttpPost("AddCharacter")]//Add new Character
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDtoResponse>>>> AddCharacter(AddCharacterDtoRequest newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut("UpdateCharacterById")]//Update character information
        public async Task<ActionResult<ServiceResponse<GetCharacterDtoResponse>>> UpdateCharacter(UpdateCharacterDtoRequest updatedCharacter){
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data == null){
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("DeleteCharacterById")]// Returns a single character with id provided 
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDtoResponse>>>> Delete(int id){
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data == null){
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}