using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;
using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Battleground.test.Behavioral.ChainOfResponsibility.StoryWorkflow;

public static class StoryWorkflowMocks
{
    public static StoryContext PremiumUserPolish => new()
    {
        StoryType = "Book",
        Language = "Polish",
        AgeGroup = "15+",
        Tone = "Dark",
        Genre = "Horror",
        IsPremiumUser = true
    };

    public static StoryContext FreeUserPolish => new()
    {
        StoryType = "Book",
        Language = "Polish",
        AgeGroup = "15+",
        Tone = "Dark",
        Genre = "Horror",
        IsPremiumUser = false
    };

    public static StoryContext PremiumUserEnglish => new()
    {
        StoryType = "Book",
        Language = "English",
        AgeGroup = "15+",
        Tone = "Dark",
        Genre = "Horror",
        IsPremiumUser = true
    };

    public static StoryContext FreeUserEnglish => new()
    {
        StoryType = "Book",
        Language = "English",
        AgeGroup = "15+",
        Tone = "Dark",
        Genre = "Horror",
        IsPremiumUser = false
    };

    public static IStoryWorkflowHandler BasicWorkflowChain =>
        new StoryTypeHandler()
            .SetNext(new LanguageHandler())
            .SetNext(new ToneHandler())
            .SetNext(new GenreHandler())
            .SetNext(new PromtBuilderHandler());
}
