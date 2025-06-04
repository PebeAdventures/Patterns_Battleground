namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions
{
    public record ValidatorResult(bool IsValid, string? ErrorMessage = null)
    {
        public static ValidatorResult Success() => new(true);
        public static ValidatorResult Failure(string error) => new(false, error);
    }

}
