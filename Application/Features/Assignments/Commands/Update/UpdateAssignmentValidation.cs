using FluentValidation;

namespace Application.Features.Assignments.Commands.Update
{
    public class UpdateAssignmentValidation : AbstractValidator<UpdateAssignmentCommand>
    {
        public UpdateAssignmentValidation()
        {
            RuleFor(i => i.Title).NotEmpty().MinimumLength(1);
            RuleFor(i => i.Description).NotEmpty().MinimumLength(1);
        }
    }
}
