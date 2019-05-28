using System.Collections.Generic;
using System.Linq;
using Plantopia.WebApi2.Data.Model;
using Plantopia.WebApi2.Data.Model.Person;
using Plantopia.WebApi2.Data.Repositories;

namespace Plantopia.WebApi2.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : ServiceBase
    {
        private readonly UserRepository usersRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserService(PlantopiaDataContext context) : base(context)
        {
            usersRepository = new UserRepository(context);
        }

        public IEnumerable<User> GetUsers(string nickLike)
        {
            return usersRepository.Get(u => u.NickName.ToLower().Contains(nickLike.ToLower())).Take(50);
        }
    }
}