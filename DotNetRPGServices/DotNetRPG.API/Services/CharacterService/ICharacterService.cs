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
        Task<ServiceResponse<GetCharacterDtoResponse>> GetCharacterById(GetSingleCharacterRequest singleCharacterRequest);
        Task<ServiceResponse<List<GetCharacterDtoResponse>>> AddCharacter(AddCharacterDtoRequest newCharacter); 
        Task<ServiceResponse<GetCharacterDtoResponse>> UpdateCharacter(UpdateCharacterDtoRequest updatedCharacter);
        Task<ServiceResponse<List<GetCharacterDtoResponse>>> DeleteCharacter(DeleteCharacterRequest deleteCharacterRequest);
    }
}