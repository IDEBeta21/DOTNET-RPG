using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYAPP.Dtos.Character;

namespace MYAPP.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter); 
    }
}