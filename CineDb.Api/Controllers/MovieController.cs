using CineDb.Domain.Command.Commands.Movies.Delete;
using CineDb.Domain.Command.Commands.Movies.Create;
using CineDb.Domain.Command.Movies.Update;
using CineDb.Domain.Query.Queries.Movies.GetById;
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
        // TODO: Refactor to a middleware
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.ToArray()[1].Errors);


        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetMovieByIdQuery(id));

        if (response is null) return NotFound();

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateMovieCommand command)
    {
        // TODO: Refactor to a middleware
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState.Values.ToArray()[1].Errors);

        command.Id = id;
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] int id)
    {
        await _mediator.Send(new DeleteMovieCommand(id));

        return NoContent();
    }
}