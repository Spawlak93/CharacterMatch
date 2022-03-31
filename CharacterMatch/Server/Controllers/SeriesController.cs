using CharacterMatch.Server.Services.SeriesServices;
using CharacterMatch.Shared.SeriesModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _service;

        public SeriesController(ISeriesService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllSeriesAsync());
        }

        [HttpGet("{id")]
        [AllowAnonymous]
        public async Task<IActionResult> GetbyId(int id)
        {
            var series = await _service.GetSeriesByIdAsync(id);
            if(series is null) return NotFound();

            return Ok(series);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SeriesCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            var success = await _service.CreateSeriesAsync(model);

            return success ? Ok() : UnprocessableEntity();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SeriesUpdate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (model == null) return BadRequest();

            if (model.Id != id) return BadRequest("Id Missmatch");

            //replace with trycatch and exceptions to handle notfound etc...
            var success = await _service.UpdateSeriesAsync(model);

            return success ? Ok() : UnprocessableEntity();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteSeriesAsync(id);
            return success ? Ok() : NotFound();
        }
    }

}
