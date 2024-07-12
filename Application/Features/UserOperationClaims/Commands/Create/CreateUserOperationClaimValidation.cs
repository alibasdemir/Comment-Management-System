using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimValidation : AbstractValidator<CreateUserOperationClaimCommand>
    {
        public CreateUserOperationClaimValidation()
        {
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.OperationClaimId).GreaterThan(0);
        }
    }
}
