using Plantopia.WebApi.Domains.Model;
using Plantopia.WebApi.Domains.Model.Person;

namespace Plantopia.WebApi.Domains.Repositories
{
    /// <inheritdoc />
    public class AccountRepository : Repository<Account>
    {
        private readonly PlantopiaDataContext context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AccountRepository(PlantopiaDataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
