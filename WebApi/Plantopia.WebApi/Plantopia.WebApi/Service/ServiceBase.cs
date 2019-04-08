using Plantopia.WebApi.Data.Model;

namespace Plantopia.WebApi.Service
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