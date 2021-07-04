using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        //List<Character> GetAllCharacters();
        //Task<List<Character>> GetAllCharacters();
        //Task<ServiceResponse<List<Character>>> GetAllCharacters();
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        //Character GetCharacterById(int id);
        //Task<Character> GetCharacterById(int id);
        //Task<ServiceResponse<Character>> GetCharacterById(int id);
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        //List<Character> AddCharacter(Character newCharacter);
        //Task<List<Character>> AddCharacter(Character newCharacter);
        //Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);

        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);

        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}