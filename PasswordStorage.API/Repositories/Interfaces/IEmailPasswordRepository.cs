using PasswordStorage.API.Models;

namespace PasswordStorage.API.Repositories.Interfaces;

public interface IEmailPasswordRepository
{
    Task CreateAsync(EmailPassword emailPassword);
}