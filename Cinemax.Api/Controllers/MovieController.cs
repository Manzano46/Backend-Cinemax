using Cinemax.Application.Movies.Commands.Create;
using Cinemax.Application.Movies.Common;
using Cinemax.Application.Movies.Queries.Read;
using Cinemax.Contracts.Movies;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("movies")]

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


    /*
    // GET: api/movies/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetMovieQuery(id);

        MovieResult movieResult = await _mediator.Send(command);

        var response = new MovieResponse(movieResult.Movie.Id, movieResult.Movie.Name, movieResult.Movie.Description, movieResult.Movie.Duration, movieResult.Movie.Premiere, movieResult.Movie.IconURL, movieResult.Movie.TrailerURL);

        return Ok(response);
        var movie = await _mediator.Send(new GetMovieQuery { Id = id });
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    /*
    // PUT: api/movies/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateMovieCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE: api/movies/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteMovieCommand { Id = id });
        return NoContent();
    }
    */
}