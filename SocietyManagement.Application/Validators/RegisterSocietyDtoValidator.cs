using FluentValidation;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Validators;

public class RegisterSocietyDtoValidator : AbstractValidator<RegisterSocietyDto>
{
    public RegisterSocietyDtoValidator()
    {
        RuleFor(x => x.SocietyName).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.MobileNumber).NotEmpty();
        RuleFor(x => x.Password).MinimumLength(6);
    }
}
