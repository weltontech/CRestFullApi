using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class ChamadoProfile : Profile
    {
        public ChamadoProfile()
        {
            CreateMap<CreateChamadoDto, Chamado>();
            CreateMap<Chamado, ReadChamadoDto>();
           // CreateMap<UpdateChamadoDto, Cinema>();

        }
    }
}
