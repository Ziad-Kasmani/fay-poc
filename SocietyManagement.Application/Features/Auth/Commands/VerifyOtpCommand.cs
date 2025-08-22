using MediatR;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Features.Auth.Commands;

public record VerifyOtpCommand(VerifyOtpDto Dto) : IRequest<bool>;
