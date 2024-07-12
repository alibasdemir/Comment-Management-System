using FluentValidation;

namespace Application.Features.OperationClaims.Commands.Update
{
    public class UpdateOperationClaimValidation : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimValidation()
        {
            RuleFor(i => i.Name).NotEmpty().MinimumLength(2);
        }
    }
}
