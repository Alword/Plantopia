using Plantopia.WebApi2.Data.Model;
using Plantopia.WebApi2.Data.Model.Person;

namespace Plantopia.WebApi2.Data.Repositories
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
