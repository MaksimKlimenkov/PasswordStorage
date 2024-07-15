using System.ComponentModel.DataAnnotations;

namespace PasswordStorage.API.DTOs.UserPassword;

public class CreateEmailPasswordDto
{
    [EmailAddress] public string Email { get; set; }
    [MinLength(8)] public string Password { get; set; }
}