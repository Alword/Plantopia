using System.Linq;
using InWords.Data;
using Plantopia.WebApi.Data.Model;
using Plantopia.WebApi.Data.Model.Person;

namespace Plantopia.WebApi.Data.Repositories
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