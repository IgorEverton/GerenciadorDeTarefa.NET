using GerenciadorDeTarefa.Model;

namespace GerenciadorDeTarefa.Repository.Interface;

public interface ITarefaRepository
{
    public Task<Tarefa> ObterTarefaPorId(Guid id);
    public Task<IEnumerable<Tarefa>> ObterTodasTarefas();
    public Task<Tarefa> CriarTarefa(Tarefa tarefa);
    public Task<int> AtualizarTarefa(Tarefa tarefa);
    public Task DeletarTarefa(Guid id);

}
