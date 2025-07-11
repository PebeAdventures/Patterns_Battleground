namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

public interface IStoryWorkflowHandler
{
    IStoryWorkflowHandler SetNext(IStoryWorkflowHandler handler);
    StoryContext Handle(StoryContext context);
}
