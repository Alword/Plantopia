using System.Collections.Generic;
using System.Linq;
using Plantopia.WebApi.Domains.Model;
using Plantopia.WebApi.Domains.Model.Person;
using Plantopia.WebApi.Domains.Repositories;

namespace Plantopia.WebApi.Service
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