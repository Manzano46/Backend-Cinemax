using Cinemax.Application.Genres.Commands.Create;
using Cinemax.Application.Genres.Commands.Delete;
using Cinemax.Application.Genres.Common;
using Cinemax.Application.Genres.Queries.ReadGenres;
using Cinemax.Contracts.Genres;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("genres")]

public class GenreController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GenreController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/genres
    [HttpPost]
   
    public async Task<IActionResult> Create(CreateGenreRequest createGenreRequest)
    {
        var command = _mapper.Map<CreateGenreCommand>(createGenreRequest);

        GenreResult GenreResult = await _mediator.Send(command);

        var response = _mapper.Map<GenreResponse>(GenreResult);
        return Ok(response);
    }

    // GET: api/genres
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadGenresQuery();

        IEnumerable<GenreResult> GenreResults = await _mediator.Send(command);

        IEnumerable<GenreResponse> responses = GenreResults.Select(GenreResult => _mapper.Map<GenreResponse>(GenreResult));
        
        return Ok(responses);
    }

    // DELETE: api/genres/{name}
    [HttpDelete("{name}")]
    public async Task<IActionResult> Delete(string name)
    {
        var command = new DeleteGenreCommand(name);

        GenreResult genreResult = await _mediator.Send(command);

        var response = _mapper.Map<GenreResponse>(genreResult);

        return Ok(response);
    }

}