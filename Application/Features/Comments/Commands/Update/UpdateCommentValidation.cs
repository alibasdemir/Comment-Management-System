using FluentValidation;

namespace Application.Features.Comments.Commands.Update
{
    public class UpdateCommentValidation : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentValidation()
        {
            RuleFor(i => i.UserId).GreaterThan(0);
            RuleFor(i => i.AssignmentId).GreaterThan(0);
            RuleFor(i => i.Content).MinimumLength(1);
        }
    }
}
