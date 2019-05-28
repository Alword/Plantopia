using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plantopia.WebApi.Data.Model;
using Plantopia.WebApi.Data.Repositories;

namespace Plantopia.WebApi.Controllers.v1
{
    /// <inheritdoc />
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("v{version:apiVersion}/[controller]")]
    // ReSharper disable once HollowTypeName
    public class ValuesController : ControllerBase
    {
        private readonly UserRepository userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ValuesController(PlantopiaDataContext context)
        {
            userRepository = new UserRepository(context);
        }

        /// <summary>
        ///     This is to get requested Api version
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("version")]
        public ActionResult GetVersion()
        {
            return Ok(HttpContext.GetRequestedApiVersion());
        }

        // GET api/values
        //IEnumerable<string>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int> Get()
        {
            return userRepository.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("getLogin")]
        public IActionResult GetLogin()
        {
            return Ok($"login: {User.Identity.Name}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("getRole")]
        public IActionResult GetRole()
        {
            return Ok("Role: Admin");
        }
    }
}