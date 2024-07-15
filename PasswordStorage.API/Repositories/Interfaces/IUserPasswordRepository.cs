using PasswordStorage.API.Models;

namespace PasswordStorage.API.Repositories.Interfaces;

public interface IUserPasswordRepository
{
    Task<IEnumerable<UserPassword>> SearchAsync(string query);
}