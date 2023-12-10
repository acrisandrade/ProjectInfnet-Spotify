using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Aplication.Streaming;
using Spotify.Aplication.Streaming.Dto;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaController : ControllerBase
    {
        private BandaService _bandaService = new BandaService();
        public BandaController() { }

        [HttpPost]
        public IActionResult criarBanda(BandaDto bandaDto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);
            this._bandaService.CriaBanda(bandaDto);
            return Created($"/banda/{bandaDto.Id}", bandaDto);
        }

        [HttpGet("{id}")]
        public IActionResult ObtemBanda(Guid id)
        {
            var result = this._bandaService.ObterBanda(id);

            if (result == null)

                return NotFound();
            return Ok(result);
        }

    }
}
