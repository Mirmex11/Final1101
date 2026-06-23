using ReadCity.DataAccess.Models;
using ReadCity.DataAccess.Repositories;

namespace ReadCity.DataAccess.Services
{
    /// <summary>
    /// Авторизация пользователя.
    /// </summary>
    /// <param name="userRepository"></param>
    public class AuthService(UserRepository userRepository)
    {
        private readonly UserRepository _userRepository = userRepository;

        public User? Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            return _userRepository.FindByCredentials(login.Trim(), password);
        }
    }
}
