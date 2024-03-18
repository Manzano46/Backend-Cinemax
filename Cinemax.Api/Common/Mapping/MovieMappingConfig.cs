using Cinemax.Application.Movies.Commands.Create;
using Cinemax.Application.Movies.Common;
using Cinemax.Contracts.Movies;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class MovieMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<MovieResult, MovieResponse>()
            .Map(dest => dest, src => src.Movie)
            .Map(dest => dest.IconURL, src => src.Movie.IconURL)
            .Map(dest => dest.TrailerURL, src => src.Movie.TrailerURL);
            

        config.NewConfig<CreateMovieRequest, CreateMovieCommand>()
        .Map(dest => dest.Name, src => src.Name)
        .Map(dest => dest.Description, src => src.Description)
        .Map(dest => dest.Duration, src => src.Duration)
        .Map(dest => dest.Premiere, src => src.Premiere)
        .Map(dest => dest.IconURL, src => src.IconURL)
        .Map(dest => dest.TrailerURL, src => src.TrailerURL);
    }
}