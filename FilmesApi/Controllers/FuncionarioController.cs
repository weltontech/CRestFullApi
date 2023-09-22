using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{
    //injeção do context 
    private FilmeContext _context;
    private IMapper _mapper;

    public FuncionarioController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
    {
        //crio um objeto do tipo chamado e faz o mapeamento chamadoDto para um Chamado
        Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);
        //adiciono no contexto
        _context.Funcionarios.Add(funcionario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFuncionarioPorId), new { Id = funcionario.Id }, funcionarioDto);
    }

    [HttpGet]
    public IEnumerable<ReadFuncionarioDto> RecuperaFuncionarios([FromQuery]
            int? funcionarioId = null)
    {
        if (funcionarioId == null)

        {
            return _mapper.Map<List<ReadFuncionarioDto>>(_context.Funcionarios.ToList());
        }
        return _mapper.Map<List<ReadFuncionarioDto>>(_context.Funcionarios.FromSqlRaw($"SELECT id, Matricula, Email, Senha from chamados WHERE funcionarios.Id = {funcionarioId}").ToList());
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaFuncionarioPorId([FromQuery] int id)
    {
        Funcionario funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == id);
        if (funcionario == null)
        {
            ReadFuncionarioDto funcionarioDto = _mapper.Map<ReadFuncionarioDto>(funcionario);
        }
        return NotFound();

    }
}
