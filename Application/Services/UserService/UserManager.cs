﻿using Application.Repositories;
using Core.Security.Entities;

namespace Application.Services.UserService
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByEmail(string email)
        {
            User? user = await _userRepository.GetAsync(i => i.Email == email);
            return user;
        }

        public async Task<User> GetById(int id)
        {
            User? user = await _userRepository.GetAsync(i => i.Id == id);
            return user;
        }

        public async Task<User> Update(User user)
        {
            await _userRepository.UpdateAsync(user);
            return user;
        }
    }
}
