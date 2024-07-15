using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            UserOperationClaim[] userOperationClaimSeeds =
            {
                new UserOperationClaim
                {
                    Id = 1,
                    UserId = 1,
                    OperationClaimId = 1,
                },
                new UserOperationClaim
                {
                    Id = 2,
                    UserId = 2,
                    OperationClaimId = 1,
                },
                new UserOperationClaim
                {
                    Id = 3,
                    UserId = 3,
                    OperationClaimId = 7,
                },
                new UserOperationClaim
                {
                    Id = 4,
                    UserId = 3,
                    OperationClaimId = 8,
                },
                new UserOperationClaim
                {
                    Id = 5,
                    UserId = 3,
                    OperationClaimId = 9,
                },
                new UserOperationClaim
                {
                    Id = 6,
                    UserId = 3,
                    OperationClaimId = 10,
                },
                new UserOperationClaim
                {
                    Id = 7,
                    UserId = 3,
                    OperationClaimId = 11,
                },
                new UserOperationClaim
                {
                    Id = 8,
                    UserId = 3,
                    OperationClaimId = 2,
                },
                new UserOperationClaim
                {
                    Id = 9,
                    UserId = 3,
                    OperationClaimId = 12,
                },
            };
            builder.HasData(userOperationClaimSeeds);
        }
    }
}
