
using Patterns_Battleground.Structural.Composite.ValidatorComposite.Composites;
using Patterns_Battleground.Structural.Composite.ValidatorComposite.Validators;

namespace Patterns_Battleground.test.Structural.Composite.ValidatorComposite;

public class ValidatorTests
{
    [Fact]
    public void Validate_WhenEmailIsProperlyFormatted_ShouldReturnSuccess()
    {
        var validator = new EmailValidator();
        var result = validator.Validate("test@example.com");
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_WhenEmailIsNotFormattedCorrectly_ShouldReturnFailure()
    {
        var validator = new EmailValidator();
        var result = validator.Validate("not-an-email");
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Validate_WhenInputLengthMeetsMinimum_ShouldReturnSuccess()
    {
        var validator = new MinLengthValidator(5);
        var result = validator.Validate("abcde");
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_WhenInputLengthIsTooShort_ShouldReturnFailure()
    {
        var validator = new MinLengthValidator(6);
        var result = validator.Validate("abc");
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Validate_WhenInputContainsDigit_ShouldReturnSuccess()
    {
        var validator = new ContainsDigitValidator();
        var result = validator.Validate("abc1");
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_WhenInputDoesNotContainDigit_ShouldReturnFailure()
    {
        var validator = new ContainsDigitValidator();
        var result = validator.Validate("abcdef");
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Validate_WhenInputDoesNotContainDigit_ShouldReturnSuccess_ForNotContainsDigitValidator()
    {
        var validator = new NotContainsDigitValidator();
        var result = validator.Validate("abcdef");
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_WhenInputContainsDigit_ShouldReturnFailure_ForNotContainsDigitValidator()
    {
        var validator = new NotContainsDigitValidator();
        var result = validator.Validate("abc1");
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Validate_WhenInputHasNoWhitespace_ShouldReturnSuccess()
    {
        var validator = new NoWhiteSpaceValidator();
        var result = validator.Validate("abc123");
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_WhenInputHasWhitespace_ShouldReturnFailure()
    {
        var validator = new NoWhiteSpaceValidator();
        var result = validator.Validate("abc 123");
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Validate_WhenAllValidatorsSucceed_ShouldReturnSuccess_ForAndValidator()
    {
        var validator = new AndValidator();
        validator.Add(new MinLengthValidator(4));
        validator.Add(new ContainsDigitValidator());

        var result = validator.Validate("abc1");
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_WhenAtLeastOneValidatorFails_ShouldReturnFailure_ForAndValidator()
    {
        var validator = new AndValidator();
        validator.Add(new MinLengthValidator(10));
        validator.Add(new ContainsDigitValidator());

        var result = validator.Validate("abc1");
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Validate_WhenAtLeastOneValidatorPasses_ShouldReturnSuccess_ForOrValidator()
    {
        var validator = new OrValidator();
        validator.Add(new EmailValidator());
        validator.Add(new ContainsDigitValidator());

        var result = validator.Validate("abc1");
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_WhenAllValidatorsFail_ShouldReturnFailure_ForOrValidator()
    {
        var validator = new OrValidator();
        validator.Add(new EmailValidator());
        validator.Add(new MinLengthValidator(10));

        var result = validator.Validate("abc");
        Assert.False(result.IsValid);
    }
}
