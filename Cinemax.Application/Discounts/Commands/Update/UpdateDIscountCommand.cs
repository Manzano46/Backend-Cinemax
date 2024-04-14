using Cinemax.Application.Discounts.Common;
using Cinemax.Domain.Discount.Entities;
using Cinemax.Domain.Discount.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateDiscountCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<DiscountResult>;
