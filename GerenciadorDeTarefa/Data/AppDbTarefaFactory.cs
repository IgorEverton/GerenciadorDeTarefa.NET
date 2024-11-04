using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GerenciadorDeTarefa.Data;

public class AppDbTarefaFactory : IDesignTimeDbContextFactory<AppDbTarefa>
{
    public AppDbTarefa CreateDbContext(string[] args)
    {
        var basePath = "C:/Users/evert/source/repos/GerenciadorDeTarefa/GerenciadorDeTarefa";

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var optionBuilder = new DbContextOptionsBuilder<AppDbTarefa>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionBuilder.UseSqlServer(connectionString);

        return new AppDbTarefa(optionBuilder.Options);
    }
}
