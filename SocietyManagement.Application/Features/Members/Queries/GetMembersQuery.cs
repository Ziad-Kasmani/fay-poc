using MediatR;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Features.Members.Queries;

public record GetMembersQuery(Guid SocietyId) : IRequest<IEnumerable<MemberDto>>;
