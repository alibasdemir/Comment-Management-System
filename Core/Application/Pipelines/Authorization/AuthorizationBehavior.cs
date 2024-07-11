using Core.Application.Pipelines.Authorization.Constants;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Core.Application.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new Exception("You are not logged in!"); // refactor
            }

            // If no roles are required for the command or query, proceed to the next behavior
            if (request.Roles.Length == 0)
            {
                return await next();
            }

            List<string>? userRoleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            if (userRoleClaims == null)
                throw new Exception("You are not authenticated."); // refactor

            bool isNotMatchedAUserRoleClaimWithRequestRoles = userRoleClaims
                .FirstOrDefault(
                    userRoleClaim => userRoleClaim == GeneralOperationClaims.Admin || request.Roles.Any(role => role == userRoleClaim)
                )
                .IsNullOrEmpty();
            if (isNotMatchedAUserRoleClaimWithRequestRoles)
                throw new Exception("You are not authorized."); // refactor

            TResponse response = await next();
            return response;
        }
    }
}
