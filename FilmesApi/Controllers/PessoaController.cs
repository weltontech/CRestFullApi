using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    //injeção do context 
    private FilmeContext _context;
    private IMapper _mapper;

    public PessoaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaPessoa([FromBody] CreatePessoaDto pessoaDto)
    {
        Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
        _context.Pessoa.Add(pessoa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaPessoasPorId), new { Id = pessoa.Id }, pessoaDto);
    }

    [HttpGet]
    public IEnumerable<ReadPessoaDto> RecuperaPessoas()
    {
        var listaDePessoas = _mapper.Map<List<ReadPessoaDto>>
       (_context.Pessoa.ToList());
        return listaDePessoas;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaPessoasPorId(int id)
    {
        Pessoa pessoa = _context.Pessoa.FirstOrDefault(pessoa => pessoa.Id == id);
        if (pessoa != null)
        {
            ReadPessoaDto pessoaDto = _mapper.Map<ReadPessoaDto>(pessoa);
            return Ok(pessoaDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaPessoa(int id, [FromBody] UpdatePessoaDto pessoaDto)
    {
        Pessoa pessoa = _context.Pessoa.FirstOrDefault(pessoa => pessoa.Id == id);
        if (pessoa == null)
        {
            return NotFound();
        }
        _mapper.Map(pessoaDto, pessoa);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Deletapessoa(int id)
    {
        Pessoa pessoa = _context.Pessoa.FirstOrDefault(pessoa => pessoa.Id == id);
        if (pessoa == null)
        {
            return NotFound();
        }
        _context.Remove(pessoa);
        _context.SaveChanges();
        return NoContent();
    }

}

