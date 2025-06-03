using System.Linq;
using System.Numerics;
using Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions;

namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Validators;

public class AndValidator : IValidator
{
    private readonly IValidator[] _validators;

    public AndValidator(IValidator[] validators)
    {
        _validators = validators ?? throw new ArgumentNullException(nameof(validators));
    }

    public ValidationResult Validate(string input)
    {
        var failedResults = new List<ValidationResult>();
        foreach (var validator in _validators)
        {
            var result = validator.Validate(input);
            if (!result.IsValid)
            {
                failedResults.Add(result);
            }
        }

        if (failedResults.Count != 0)
        {
            var incorrectMessages = string.Join("; ", failedResults.Select(m => m.ErrorMessage));
            return ValidationResult.Failure($"Validation failed for the following validators: {incorrectMessages}");
        }

        return ValidationResult.Success();
    }
}
