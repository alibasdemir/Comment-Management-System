using Core.Persistence;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {
        }

        public User(int id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }
    }
}
