using MediatR;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Features.Auth.Commands;

public record LoginCommand(LoginDto Dto) : IRequest<string>;
