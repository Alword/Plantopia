using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plantopia.Auth.Extensions;
using Plantopia.WebApi.Data.Model;
using Plantopia.WebApi.Data.Model.Person;
using Plantopia.WebApi.Data.Repositories;
using Plantopia.WebApi.Enums;
using Plantopia.WebApi.Service;

namespace Plantopia.WebApi.Controllers.v1
{
    /// <inheritdoc />
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AccountRepository accountRepository;
        private readonly UserService userService;
        private readonly UserRepository usersRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UsersController(PlantopiaDataContext context)
        {
            PlantopiaDataContext dataContext = context;
            userService = new UserService(dataContext);

            // TODO: remove
            usersRepository = new UserRepository(dataContext);
            accountRepository = new AccountRepository(dataContext);
        }

        /// <summary>
        /// GET: api/Users/nickname
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        [HttpGet("find/{nick}")]
        public IEnumerable<User> GetUsers(string nick)
        {
            return userService.GetUsers(nick);
        }

        /// <summary>
        /// GET: api/Users/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserId([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            User user = await usersRepository.FindById(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// api/Users/
        /// </summary>
        /// <returns>authorized user data</returns>
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            // ReSharper disable once TooManyChainedReferences
            int userId = User.Claims.GetUserId();

            User user = await usersRepository.FindById(userId);

            if (user == null) return NotFound();

            return Ok(user);
        }


        /// <summary>
        /// PUT: api/Users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutUser([FromBody] User user)
        {
            // ReSharper disable once TooManyChainedReferences
            int authorizedId = User.Claims.GetUserId();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            // check is user exist
            User authorizedUser = await usersRepository.FindById(authorizedId);

            if (authorizedUser == null) return NotFound("User doesn't exist. Send this problem to admin");

            // UpdateNickname
            if (user.NickName != null) authorizedUser.NickName = user.NickName;

            // Update avatar
            if (user.AvatarPath != null) authorizedUser.AvatarPath = user.AvatarPath;

            await usersRepository.Update(authorizedUser);

            return NoContent();
        }

        /// <summary>
        /// DELETE: api/Users/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(RoleType.Admin))]
        public async Task<IActionResult> AdminDeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Account account = await accountRepository.FindById(id);
            if (account == null) return NotFound();

            await accountRepository.Remove(account);
            return Ok(account);
        }
    }
}