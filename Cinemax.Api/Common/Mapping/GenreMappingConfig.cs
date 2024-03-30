using Cinemax.Application.Genres.Commands.Create;
using Cinemax.Application.Genres.Commands.Delete;
using Cinemax.Application.Genres.Common;
using Cinemax.Application.Genres.Queries.Get;
using Cinemax.Contracts.Genres;
using Cinemax.Domain.Genre.ValueObjects;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class GenreMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<GenreResult, GenreResponse>()
            .Map(dest => dest.Id, src => src.Genre.Id.Value )
            .Map(dest => dest.Name, src => src.Genre.Name );
            
        config.NewConfig<CreateGenreRequest, CreateGenreCommand>();
        config.NewConfig<DeleteGenreRequest, DeleteGenreCommand>()
            .Map(dest => dest.GenreId, src => GenreId.Create(new(src.GenreId)));

        config.NewConfig<DeleteGenreRequest, DeleteGenreCommand>()
            .Map(dest => dest.GenreId, src => GenreId.Create(new(src.GenreId)));

        config.NewConfig<GetGenreRequest, GetGenreQuery>()
            .Map(dest => dest.GenreId, src => GenreId.Create(new(src.GenreId)));
    }
}