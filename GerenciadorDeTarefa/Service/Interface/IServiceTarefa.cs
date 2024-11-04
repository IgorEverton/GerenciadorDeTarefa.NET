using GerenciadorDeTarefa.Model;

namespace GerenciadorDeTarefa.Service.Interface;

public interface IServiceTarefa
{
    public Task<Tarefa> ObterTarefaPorId(Guid id);
    public Task<IEnumerable<Tarefa>> RetornarTodasTarefas();
    public Task<Tarefa> CriarTarefa(Tarefa tarefa);
    public Task<int> AtualizarTarefa(Tarefa tarefa);
    public Task DeletarTarefa(Guid id);

}
