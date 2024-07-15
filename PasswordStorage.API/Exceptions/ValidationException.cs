using System.ComponentModel.DataAnnotations;

namespace PasswordStorage.API.Exceptions;

public class ValidationException(IEnumerable<ValidationResult> results) : Exception
{
    public IEnumerable<ValidationResult> Results { get; set; } = results;
}