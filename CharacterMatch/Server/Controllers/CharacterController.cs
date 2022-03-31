using CharacterMatch.Server.Services.CharacterServices;
using CharacterMatch.Shared.CharacterModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllCharactersAsync());
        }

        [HttpGet("{id")]
        [AllowAnonymous]
        public async Task<IActionResult> GetbyId(int id)
        {
            var series = await _service.GetCharacterByIdAsync(id);
            if (series is null) return NotFound();

            return Ok(series);
        }

        [HttpGet("/CharactersWithTraits")]
        public async Task<IActionResult> GetWithTraits()
        {
            return Ok(await _service.GetAllCharactersWithTraitsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CharacterCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            var success = await _service.CreateCharacterAsync(model);

            return success ? Ok() : UnprocessableEntity();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CharacterUpdate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (model == null) return BadRequest();

            if (model.Id != id) return BadRequest("Id Missmatch");

            var success = await _service.UpdateCharacterAsync(model);

            return success ? Ok() : UnprocessableEntity();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteCharacterAsync(id);
            return success ? Ok() : NotFound();
        }
    }
}
