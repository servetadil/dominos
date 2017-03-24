using Dominos.Core.Domain;
using Dominos.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos.Infrastructure.Service
{
    public class UserService : IUserService
    {

        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        } 
        public User Login(string email, string password)
        {
            // TODO: zaman kalırsa auth yapılacak.
            return _userRepository.Table.FirstOrDefault();
        }
    }

    public interface IUserService
    {
        User Login(string email, string password);
    }
}
