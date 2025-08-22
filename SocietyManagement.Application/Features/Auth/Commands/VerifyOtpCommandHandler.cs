using MediatR;
using SocietyManagement.Application.Interfaces.Services;

namespace SocietyManagement.Application.Features.Auth.Commands;

public class VerifyOtpCommandHandler : IRequestHandler<VerifyOtpCommand, bool>
{
    private readonly IOtpService _otpService;

    public VerifyOtpCommandHandler(IOtpService otpService) => _otpService = otpService;

    public Task<bool> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        => _otpService.VerifyOtpAsync(request.Dto.Target, request.Dto.Code);
}
