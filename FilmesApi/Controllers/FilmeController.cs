﻿using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    //Injeção de dependencia do context
    //declararando um campo 
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Obejto com os campos necessários para criação de
    /// um filme </param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a inserção seja feita com sucesso</response>
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        //Fazendo um mapeamento de um filme a partir de um filmeDTO
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        //O padrão REST pede que ao adicionar um objeto, voce retorne o objeto e o caminho deste objeto
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);

    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilme([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).ToList());

    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {

        var filme = _context.Filmes
            .FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        //a linha abaixo vai recuperar o filme no banco a partir do id
        var filme = _context.Filmes.FirstOrDefault(
            //quero que este filme que eu estou procurando tenha o mesmo id que estou recebendo
            filme => filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, 
        [FromBody] JsonPatchDocument<UpdateFilmeDto> patch)
    {
        //a linha abaixo vai recuperar o filme no banco a partir do id
        var filme = _context.Filmes.FirstOrDefault(
            //quero que este filme que eu estou procurando tenha o mesmo id que estou recebendo
            filme => filme.Id == id);
        if (filme == null) return NotFound();
        
        //converte o filme que pegamos no banco para conseguir aplicar regras de validação
        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        //aplica as mudanças que queremos ao objeto
        patch.ApplyTo(filmeParaAtualizar, ModelState);
        //valida se o patch.apply funcionou e se as mudanças no forem validas
        if (!TryValidateModel(filme))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        //a linha abaixo vai recuperar o filme no banco a partir do id
        var filme = _context.Filmes.FirstOrDefault(
            //quero que este filme que eu estou procurando tenha o mesmo id que estou recebendo
            filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
   

}