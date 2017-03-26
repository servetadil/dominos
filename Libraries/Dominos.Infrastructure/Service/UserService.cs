using Dominos.Core.Base;
using Dominos.Core.Domain;
using Dominos.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos.Infrastructure.Service
{
    public class UserService : BaseService<User>, IUserService
    {

        public UserService(IRepository<User> userRepository) : base(userRepository)
        {
        }
        public User Login(string email, string password)
        {
            return BaseRepository.Table.FirstOrDefault(p => p.Email == email && p.Password == password);
        }
    }

    public interface IUserService : IBaseService<User>
    {
        User Login(string email, string password);
    }
}
