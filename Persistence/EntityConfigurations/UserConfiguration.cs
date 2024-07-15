using Core.Security.Entities;
using Core.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            string password = "admin";
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            string password2 = "ali";
            byte[] passwordHash2, passwordSalt2;
            HashingHelper.CreatePasswordHash(password2, out passwordHash2, out passwordSalt2);

            string password3 = "string";
            byte[] passwordHash3, passwordSalt3;
            HashingHelper.CreatePasswordHash(password3, out passwordHash3, out passwordSalt3);

            User[] userSeeds =
            {
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    CreatedDate = new DateTime(1111, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                },
                new User
                {
                    Id = 2,
                    FirstName = "Ali",
                    LastName = "Ali",
                    Email = "ali",
                    PasswordSalt = passwordSalt2,
                    PasswordHash = passwordHash2,
                    CreatedDate = new DateTime(1112, 02, 02, 0, 0, 0, DateTimeKind.Utc),
                },
                new User
                {
                    Id = 3,
                    FirstName = "String",
                    LastName = "String",
                    Email = "string",
                    PasswordSalt = passwordSalt3,
                    PasswordHash = passwordHash3,
                    CreatedDate = new DateTime(1113, 03, 03, 0, 0, 0, DateTimeKind.Utc),
                },
            };
            builder.HasData(userSeeds);
        }
    }
}
