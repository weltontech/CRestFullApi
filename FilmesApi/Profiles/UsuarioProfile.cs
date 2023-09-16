using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class UsuarioProfile : Profile
{

    public UsuarioProfile() 
    {

        //fazendo um mappeamento de CreateUsuarioDto para Usuario 
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<UpdateUsuarioDto, Usuario>();
        CreateMap<Usuario, UpdateUsuarioDto>();

    }
    
}
