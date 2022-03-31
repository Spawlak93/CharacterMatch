using CharacterMatch.Server.Services.TraitServices;
using CharacterMatch.Shared.TraitModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TraitController : ControllerBase
    {
        private readonly ITraitService _service;

        public TraitController(ITraitService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllTraitsAsync());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetbyId(int id)
        {
            var trait = await _service.GetTraitByIdAsync(id);
            if (trait is null) return NotFound();

            return Ok(trait);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TraitCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            bool success = await _service.CreateTraitAsync(model);

            if (success) return Ok();
            return UnprocessableEntity();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TraitUpdate model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if (model == null) return BadRequest();

            if (model.Id != id) return BadRequest("Id Missmatch");

            bool success = await _service.UpdateTraitAsync(model);
            if (success) return Ok();
            return UnprocessableEntity();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool success = await _service.DeleteTraitAsync(id);
            return success ? Ok() : NotFound();
        }
    }
}
