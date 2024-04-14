using Cinemax.Application.Rooms.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateRoomCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<RoomResult>;
