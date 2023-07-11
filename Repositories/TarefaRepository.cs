using ApiTarefaUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefaUsuario.Repositories
{
    public interface ITarefaRepository
    {
        List<Tarefa> Read(int id);
        void Create(Tarefa tarefa);
        void Delete(int id);
        void Update(int id, Tarefa tarefa);
    }

    public class TarefaRepository : ITarefaRepository
    {
        private readonly DataContext _context;

        public TarefaRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            _context.Entry(tarefa).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Tarefa> Read(int id)
        {
            return _context.Tarefas.Where(tarefa => tarefa.UsuarioId == id).ToList();
        }

        public void Update(int id, Tarefa tarefa)
        {
            var _tarefa = _context.Tarefas.Find(id);

            _tarefa.Nome = tarefa.Nome;
            _tarefa.Concluida = tarefa.Concluida;

            _context.Entry(_tarefa).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
