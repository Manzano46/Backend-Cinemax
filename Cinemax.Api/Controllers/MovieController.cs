using Cinemax.Application.Movies.Commands.Create;
using Cinemax.Application.Movies.Commands.Delete;
using Cinemax.Application.Movies.Common;
using Cinemax.Application.Movies.Queries.Get;
using Cinemax.Application.Movies.Queries.Read;
using Cinemax.Contracts.Movies;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("movies")]
//[Authorize(Roles = "ADMIN")] 

public class MovieController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MovieController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/movies
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateMovieRequest createMovieRequest)
    {
        var command = _mapper.Map<CreateMovieCommand>(createMovieRequest);

        MovieResult movieResult = await _mediator.Send(command);

        var response = _mapper.Map<MovieResponse>(movieResult);
        return Ok(response);
    }

    // GET: api/movies
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadMoviesQuery();

        IEnumerable<MovieResult> movieResults = await _mediator.Send(command);

        IEnumerable<MovieResponse> responses = movieResults.Select(movieResult => _mapper.Map<MovieResponse>(movieResult));
        
        return Ok(responses);
    }

    // GET: api/movies/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        GetMovieRequest getMovieRequest = new(id);
        var query = _mapper.Map<GetMovieQuery>(getMovieRequest);

        MovieResult MovieResult = await _mediator.Send(query);

        var response = _mapper.Map<MovieResponse>(MovieResult);

        return Ok(response);
    }

    // GET: api/movies/name/{name}
    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        GetMovieByNameRequest getMovieRequest = new(name);
        var query = _mapper.Map<GetMovieByNameQuery>(getMovieRequest);

        MovieResult MovieResult = await _mediator.Send(query);

        var response = _mapper.Map<MovieResponse>(MovieResult);

        return Ok(response);
    }

    // DELETE: api/movies/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        DeleteMovieRequest deleteMovieRequest = new(id);
        var command = _mapper.Map<DeleteMovieCommand>(deleteMovieRequest);

        MovieResult MovieResult = await _mediator.Send(command);

        var response = _mapper.Map<MovieResponse>(MovieResult);

        return Ok(response);
    }

    // PATCH: api/actors/{id}
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<Movie> patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new UpdateMovieCommand(id, patchDoc);
        var actorResult = await _mediator.Send(command);

        return Ok(actorResult);
    }
}