using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Handlers
{
    public class GenreHandler : StoryWorkflowHandler
    {
        public override StoryContext Handle(StoryContext context)
        {
            context.Prompt += $"Genre: {context.Genre}";
            return base.Handle(context);
        }
    }
}
