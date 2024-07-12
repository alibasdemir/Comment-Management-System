using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.Update
{
    public class UpdateUserOperationClaimValidation : AbstractValidator<UpdateUserOperationClaimCommand>
    {
        public UpdateUserOperationClaimValidation()
        {
            RuleFor(i => i.UserId).GreaterThan(0);
            RuleFor(i => i.OperationClaimId).GreaterThan(0);
        }
    }
}
