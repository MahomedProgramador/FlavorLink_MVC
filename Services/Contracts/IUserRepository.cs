using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserRepository
    {
        User Login(string username, string password);
        User Register(string username, string password);
        bool UserExists(string username);
    }
}
