using FluentValidation;

namespace Application.Features.Assignments.Commands.Create
{
    public class UpdateAssignmentValidation : AbstractValidator<CreateAssignmentCommand>
    {
        public UpdateAssignmentValidation()
        {
            RuleFor(i => i.Title).NotEmpty().MinimumLength(1);
            RuleFor(i => i.Description).NotEmpty().MinimumLength(1);
        }
    }
}
