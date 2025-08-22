using FluentValidation;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Validators;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.EmailOrMobile).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
