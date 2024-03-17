
using Cinemax.Application.Movies.Commands.Create;
using Cinemax.Application.Movies.Common;
using Cinemax.Application.Movies.Queries.Read;
using Cinemax.Contracts.Movies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("movies")]
public class MovieController : ControllerBase{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator) => _mediator = mediator;

    // POST: api/movies
    [HttpPost]
    public async Task<IActionResult> Create(CreateMovieRequest createMovieRequest)
    {
        var command = new CreateMovieCommand(createMovieRequest.Name, createMovieRequest.Description, createMovieRequest.Duration, createMovieRequest.Premiere, createMovieRequest.IconURL,
        createMovieRequest.TrailerURL
        );

        MovieResult movieResult = await _mediator.Send(command);

        var response = new MovieResponse(movieResult.Movie.Id.Value, movieResult.Movie.Name, movieResult.Movie.Description, movieResult.Movie.Duration, movieResult.Movie.Premiere, movieResult.Movie.IconURL, movieResult.Movie.TrailerURL);

        return Ok(response);
    }

    // GET: api/movies
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadMoviesQuery();

        IEnumerable<MovieResult> movieResults = await _mediator.Send(command);

        IEnumerable<MovieResponse> responses = movieResults.Select(movieResult => new MovieResponse
            (
                movieResult.Movie.Id.Value,
                movieResult.Movie.Name,
                movieResult.Movie.Description,
                movieResult.Movie.Duration,
                movieResult.Movie.Premiere,
                movieResult.Movie.IconURL,
                movieResult.Movie.TrailerURL
            )
        );
        
    
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