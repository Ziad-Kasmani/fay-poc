using MediatR;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Features.Vendors.Queries;

public record GetVendorsQuery(Guid SocietyId) : IRequest<IEnumerable<VendorDto>>;
