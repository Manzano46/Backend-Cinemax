using Cinemax.Application.Movies.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateMovieCommand(string Id,  JsonPatchDocument<Movie> patchDoc) : IRequest<MovieResult>;
