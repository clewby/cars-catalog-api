using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SB.CarsCatalog.Api.Data;
using SB.CarsCatalog.Api.Errors;
using SB.CarsCatalog.Api.Models;
using System.Net;
using System.Threading.Tasks;

namespace SB.CarsCatalog.Api.Controllers
{
    /// <summary>
    /// Users api controller
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// User service
        /// </summary>
        private IUserService userService;

        /// <summary>
        /// Users controller ctor
        /// </summary>
        /// <param name="userService">user service</param>
        /// <param name="appSettings"></param>
        public UsersController(
            IUserService userService,
            IOptions<AppSettings> appSettings)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="userToLogin">user to login</param>
        /// <returns>user data with token</returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userToLogin)
        {
            if(ModelState.IsValid)
            {
                return Ok(await userService.AuthenticateAsync(userToLogin.UserName, userToLogin.Password));
            }

            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Username or password is empty");
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="userToRegister">user to register</param>
        /// <returns>register user</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]User userToRegister)
        {
            return Ok(await userService.RegisterAsync(userToRegister));
        }
    }
}