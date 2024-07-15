using Microsoft.EntityFrameworkCore;
using PasswordStorage.API.Data;
using PasswordStorage.API.Models;
using PasswordStorage.API.Repositories.Interfaces;

namespace PasswordStorage.API.Repositories;

public class WebsitePasswordRepository(ApplicationContext context) : IWebsitePasswordRepository
{
    public async Task CreateAsync(WebsitePassword websitePassword)
    {
        await context.WebsitePasswords.AddAsync(websitePassword);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<WebsitePassword>> FindAsync() =>
        await context.WebsitePasswords.ToListAsync();
}