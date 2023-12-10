using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Aplication.Conta;
using Spotify.Aplication.Conta.Dto;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly UsuarioService _usuarioService=new UsuarioService(); 

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CriaConta(CriarContaDTO dtousuario)
        {
            if(ModelState.IsValid==false)
                return BadRequest(ModelState);
            this._usuarioService.CriarConta(dtousuario);
            return Created($"/usuario/{dtousuario.Id}", dtousuario);
        }

        [HttpGet("{id}")]
        public IActionResult ObtemUsuario(Guid id)
        {
            var result = this._usuarioService.ObtemUsuario(id);

            if (result == null)

                return NotFound();
        return Ok(result);
        }
        [HttpPost("{id}/favoritar")]//cria uma rota
        public IActionResult FavoritaAMusica(Guid id,[FromBody] FavoritarDto favoritarDto) {

             this._usuarioService.FavoritarMusica(id, favoritarDto.IdMusica);
            return Ok();
        }


    }
}
