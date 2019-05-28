using System.Linq;
using Plantopia.WebApi.Domains.Model;
using Plantopia.WebApi.Domains.Model.Person;

namespace Plantopia.WebApi.Domains.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepository : Repository<User>
    {
        private readonly PlantopiaDataContext context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(PlantopiaDataContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return context.Accounts.Count();
        }
    }
}