using ApiTarefaUsuario.Models;
using ApiTarefaUsuario.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefaUsuario.Controllers
{
    [Authorize]
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices]ITarefaRepository repository)
        {
            var id = int.Parse(User.Identity.Name);
            var tarefas = repository.Read(id);
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Tarefa model, [FromServices]ITarefaRepository repository)
        {
            if(!ModelState.IsValid)
                    return BadRequest();

            model.UsuarioId = int.Parse(User.Identity.Name);
            repository.Create(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Tarefa model, [FromServices] ITarefaRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            repository.Update(int.Parse(id), model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices] ITarefaRepository repository)
        {
            repository.Delete(int.Parse(id));
            return Ok();
        }
    }
}
