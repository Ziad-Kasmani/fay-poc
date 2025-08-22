using MediatR;
using SocietyManagement.Application.DTOs;
using SocietyManagement.Application.Interfaces.Repositories;

namespace SocietyManagement.Application.Features.Vendors.Queries;

public class GetVendorsQueryHandler : IRequestHandler<GetVendorsQuery, IEnumerable<VendorDto>>
{
    private readonly IUnitOfWork _uow;

    public GetVendorsQueryHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<IEnumerable<VendorDto>> Handle(GetVendorsQuery request, CancellationToken cancellationToken)
    {
        var vendors = await _uow.Vendors.GetBySocietyAsync(request.SocietyId);
        return vendors.Select(v => new VendorDto
        {
            Id = v.Id,
            Name = v.Name,
            ServiceType = v.ServiceType,
            ContactPerson = v.ContactPerson,
            MobileNumber = v.MobileNumber,
            SocietyId = v.SocietyId
        });
    }
}
