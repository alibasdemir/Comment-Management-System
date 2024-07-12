using FluentValidation;

namespace Application.Features.OperationClaims.Commands.Update
{
    public class UpdateOperationClaimValidation : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimValidation()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        }
    }
}
