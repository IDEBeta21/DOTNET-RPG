using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetRPG.API.Dtos.Character;

namespace DotNetRPG.API.Services.CharacterService
{
    public interface ICharacterService
    {
        ServiceResponse<List<GetCharacterDtoResponse>> GetAllCharacters();
        ServiceResponse<GetCharacterDtoResponse> GetCharacterById(GetSingleCharacterRequest singleCharacterRequest);
        ServiceResponse<List<GetCharacterDtoResponse>> AddCharacter(AddCharacterDtoRequest newCharacter); 
        ServiceResponse<GetCharacterDtoResponse> UpdateCharacter(UpdateCharacterDtoRequest updatedCharacter);
        ServiceResponse<List<GetCharacterDtoResponse>> DeleteCharacterById(DeleteCharacterRequest deleteCharacterRequest);
    }
}