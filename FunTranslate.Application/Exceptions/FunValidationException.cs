using FluentValidation.Results;

namespace FunTranslate.Application.Exceptions;
public class FunValidationException : ApplicationException
{
    public List<string> ValidationErrors { get; set; } = new();
    public FunValidationException(ValidationResult validationResult) =>
        validationResult.Errors?.ForEach(error => ValidationErrors.Add(error.ErrorMessage));
}
