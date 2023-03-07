using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYAPP.Dtos.Character;

namespace MYAPP.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDtoResponse>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDtoResponse>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDtoResponse>>> AddCharacter(AddCharacterDtoRequest newCharacter); 
        Task<ServiceResponse<GetCharacterDtoResponse>> UpdateCharacter(UpdateCharacterDtoRequest updatedCharacter);
        Task<ServiceResponse<List<GetCharacterDtoResponse>>> DeleteCharacter(int id); 
    }
}