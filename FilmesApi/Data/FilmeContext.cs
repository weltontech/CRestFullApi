using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

//Classe de contexto de Banco de dados, extende de DbContext
public class FilmeContext : DbContext
{
    //Contrutor 
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        //passagem das opções para o contrutor da classe que extendemos
        : base(opts)
    { }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }

    public DbSet<Pessoa> Pessoa { get; set; }

}
