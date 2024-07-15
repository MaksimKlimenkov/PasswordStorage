namespace PasswordStorage.API.DTOs.UserPassword;

public record UserPasswordDto(int Id, string EmailOrWebsite, string Password, DateTime CreatedAt);