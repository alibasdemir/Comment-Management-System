using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimValidation : AbstractValidator<CreateUserOperationClaimCommand>
    {
        public CreateUserOperationClaimValidation()
        {
            RuleFor(i => i.UserId).GreaterThan(0);
            RuleFor(i => i.OperationClaimId).GreaterThan(0);
        }
    }
}
