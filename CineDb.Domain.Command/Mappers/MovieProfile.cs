using AutoMapper;
using CineDb.Domain.Entities;
using CineDb.Domain.Command.Movies.Create;
using CineDb.Domain.Command.Movies.Update;

namespace CineDb.Domain.Command.Mappers;

public sealed class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieCommand, Movie>();
        CreateMap<CreateMovieCommandDirector, Director>();
        CreateMap<UpdateMovieCommand, Movie>();
        CreateMap<UpdateMovieCommandDirector, Director>();
    }
}