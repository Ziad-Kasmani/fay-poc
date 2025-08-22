using FluentValidation;
using SocietyManagement.Application.DTOs;

namespace SocietyManagement.Application.Validators;

public class VendorDtoValidator : AbstractValidator<VendorDto>
{
    public VendorDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.MobileNumber).NotEmpty();
    }
}
