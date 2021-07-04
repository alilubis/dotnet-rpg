using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route(("[controller]"))]
    //[EnableCors("AllowOrigin")]
    public class CharacterController : ControllerBase
    {
        //private static Character knight = new Character();
        /*private static List<Character> characters = new List<Character>{
            new Character(),
            new Character {Id=1, Name="Sam"}
        };*/
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            //this.characterService = characterService;
            _characterService = characterService;
        }



        //[Route("GetAll")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            //return NotFound(knight);
            //return BadRequest(knight);
            //return Ok(knight);

            //return Ok(characters);
            return Ok(await _characterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        //public IActionResult GetSingle(){
        public async Task<IActionResult> GetSingle(int id)
        {
            //return Ok(characters[0]);

            //return Ok(characters.FirstOrDefault(c => c.Id == id));
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        //public async Task<IActionResult> AddCharacter(Character newCharacter)
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            //characters.Add(newCharacter);

            //return Ok(characters);
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updateCharacter);
            if(response.Data == null){
                return NotFound(response);
            }

            return Ok(await _characterService.UpdateCharacter(updateCharacter));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
            if(response.Data == null){
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}