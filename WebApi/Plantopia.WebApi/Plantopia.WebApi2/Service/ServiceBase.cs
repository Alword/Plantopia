using Plantopia.WebApi2.Data.Model;

namespace Plantopia.WebApi2.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly PlantopiaDataContext Context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ServiceBase(PlantopiaDataContext context)
        {
            Context = context;
        }
    }
}