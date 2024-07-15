using PasswordStorage.API.Data;
using PasswordStorage.API.Models;
using PasswordStorage.API.Repositories.Interfaces;
namespace PasswordStorage.API.Repositories;

public class EmailPasswordRepository(ApplicationContext context) : IEmailPasswordRepository
{
    public async Task CreateAsync(EmailPassword emailPassword)
    {
        await context.AddAsync(emailPassword);
        await context.SaveChangesAsync();
    }
}