using Cinemax.Application.Genres.Common;
using Cinemax.Domain.Genre.Entities;
using Cinemax.Domain.Genre.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateGenreCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<GenreResult>;
