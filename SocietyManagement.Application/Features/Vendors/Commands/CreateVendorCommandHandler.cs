using MediatR;
using SocietyManagement.Application.DTOs;
using SocietyManagement.Application.Interfaces.Repositories;
using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Application.Features.Vendors.Commands;

public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, VendorDto>
{
    private readonly IUnitOfWork _uow;

    public CreateVendorCommandHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<VendorDto> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var vendor = new Vendor
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            ServiceType = dto.ServiceType,
            ContactPerson = dto.ContactPerson,
            MobileNumber = dto.MobileNumber,
            SocietyId = dto.SocietyId
        };
        await _uow.Vendors.AddAsync(vendor);
        await _uow.SaveChangesAsync();

        dto.Id = vendor.Id;
        return dto;
    }
}
