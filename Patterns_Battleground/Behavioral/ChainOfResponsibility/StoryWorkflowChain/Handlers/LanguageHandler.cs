using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Handlers
{
    public class LanguageHandler : StoryWorkflowHandler
    {
        public override StoryContext Handle(StoryContext context)
        {
            if (context.Language != "English" && !context.IsPremiumUser)
            {
                context.Block($"{context.Language} langueage is available only for premium users");
                return context;
            }
            context.Prompt += $"Language: {context.Language}";
            return base.Handle(context);
        }

    }
}
