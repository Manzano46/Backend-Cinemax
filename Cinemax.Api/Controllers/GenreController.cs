using Cinemax.Application.Genres.Commands.Create;
using Cinemax.Application.Genres.Commands.Delete;
using Cinemax.Application.Genres.Common;
using Cinemax.Application.Genres.Queries.Get;
using Cinemax.Application.Genres.Queries.Read;
using Cinemax.Contracts.Genres;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("genres")]
//[Authorize(Roles = "ADMIN")] 

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

    // DELETE: api/genres/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        DeleteGenreRequest deleteGenreRequest = new(id);
        var command = _mapper.Map<DeleteGenreCommand>(deleteGenreRequest);

        GenreResult genreResult = await _mediator.Send(command);

        var response = _mapper.Map<GenreResponse>(genreResult);

        return Ok(response);
    }

    // GET: api/genres/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(GetGenreRequest getGenreRequest)
    {
        var query = _mapper.Map<GetGenreQuery>(getGenreRequest);

        GenreResult GenreResult = await _mediator.Send(query);

        var response = _mapper.Map<GenreResponse>(GenreResult);

        return Ok(response);
    }

    // PATCH: api/actors/{id}
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new UpdateGenreCommand(id, patchDoc);
        var actorResult = await _mediator.Send(command);

        return Ok(actorResult);
    }
}