using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Handlers
{
    public class StoryTypeHandler : StoryWorkflowHandler
    {
        public override StoryContext Handle(StoryContext context)
        {
            if (context.IsBlocked)
                return context;

            if (string.IsNullOrWhiteSpace(context.StoryType))
            {
                context.IsBlocked = true;
                context.BlockReason = "Story type was not specified.";
                return context;
            }

            if (context.StoryType.Equals("Book", StringComparison.OrdinalIgnoreCase)
                && !context.IsPremiumUser)
            {
                context.IsBlocked = true;
                context.BlockReason = "Premium account required to access full-length books.";
                return context;
            }

            return base.Handle(context);
        }
    }
}
