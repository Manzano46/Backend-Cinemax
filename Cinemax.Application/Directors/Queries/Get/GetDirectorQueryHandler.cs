using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Directors.Common;
using MediatR;

namespace Cinemax.Application.Directors.Queries.Get;
public class GetDirectorQueryHandler : IRequestHandler<GetDirectorQuery, DirectorResult>
{
    private readonly IDirectorRepository _DirectorRepository;

    public GetDirectorQueryHandler(IDirectorRepository DirectorRepository)
    {
        _DirectorRepository = DirectorRepository;
    }
    public async Task<DirectorResult> Handle(GetDirectorQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_DirectorRepository.GetById(command.DirectorId)!);
    }
}
