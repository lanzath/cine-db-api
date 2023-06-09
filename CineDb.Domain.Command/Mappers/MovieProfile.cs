using AutoMapper;
using CineDb.Domain.Entities;
using CineDb.Domain.Command.Commands.Movies.Create;
using CineDb.Domain.Command.Movies.Update;

namespace CineDb.Domain.Command.Mappers;

public sealed class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieCommand, Movie>();
        CreateMap<CreateMovieCommandDirector, Director>();
        CreateMap<UpdateMovieCommand, Movie>()
            .ForMember(dest => dest.DirectorId, opt => opt.Ignore());
        CreateMap<UpdateMovieCommandDirector, Director>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}