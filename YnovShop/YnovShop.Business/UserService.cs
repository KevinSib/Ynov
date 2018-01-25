using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using YnovShop.Data;
using YnovShop.Data.Entities;
using YnovShop.Provider;

namespace YnovShop.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISaltProvider _saltProvider;
        private readonly IPasswordProvider _passwordProvider;

        public UserService(IUserRepository userRepository,
            ISaltProvider saltProvider,
            IPasswordProvider passwordProvider)
        {
            _userRepository = userRepository;
            _saltProvider = saltProvider;
            _passwordProvider = passwordProvider;
        }

        public void CreateUser(string firstname, string lastname, string email, string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var salt = _saltProvider.GetSalt();
            var passwordHash = _passwordProvider.PasswordHash(password, salt);

            var user = new YUser
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                PasswordHash = Convert.ToBase64String(passwordHash),
                Salt = Convert.ToBase64String(salt),
                Registration = DateTime.UtcNow,
                IsEnable = false
            };

            _userRepository.Insert(user);
        }

        public LoginResult LoginUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            YUser currentUser = this._userRepository.GetByEmail(email);
            if (currentUser == null)
            {
                return LoginResult.NotExists;
            }

            string userSalt = currentUser.Salt;
            string userPassword = currentUser.PasswordHash;

            bool isValidate = this._passwordProvider.Validate(password, Convert.FromBase64String(userSalt), Convert.FromBase64String(userPassword));
            if (isValidate)
            {
                return LoginResult.Success;
            }

            return LoginResult.Failed;
        }
    }
}
