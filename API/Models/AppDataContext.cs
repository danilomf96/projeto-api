using Microsoft.EntityFrameworkCore;

namespace API.Models;

//Classe que representa o EntityFrameworkCore : Code First
public class AppDataContext : DbContext
{
    //Representação das classes que vao virar tabelas do banco de dados
    public DbSet<Produto> Produtos { get; set; }

    //override OnConfiguring
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Configuraçao da conexão com o banco de dados
        optionsBuilder.UseSqlite("Data Source=app.db");

    }
}
