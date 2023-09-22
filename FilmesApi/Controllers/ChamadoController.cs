using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ChamadoController : ControllerBase
    {
        //injeção do context 
        private FilmeContext _context;
        private IMapper _mapper;

        public ChamadoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaChamado([FromBody] CreateChamadoDto chamadoDto)
        {
            //crio um objeto do tipo chamado e faz o mapeamento chamadoDto para um Chamado
            Chamado chamado = _mapper.Map<Chamado>(chamadoDto);
            //adiciono no contexto
            _context.Chamados.Add(chamado);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaChamadosPorId), new { Id = chamado.Id }, chamadoDto);
        }
        
        [HttpGet]
        public IEnumerable<ReadChamadoDto> RecuperaChamados([FromQuery]
            int? chamadoId = null)
        {
            if (chamadoId == null)

            {
                return _mapper.Map<List<ReadChamadoDto>>(_context.Chamados.ToList());
            }
            return _mapper.Map<List<ReadChamadoDto>>(_context.Chamados.FromSqlRaw($"SELECT id, Titulo, Descricao, PessoaId from chamados WHERE chamados.PessoaId = {chamadoId}").ToList());
        }


        [HttpGet("{id}")]
        public IActionResult RecuperaChamadosPorId([FromQuery] int id)
        {
            Chamado chamado = _context.Chamados.FirstOrDefault(chamado => chamado.Id == id);
            if(chamado == null) 
            {
                ReadChamadoDto chamadoDto = _mapper.Map<ReadChamadoDto>(chamado); 
            }
            return NotFound();

        }

    }
}
