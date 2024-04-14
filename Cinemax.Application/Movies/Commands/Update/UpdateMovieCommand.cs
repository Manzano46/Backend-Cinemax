using Cinemax.Application.Movies.Common;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateMovieCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<MovieResult>;
