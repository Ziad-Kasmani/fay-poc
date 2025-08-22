using FluentValidation;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Validators;

public class RegisterMemberDtoValidator : AbstractValidator<RegisterMemberDto>
{
    public RegisterMemberDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).MinimumLength(6);
    }
}
