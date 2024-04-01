using Cinemax.Application.Movies.Commands.Create;
using Cinemax.Application.Movies.Commands.Delete;
using Cinemax.Application.Movies.Common;
using Cinemax.Application.Movies.Queries.Get;
using Cinemax.Contracts.Actors;
using Cinemax.Contracts.Countries;
using Cinemax.Contracts.Directors;
using Cinemax.Contracts.Genres;
using Cinemax.Contracts.Movies;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class MovieMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<MovieResult, MovieResponse>()
            .Map(dest => dest.Id, src => src.Movie.Id.Value )
            .Map(dest => dest.Name, src => src.Movie.Name )
            .Map(dest => dest.Description, src => src.Movie.Description )
            .Map(dest => dest.Duration, src => src.Movie.Duration)
            .Map(dest => dest.Premiere, src => src.Movie.Premiere )
            .Map(dest => dest.IconURL, src => src.Movie.IconURL)
            .Map(dest => dest.TrailerURL, src => src.Movie.TrailerURL)
            .Map(dest => dest.Summary, src => src.Movie.Summary)
            .Map(dest => dest.CoverURL, src => src.Movie.CoverURL)
            .Map(dest => dest.ImagenURL, src => src.Movie.ImagenURL)
            .Map(dest => dest.Actors, src => src.Movie.Actors)
            .Map(dest => dest.Countries, src => src.Movie.Countries)
            .Map(dest => dest.Directors, src => src.Movie.Directors)
            .Map(dest => dest.Genres, src => src.Movie.Genres);
            

        config.NewConfig<CreateMovieRequest, CreateMovieCommand>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Duration, src => src.Duration)
            .Map(dest => dest.Premiere, src => src.Premiere)
            .Map(dest => dest.IconURL, src => src.IconURL)
            .Map(dest => dest.TrailerURL, src => src.TrailerURL)
            .Map(dest => dest.Summary, src => src.Summary)
            .Map(dest => dest.CoverURL, src => src.CoverURL)
            .Map(dest => dest.ImagenURL, src => src.ImagenURL);

        config.NewConfig<DeleteMovieRequest, DeleteMovieCommand>()
            .Map(dest => dest.MovieId, src => MovieId.Create(new(src.Id)));

        config.NewConfig<GetMovieRequest, GetMovieQuery>()
            .Map(dest => dest.MovieId, src => MovieId.Create(new(src.Id)));

        config.NewConfig<Movie, MovieResponseCore>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Duration, src => src.Duration)
            .Map(dest => dest.Premiere, src => src.Premiere)
            .Map(dest => dest.IconURL, src => src.IconURL)
            .Map(dest => dest.TrailerURL, src => src.TrailerURL)
            .Map(dest => dest.Summary, src => src.Summary)
            .Map(dest => dest.CoverURL, src => src.CoverURL)
            .Map(dest => dest.ImagenURL, src => src.ImagenURL);
    }
}