using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class PessoaProfile :Profile
    {
        public PessoaProfile()
        {
            CreateMap<CreatePessoaDto, Pessoa>();
            CreateMap<Pessoa, ReadPessoaDto>()
           .ForMember(pessoaDto => pessoaDto.Endereco,
                opt => opt.MapFrom(pessoa => pessoa.Endereco));
            CreateMap<UpdatePessoaDto, Pessoa>();
            CreateMap<Pessoa, UpdatePessoaDto>();
        }
    }
}
