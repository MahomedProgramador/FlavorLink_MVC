using Domain.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Login(string username, string password)
        {
            return _userRepository.Login(username, password);
        }

        public User Register(string username, string password)
        {
            return _userRepository.Register(username, password);
        }
        public bool UserExists(string username)
        {
            return _userRepository.UserExists(username);
        }
    }
}
