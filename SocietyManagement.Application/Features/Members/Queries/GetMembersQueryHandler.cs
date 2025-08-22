using MediatR;
using SocietyManagement.Application.DTOs;
using SocietyManagement.Application.Interfaces.Repositories;

namespace SocietyManagement.Application.Features.Members.Queries;

public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<MemberDto>>
{
    private readonly IUnitOfWork _uow;

    public GetMembersQueryHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<IEnumerable<MemberDto>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
    {
        var members = await _uow.Members.FindAsync(m => m.SocietyId == request.SocietyId);
        return members.Select(m => new MemberDto
        {
            Id = m.Id,
            FirstName = m.FirstName,
            LastName = m.LastName,
            Email = m.Email,
            MobileNumber = m.MobileNumber,
            Role = m.Role
        });
    }
}
