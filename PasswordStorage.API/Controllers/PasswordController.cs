using Microsoft.AspNetCore.Mvc;
using PasswordStorage.API.DTOs;
using PasswordStorage.API.DTOs.UserPassword;
using PasswordStorage.API.Exceptions;
using PasswordStorage.API.Models;
using PasswordStorage.API.Repositories.Interfaces;

namespace PasswordStorage.API.Controllers;

[ApiController]
[Route("api/passwords")]
public class PasswordController(
    IUserPasswordRepository userPasswordRepository,
    IWebsitePasswordRepository websitePasswordRepository,
    IEmailPasswordRepository emailPasswordRepository
) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<UserPasswordDto>> Get(string? query)
    {
        var userPasswords = await userPasswordRepository.SearchAsync(query ?? string.Empty);
        return userPasswords.Select(up => new UserPasswordDto(up.Id, up.GetEmailOrUrl(), up.Password, up.CreateAt));
    }

    [HttpPost("email")]
    public async Task<IActionResult> PostEmailPassword(CreateEmailPasswordDto createEmailPasswordDto)
    {
        try
        {
            var emailPassword = new EmailPassword
            {
                Email = createEmailPasswordDto.Email,
                Password = createEmailPasswordDto.Password
            };
            await emailPasswordRepository.CreateAsync(emailPassword);
            return Ok();
        }
        catch (ValidationException e)
        {
            foreach (var result in e.Results)
                ModelState.AddModelError("EmailPassword", result.ErrorMessage!);
            return BadRequest(ModelState);
        }
    }

    [HttpPost("website")]
    public async Task<IActionResult> PostWebsitePassword(CreateWebsitePasswordDto createWebsitePasswordDto)
    {
        try
        {
            var websitePassword = new WebsitePassword
            {
                Url = createWebsitePasswordDto.Url,
                Password = createWebsitePasswordDto.Password
            };
            await websitePasswordRepository.CreateAsync(websitePassword);
            return Ok();
        }
        catch (ValidationException e)
        {
            foreach (var result in e.Results)
                ModelState.AddModelError("WebsitePassword", result.ErrorMessage!);
            return BadRequest(ModelState);
        }
    }
}