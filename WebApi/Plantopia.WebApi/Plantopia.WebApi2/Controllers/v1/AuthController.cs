using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plantopia.Service.Auth.Models;
using Plantopia.WebApi2.Data.Model;
using Plantopia.WebApi2.Data.Repositories;
using Plantopia.WebApi2.Providers;

namespace Plantopia.WebApi2.Controllers.v1
{
    // ReSharper disable once HollowTypeName
    /// <inheritdoc />
    /// <summary>
    /// The controller is responsible for user registration and authorization
    /// </summary>
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AccountRepository accountRepository;

        private readonly AccountIdentityProvider accountIdentityProvider;

        private readonly ILogger<AuthController> logger;

        /// <summary>
        /// Base ctor, injected context and logger
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public AuthController(PlantopiaDataContext context, ILogger<AuthController> logger)
        {
            this.logger = logger;
            accountRepository = new AccountRepository(context);
            accountIdentityProvider = new AccountIdentityProvider(accountRepository, logger);
        }

        /// <summary>
        ///     From Request Basic Authorization
        /// </summary>
        /// <returns></returns>
        [Route("token")]
        [HttpPost]
        public IActionResult Token([FromBody] BasicAuthClaims user)
        {
            try
            {
                TokenResponse tokenResponse = accountIdentityProvider.GetIdentity(user);
                return Ok(tokenResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create the account
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("registration")]
        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] BasicAuthClaims user)
        {
            //check if account exist;
            if (accountRepository.ExistAny(a => a.Email == user.Email))
                return BadRequest($"User already exists {user.Email}");

            //Create token
            TokenResponse response = await CreateUserAccount(user);

            //send token
            return Ok(response);
        }

        private async Task<TokenResponse> CreateUserAccount(BasicAuthClaims basicAuthClaims)
        {
            //Create account in repository;
            await accountIdentityProvider.CreateUserAccount(basicAuthClaims.Email, basicAuthClaims.Password);

            //Create token
            TokenResponse response =
                accountIdentityProvider.GetIdentity(basicAuthClaims.Email, basicAuthClaims.Password);
            return response;
        }

    }
}