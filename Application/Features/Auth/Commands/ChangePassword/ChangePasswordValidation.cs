using FluentValidation;

namespace Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordValidation : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidation()
        {
            RuleFor(i => i.Password).NotEmpty().MinimumLength(4);
        }
    }
}
