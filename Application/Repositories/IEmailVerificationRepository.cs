using Core.Persistence;
using Core.Security.Entities;

namespace Application.Repositories
{
    public interface IEmailVerificationRepository : IAsyncRepository<EmailVerification>, IRepository<EmailVerification>
    {
    }
}
