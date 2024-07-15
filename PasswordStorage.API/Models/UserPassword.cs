namespace PasswordStorage.API.Models;

public abstract class UserPassword
{
    public int Id { get; set; }
    public required string Password { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    public string GetEmailOrUrl() =>
        this is EmailPassword ep
            ? ep.Email
            : ((WebsitePassword)this).Url;
}

public class WebsitePassword : UserPassword
{
    public required string Url { get; set; }
}

public class EmailPassword : UserPassword
{
    public required string Email { get; set; }
}