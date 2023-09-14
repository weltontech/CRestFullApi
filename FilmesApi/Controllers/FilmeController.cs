﻿using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        //O padrão REST pede que ao adicionar um objeto, voce retorne o objeto e o caminho deste objeto
        return CreatedAtAction(nameof(RecuperaFilmePorId), new {id = filme.Id}, filme);

    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilme([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return filmes.Skip(skip).Take(take);

    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {

        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }

}