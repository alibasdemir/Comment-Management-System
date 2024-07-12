using FluentValidation;

namespace Application.Features.Comments.Commands.Create
{
    public class CreateCommentValidation : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidation()
        {
            RuleFor(i => i.UserId).GreaterThan(0);
            RuleFor(i => i.AssignmentId).GreaterThan(0);
            RuleFor(i => i.Content).MinimumLength(1);
        }
    }
}
