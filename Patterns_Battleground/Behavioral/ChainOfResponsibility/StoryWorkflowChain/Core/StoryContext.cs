namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core
{
    public record StoryContext
    {
        public string StoryType { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string AgeGroup { get; set; } = string.Empty;
        public string Tone { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        public bool IsPremiumUser { get; set; }
        public bool IsBlocked { get; set; }
        public string? BlockReason { get; set; }

        public List<string> AvailableGenres { get; set; } = [];
    }
}
