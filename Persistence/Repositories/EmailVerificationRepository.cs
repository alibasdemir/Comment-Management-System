using Application.Repositories;
using Core.Persistence;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class EmailVerificationRepository : EfRepositoryBase<EmailVerification, BaseDbContext>, IEmailVerificationRepository
    {
        public EmailVerificationRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
