using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Countries.Common;
using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Countries.Commands.Create;
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CountryResult>
{
    private readonly ICountryRepository _countryRepository; 
    private readonly IMovieRepository _movieRepository; 

    public CreateCountryCommandHandler(ICountryRepository CountryRepository,IMovieRepository MovieRepository)
    {
        _countryRepository = CountryRepository; 
        _movieRepository = MovieRepository;   
    }
    public async Task<CountryResult> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_countryRepository.GetByName(command.Name) is not null){
            throw new Exception("Country with given name alredy exists");
        }

        Country country = Country.Create(
            command.Name,
            new List<Movie>()
        );

        _countryRepository.Add(country);

        return new CountryResult(country);
    }

}
