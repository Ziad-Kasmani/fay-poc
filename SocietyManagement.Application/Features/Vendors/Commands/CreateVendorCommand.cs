using MediatR;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Features.Vendors.Commands;

public record CreateVendorCommand(VendorDto Dto) : IRequest<VendorDto>;
