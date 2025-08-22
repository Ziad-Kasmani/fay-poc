using FluentValidation;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Validators;

public class VerifyOtpDtoValidator : AbstractValidator<VerifyOtpDto>
{
    public VerifyOtpDtoValidator()
    {
        RuleFor(x => x.Target).NotEmpty();
        RuleFor(x => x.Code).Length(6);
    }
}
