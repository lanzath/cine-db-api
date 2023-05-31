using CineDb.Domain.Entities;
using MediatR;

namespace CineDb.Domain.Query.Queries.Movies.GetById;

public sealed class GetMovieByIdQuery : IRequest<Movie>
{
    public int Id { get; set; }

    public GetMovieByIdQuery(int id) => Id = id;
}