using Cinemax.Application.Genres.Commands.Create;
using Cinemax.Application.Genres.Common;
using Cinemax.Contracts.Genres;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class GenreMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<GenreResult, GenreResponse>()
            .Map(dest => dest.Id, src => src.Genre.Id.Value )
            .Map(dest => dest.Name, src => src.Genre.Name );
            
        config.NewConfig<CreateGenreRequest, CreateGenreCommand>();
    }
}