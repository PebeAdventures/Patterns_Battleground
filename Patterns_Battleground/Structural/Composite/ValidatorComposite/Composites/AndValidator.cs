
using System.Linq;
using System.Numerics;
using Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions;

namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Composites;

public class AndValidator : IValidator
{
    //C# 12 collection expression – equivalent to new List<IValidator>()  
    private readonly List<IValidator> _validators = [];

    public void Add(IValidator validator)
    {
        // C# 10 null-check shortcut
        ArgumentNullException.ThrowIfNull(validator);

        _validators.Add(validator);
    }

    public void AddMany(IEnumerable<IValidator> validators)
    {
        // C# 10 null-check shortcut
        ArgumentNullException.ThrowIfNull(validators);

        foreach (var validator in validators)
        {
            Add(validator); 
        }
    }

    // Return success if all validators pass.
    // Otherwise, return combined failure message from all.
    public ValidatorResult Validate(string input)
    {
        var failedResults = new List<ValidatorResult>();
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
            return ValidatorResult.Failure($"Validation failed for the following validators: {incorrectMessages}");
        }

        return ValidatorResult.Success();
    }
}
