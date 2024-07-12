using FluentValidation;

namespace Application.Features.OperationClaims.Commands.Create
{
    public class CreateOperationClaimValidation : AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimValidation()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        }
    }
}
