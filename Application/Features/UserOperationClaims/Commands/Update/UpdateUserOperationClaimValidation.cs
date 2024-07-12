using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.Update
{
    public class UpdateUserOperationClaimValidation : AbstractValidator<UpdateUserOperationClaimCommand>
    {
        public UpdateUserOperationClaimValidation()
        {
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.OperationClaimId).GreaterThan(0);
        }
    }
}
