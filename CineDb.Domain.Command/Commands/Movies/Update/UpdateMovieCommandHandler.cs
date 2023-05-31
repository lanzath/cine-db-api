using AutoMapper;
using CineDb.Domain.Contracts;
using MediatR;

namespace CineDb.Domain.Command.Movies.Update;

public sealed class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IMovieRepository _movieRepository;

    public UpdateMovieCommandHandler(
        IMapper mapper,
        IMovieRepository movieRepository)
    {
        _mapper = mapper;
        _movieRepository = movieRepository;
    }

    public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(request.Id);

        _mapper.Map(request, movie);

        await _movieRepository.UpdateAsync(movie);

        return Unit.Value;
    }
}