using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

//Extende de Profile 
public class FilmeProfile : Profile
{

    public FilmeProfile()
    {
        //fazendo um mappeamento de CreateFilmeDto para Filme 
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
    }
}
