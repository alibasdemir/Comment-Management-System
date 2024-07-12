using Application.Features.Comments.Constants;
using Application.Repositories;
using Application.Services.AssignmentService;
using Application.Services.UserService;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Comments.Rules
{
    public class CommentBusinessRules : BaseBusinessRules
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserService _userService;
        private readonly IAssignmentService _assignmentService;

        public CommentBusinessRules(ICommentRepository commentRepository, IUserService userService, IAssignmentService assignmentService)
        {
            _commentRepository = commentRepository;
            _userService = userService;
            _assignmentService = assignmentService;
        }

        public async Task CommentIdShouldExistWhenSelected(int id)
        {
            Comment? result = await _commentRepository.GetAsync(predicate: i => i.Id == id, enableTracking: false);
            if (result == null)
            {
                throw new BusinessException(CommentMessages.CommentNotExists);
            }
        }

        public async Task UserIdShouldExist(int id)
        {
            User user = await _userService.GetById(id);
            if (user == null)
            {
                throw new BusinessException(CommentMessages.UserIdShouldExist);
            }
        }

        public async Task AssignmentIdShouldExist(int id)
        {
            Assignment assignment = await _assignmentService.GetById(id);
            if (assignment == null)
            {
                throw new BusinessException(CommentMessages.AssignmentIdShouldExist);
            }
        }
    }
}
