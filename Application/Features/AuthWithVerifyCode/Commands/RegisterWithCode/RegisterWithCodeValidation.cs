using FluentValidation;

namespace Application.Features.AuthWithVerifyCode.Commands.RegisterWithCode
{
    public class RegisterWithCodeValidation : AbstractValidator<RegisterWithCodeCommand>
    {
        public RegisterWithCodeValidation()
        {
            RuleFor(i => i.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(i => i.LastName).NotEmpty().MinimumLength(2);
            RuleFor(i => i.Email).NotEmpty().EmailAddress()
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Email address is not in a valid format.");
            RuleFor(i => i.Password).NotEmpty().MinimumLength(4);
        }
    }
}
