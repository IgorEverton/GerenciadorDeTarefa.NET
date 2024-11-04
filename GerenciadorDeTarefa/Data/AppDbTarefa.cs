using GerenciadorDeTarefa.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefa.Data;

public class AppDbTarefa: DbContext
{
    public AppDbTarefa(DbContextOptions<AppDbTarefa> options) : base(options){ }

    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Tarefa>();

    }
}
