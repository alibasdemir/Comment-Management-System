using Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Index(nameof(FirstName))]  // 1.method: -index- for FirstName (2.method: -index- look dbcontext for with fluent API)
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public User()
        {
        }

        public User(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, string password)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
        }
    }
}
