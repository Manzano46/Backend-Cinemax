using Cinemax.Application.RoomTypes.Common;
using Cinemax.Domain.RoomType.Entities;
using Cinemax.Domain.RoomType.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateRoomTypeCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<RoomTypeResult>;
