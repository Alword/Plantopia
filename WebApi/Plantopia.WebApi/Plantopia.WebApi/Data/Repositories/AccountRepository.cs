using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InWords.Data;
using Plantopia.WebApi.Data.Model;
using Plantopia.WebApi.Data.Model.Person;

namespace Plantopia.WebApi.Data.Repositories
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
