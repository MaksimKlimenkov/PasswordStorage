using System.ComponentModel.DataAnnotations;

namespace PasswordStorage.API.DTOs.UserPassword;

public class CreateWebsitePasswordDto
{
    [Required] public string Url { get; set; }
    [MinLength(8)] public string Password { get; set; }
}