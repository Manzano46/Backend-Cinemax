using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Directors.Common;
using Cinemax.Application.Directors.Queries.Read;
using MediatR;

namespace Cinemax.Application.Directors.Query.Read;
public class ReadDirectorsQueryHandler : IRequestHandler<ReadDirectorsQuery, IEnumerable<DirectorResult>>
{
    private readonly IDirectorRepository _directorRepository; 

    public ReadDirectorsQueryHandler(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;    
    }
    public async Task<IEnumerable<DirectorResult>> Handle(ReadDirectorsQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _directorRepository.GetAllDirectors().Select(x => new DirectorResult(x));
    }
}
