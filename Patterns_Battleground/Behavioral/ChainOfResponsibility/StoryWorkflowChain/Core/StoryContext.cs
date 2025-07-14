namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

public record StoryContext
{
    public string StoryType { get; init; } = string.Empty;
    public string Language { get; init; } = string.Empty;
    public string AgeGroup { get; init; } = string.Empty;
    public string Tone { get; init; } = string.Empty;
    public string Genre { get; init; } = string.Empty;
    public string Prompt { get; set; } = string.Empty;
    public bool IsPremiumUser { get; init; }
    public bool IsBlocked { get; private set; }
    public string? BlockReason { get; private set; }

    public void Block(string reason)
    {
        IsBlocked = true;
        BlockReason = reason;
    }

}
