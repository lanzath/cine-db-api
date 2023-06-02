using AutoMapper;
using CineDb.Domain.Contracts;
using CineDb.Domain.Entities;
using MediatR;

namespace CineDb.Domain.Command.Commands.Movies.Create;

public sealed class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IMovieRepository _movieRepository;

    public CreateMovieCommandHandler(
        IMapper mapper,
        IMovieRepository movieRepository)
    {
        _mapper = mapper;
        _movieRepository = movieRepository;
    }

    public async Task<Unit> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = _mapper.Map<Movie>(request);

        await _movieRepository.AddAsync(movie);

        return Unit.Value;
    }
}