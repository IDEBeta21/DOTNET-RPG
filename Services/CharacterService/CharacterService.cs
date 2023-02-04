using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYAPP.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character {Id = 1, Name = "Sam"}
        };
        public List<Character> AddCharacter(Character newCharacter)
        {
            // throw new NotImplementedException();
            characters.Add(newCharacter);
            return characters;
        }

        public List<Character> GetAllCharacters()
        {
            // throw new NotImplementedException();
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            // throw new NotImplementedException();
            return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}