using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SB.CarsCatalog.Api.Errors;
using SB.CarsCatalog.Api.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SB.CarsCatalog.Api.Data
{
    /// <summary>
    /// User service
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// db context
        /// </summary>
        private CarsCatalogDbContext context;
        /// <summary>
        /// app settings
        /// </summary>
        private AppSettings appSettings;

        /// <summary>
        /// User service ctor
        /// </summary>
        /// <param name="context">db context</param>
        /// <param name="appSettings">app settings</param>
        public UserService(CarsCatalogDbContext context, IOptions<AppSettings> appSettings)
        {
            this.context = context;
            this.appSettings = appSettings.Value;
        }

        /// <summary>
        /// Authenticate user async
        /// </summary>
        /// <param name="username">user name</param>
        /// <param name="password">password</param>
        /// <returns>user</returns>
        public async Task<User> AuthenticateAsync(string userName, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Username or password is incorrect");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and token to store client side
            return new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            };
        }
        /// <summary>
        /// Register a new user async
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>user</returns>
        public async Task<User> RegisterAsync(User user)
        {
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }
        /// <summary>
        /// Password Hash and Salt generating
        /// </summary>
        /// <param name="password">password</param>
        /// <param name="passwordHash">Hash</param>
        /// <param name="passwordSalt">Salt</param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        /// <summary>
        /// Verify password hash
        /// </summary>
        /// <param name="password">password</param>
        /// <param name="storedHash">stored Hash</param>
        /// <param name="storedSalt">stored Salt</param>
        /// <returns></returns>
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
