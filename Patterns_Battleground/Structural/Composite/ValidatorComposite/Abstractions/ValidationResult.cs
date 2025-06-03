namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions
{
    public record ValidationResult(bool IsValid, string? ErrorMessage = null)
    {
        public static ValidationResult Success() => new(true);
        public static ValidationResult Failure(string error) => new(false, error);
    }

}
