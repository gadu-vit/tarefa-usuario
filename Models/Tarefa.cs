using System.ComponentModel.DataAnnotations;

namespace ApiTarefaUsuario.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }
        public bool Concluida { get; set; } = false;
    }
}
