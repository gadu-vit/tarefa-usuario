using ApiTarefaUsuario.Auth;
using ApiTarefaUsuario.Models;
using ApiTarefaUsuario.Models.ViewModels;
using ApiTarefaUsuario.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefaUsuario.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody]Usuario model, [FromServices]IUsuarioRepository repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            repository.Create(model);

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]UsuarioLogin model, [FromServices] IUsuarioRepository repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            Usuario usuario = repository.Read(model.Email, model.Senha);

            if (usuario == null)
                return Unauthorized();

            usuario.Senha = "";

            var geracaoToken = new GeracaoToken();
            return Ok(new
            {
                usuario = usuario,

                token = geracaoToken.GenerateToken(usuario)
            });
        }

    }
}
