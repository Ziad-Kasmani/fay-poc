using MediatR;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Features.Auth.Commands;

public record RegisterSocietyCommand(RegisterSocietyDto Dto) : IRequest<Guid>;
