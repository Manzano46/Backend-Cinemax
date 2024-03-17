using Cinemax.Application.Authentication.Commands.Register;
using Cinemax.Application.Authentication.Common;
using Cinemax.Application.Authentication.Queries.Login;
using Cinemax.Application.Movies.Commands.Create;
using Cinemax.Application.Movies.Common;
using Cinemax.Contracts.Authentication;
using Cinemax.Contracts.Movies;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class MovieMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<MovieResult, MovieResponse>()
            .Map(dest => dest, src => src.Movie);

        config.NewConfig<CreateMovieRequest, CreateMovieCommand>();
    }
}