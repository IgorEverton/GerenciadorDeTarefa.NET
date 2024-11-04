namespace GerenciadorDeTarefa.Model;

public class Tarefa
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }
    public Boolean Status {  get; set; }

    public Tarefa(Guid id, string titulo, string descricao, DateTime dataCriacao, DateTime dataConclusao, bool status)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = dataCriacao;
        DataConclusao = dataConclusao;
        Status = status;
    }

}
