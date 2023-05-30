using CineDb.Domain.Command.Movies.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineDb.Api.Controllers;

[Route("api/v1/movies")]
public sealed class MovieController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateMovieCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }
}