using MediatR;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Features.Members.Commands;

public record RegisterMemberCommand(RegisterMemberDto Dto) : IRequest<MemberDto>;
