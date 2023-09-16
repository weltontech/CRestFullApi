using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;

[Controller]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    //Injejar dependencia contexto Usuario
    private UsuarioContext _context;
    private IMapper _mapper;

    public UsuarioController(UsuarioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult cadastrar([FromBody] CreateUsuarioDto usuarioDto)
    {
        //Fazendo um mapeamento de um filme a partir de um filmeDTO
              
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
        _context.Add(usuario);
        _context.SaveChanges();
        //O padrão REST pede que ao adicionar um objeto, voce retorne o objeto e o caminho deste objeto
        return CreatedAtAction(nameof(RecuperaUsuarioPorId), new { id = usuario.Id }, usuario);
    }

    [HttpGet]

    public IEnumerable<Usuario> RecuperaUsuario([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _context.Usuarios.Skip(skip).Take(take);

    }

    [HttpGet("{id}")]
    public IActionResult RecuperaUsuarioPorId(int id) 
    {
        var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaUsuario(int id, [FromBody] UpdateUsuarioDto usuarioDto)
    {
        //Recuperar o filme no banco a partir do id
        var usuario = _context.Usuarios.FirstOrDefault(
            usuario => usuario.Id == id);
        if (usuario == null) return NotFound();
        _mapper.Map(usuarioDto, usuario);
        _context.SaveChanges();
        return NoContent();
        
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaUsuarioParcial(int id,
        [FromBody] JsonPatchDocument<UpdateUsuarioDto> patch)
    {
        //Recupera o usuario no banco a partir do id
        var usuario = _context.Usuarios.FirstOrDefault(
            usuario => usuario.Id == id);
        if (usuario == null) return NotFound();

        //converte o filme que pegamos no banco para conseguir aplicar regras de validação
        var usuarioParaAtualizar = _mapper.Map<UpdateUsuarioDto>(usuario);
        //aplica as mudanças que queremos ao objeto
        patch.ApplyTo(usuarioParaAtualizar, ModelState);
        //valida se o patch.apply funcionou e se as mudanças no forem validas
        if (!TryValidateModel(usuario))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(usuarioParaAtualizar, usuario);
        _context.SaveChanges();
        return NoContent();

    }

}