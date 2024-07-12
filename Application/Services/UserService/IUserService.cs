using Core.Security.Entities;

namespace Application.Services.UserService
{
    public interface IUserService
    {
        public Task<User> GetById (int id);
        public Task<User> GetByEmail(string email);
        public Task<User> Update(User user);
    }
}
