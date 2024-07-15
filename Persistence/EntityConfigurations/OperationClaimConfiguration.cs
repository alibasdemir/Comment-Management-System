using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            OperationClaim[] operationClaimSeeds =
            {
                new OperationClaim
                {
                    Id = 1,
                    Name = "Admin",
                },
                new OperationClaim
                {
                    Id = 2,
                    Name = "assignment.read",
                },
                new OperationClaim
                {
                    Id = 3,
                    Name = "assignment.write",
                },
                new OperationClaim
                {
                    Id = 4,
                    Name = "assignment.add",
                },
                new OperationClaim
                {
                    Id = 5,
                    Name = "assignment.update",
                },
                new OperationClaim
                {
                    Id = 6,
                    Name = "assignment.delete",
                },
                new OperationClaim
                {
                    Id = 7,
                    Name = "comment.read",
                },
                new OperationClaim
                {
                    Id = 8,
                    Name = "comment.write",
                },
                new OperationClaim
                {
                    Id = 9,
                    Name = "comment.add",
                },
                new OperationClaim
                {
                    Id = 10,
                    Name = "comment.update",
                },
                new OperationClaim
                {
                    Id = 11,
                    Name = "comment.delete",
                },
                new OperationClaim
                {
                    Id = 12,
                    Name = "user.read",
                },
                new OperationClaim
                {
                    Id = 13,
                    Name = "user.write",
                },
                new OperationClaim
                {
                    Id = 14,
                    Name = "user.add",
                },
                new OperationClaim
                {
                    Id = 15,
                    Name = "user.update",
                },
                new OperationClaim
                {
                    Id = 16,
                    Name = "user.delete",
                },
                new OperationClaim
                {
                    Id = 17,
                    Name = "operationclaim.read",
                },
                new OperationClaim
                {
                    Id = 18,
                    Name = "operationclaim.write",
                },
                new OperationClaim
                {
                    Id = 19,
                    Name = "operationclaim.add",
                },
                new OperationClaim
                {
                    Id = 20,
                    Name = "operationclaim.update",
                },
                new OperationClaim
                {
                    Id = 21,
                    Name = "operationclaim.delete",
                },
                new OperationClaim
                {
                    Id = 22,
                    Name = "useroperationclaim.read",
                },
                new OperationClaim
                {
                    Id = 23,
                    Name = "useroperationclaim.write",
                },
                new OperationClaim
                {
                    Id = 24,
                    Name = "useroperationclaim.add",
                },
                new OperationClaim
                {
                    Id = 25,
                    Name = "useroperationclaim.update",
                },
                new OperationClaim
                {
                    Id = 26,
                    Name = "useroperationclaim.delete",
                },
            };
            builder.HasData(operationClaimSeeds);
        }
    }
}
