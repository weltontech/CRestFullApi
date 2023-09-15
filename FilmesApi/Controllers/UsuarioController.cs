using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Controller]
[Route("[controller]")]
public class UsuarioController
{
    
    private static List<Usuario> usuarios = new List<Usuario>();

    [HttpPost]
    public void cadastrar([FromBody] Usuario usuario)
    {
        usuarios.Add(usuario);
        Console.WriteLine(usuario.nome);
        Console.WriteLine(usuario.dataNascimento);
    }

    [HttpGet]
    public List<Usuario> RecuperaUsuario()
    {
        return usuarios;
    }

}
