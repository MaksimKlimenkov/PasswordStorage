using PasswordStorage.API.Models;

namespace PasswordStorage.API.Repositories.Interfaces;

public interface IWebsitePasswordRepository
{
    Task CreateAsync(WebsitePassword emailPassword);
}