using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

//precisa extender de DbContext
public class UsuarioContext : DbContext
{

    public UsuarioContext(DbContextOptions<UsuarioContext> opts) 
    
        : base(opts)
    { }

    public DbSet<Usuario> Usuarios { get; set; }
}
