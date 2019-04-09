using SB.CarsCatalog.Api.Models;
using System.Threading.Tasks;

namespace SB.CarsCatalog.Api.Data
{
    /// <summary>
    /// User service interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticate user async
        /// </summary>
        /// <param name="username">user name</param>
        /// <param name="password">password</param>
        /// <returns>user</returns>
        Task<User> AuthenticateAsync(string username, string password);
        /// <summary>
        /// Register a new user async
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>user</returns>
        Task<User> RegisterAsync(User user);
    }
}
