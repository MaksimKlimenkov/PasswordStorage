using Microsoft.EntityFrameworkCore;
using PasswordStorage.API.Data;
using PasswordStorage.API.Models;
using PasswordStorage.API.Repositories.Interfaces;

namespace PasswordStorage.API.Repositories;

public class UserPasswordRepository(ApplicationContext context) : IUserPasswordRepository
{
    public async Task<IEnumerable<UserPassword>> SearchAsync(string query)
    {
        return await context.UserPasswords.Where(up =>
                (up as EmailPassword).Email.Contains(query) || (up as WebsitePassword).Url.Contains(query))
            .ToListAsync();
    }
}