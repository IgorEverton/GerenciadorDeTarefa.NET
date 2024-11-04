using GerenciadorDeTarefa.Data;
using GerenciadorDeTarefa.Model;
using GerenciadorDeTarefa.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefa.Repository;

public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbTarefa _context;
    public TarefaRepository(AppDbTarefa context)
    {
        _context = context; 
    }

    public async Task<Tarefa> CriarTarefa(Tarefa tarefa)
    {
        tarefa.DataCriacao = DateTime.Now.ToLocalTime();
        await _context.Tarefas.AddAsync(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }

    public async Task<int> AtualizarTarefa(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        return await _context.SaveChangesAsync();
    }


    public async Task<Tarefa> ObterTarefaPorId(Guid id)
    {
        return await _context.Tarefas.FindAsync(id);
    }

    public async Task<IEnumerable<Tarefa>> ObterTodasTarefas()
    {
        return await _context.Tarefas.AsNoTracking().ToListAsync();
    }

    public async Task DeletarTarefa(Guid id)
    {
        var tarefaEncontrada = _context.Tarefas.Find(id);

        if(tarefaEncontrada != null)
        {
            _context.Remove(tarefaEncontrada);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception($"Tarefa {id} não encontrada");
        }
    }

}
