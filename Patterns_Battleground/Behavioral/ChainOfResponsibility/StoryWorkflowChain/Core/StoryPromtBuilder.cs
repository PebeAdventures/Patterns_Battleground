
using System.Text;

namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

public class StoryPromtBuilder
{
    private readonly IStoryWorkflowHandler _workflow;

    public StoryPromtBuilder(IStoryWorkflowHandler workflow)
    {
        _workflow = workflow;
    }

    public string BuildPromt(StoryContext context)
    {
        var processedContext = _workflow.Handle(context);

        if (processedContext.IsBlocked) 
        {
            return $"[Blocked]: {processedContext.BlockReason}";
        }

        return GeneratePromt(processedContext);
}

    private string GeneratePromt(StoryContext ctx)
    {
         var sb = new StringBuilder();

        sb.AppendLine($"[Story Type]: {ctx.StoryType}");
        sb.AppendLine($"[Language]: {ctx.Language}");
        sb.AppendLine($"[Age Group]: {ctx.AgeGroup}");
        sb.AppendLine($"[Genre]: {ctx.Genre}");
        sb.AppendLine($"[Tone]: {ctx.Tone}");
        sb.AppendLine();
        sb.AppendLine("ased on the context above, generate a story that is engaging, appropriate for the selected age group, and follows the selected style and genre.");

        return sb.ToString();
    }
}
