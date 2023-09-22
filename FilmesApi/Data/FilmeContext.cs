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

    //sobrecrista do metodo

    //codigo abaixo diz: que a entidade Sessao tera como chave "sessao.FilmeId" e "sessao.CinemaId"
    protected override void OnModelCreating(ModelBuilder builder)
    {   
        builder.Entity<Sessao>()
            .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });
        
        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);
       
        builder.Entity<Sessao>()
           .HasOne(sessao => sessao.Filme)
           .WithMany(cinema => cinema.Sessoes)
           .HasForeignKey(sessao => sessao.FilmeId);

         //definir qual o tipo de deleção queremos
        builder.Entity<Endereco>()
            .HasOne(Endereco => Endereco.Cinema)
            .WithOne(cinema => cinema.Endereco)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Endereco>()
           .HasOne(Endereco => Endereco.Pessoa)
           .WithOne(pessoa => pessoa.Endereco)
           .OnDelete(DeleteBehavior.Restrict);

    }

    

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<Chamado> Chamados { get; set; }


}
