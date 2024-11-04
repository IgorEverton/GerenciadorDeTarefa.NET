using GerenciadorDeTarefa.Model;
using GerenciadorDeTarefa.Repository.Interface;
using GerenciadorDeTarefa.Service.Interface;

namespace GerenciadorDeTarefa.Service;

public class TarefaService : IServiceTarefa
{
    private readonly ITarefaRepository _tarefaRepository;

    public TarefaService(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task<int> AtualizarTarefa(Tarefa tarefa)
    {
        return await _tarefaRepository.AtualizarTarefa(tarefa);
    }

    public async Task<Tarefa> CriarTarefa(Tarefa tarefa)
    {
        return await _tarefaRepository.CriarTarefa(tarefa);
    }

    public async Task DeletarTarefa(Guid id)
    {
        await _tarefaRepository.DeletarTarefa(id);
    }

    public async Task<Tarefa> ObterTarefaPorId(Guid id)
    {
        return await _tarefaRepository.ObterTarefaPorId(id);
    }

    public async Task<IEnumerable<Tarefa>> RetornarTodasTarefas()
    {
        return await _tarefaRepository.ObterTodasTarefas();
    }
}
