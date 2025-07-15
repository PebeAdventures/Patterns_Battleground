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
    public static StoryContext PremiumUserPartialData => new()
    {
        StoryType = "Story",
        Language = "English",
        AgeGroup = "15+",
        IsPremiumUser = true
    };
    public static StoryContext FreeUserPartialData => new()
    {
        StoryType = "Story",
        Language = "English",
        AgeGroup = "15+",
        IsPremiumUser = false
    };
    public static StoryContext PremiumUserPolish => new()
    {
        StoryType = "Story",
        Language = "Polish",
        AgeGroup = "15+",
        Tone = "Dark",
        Genre = "Horror",
        IsPremiumUser = true
    };
    public static StoryContext PremiumUserBookPolish => new()
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
        StoryType = "Story",
        Language = "Polish",
        AgeGroup = "15+",
        Tone = "Dark",
        Genre = "Horror",
        IsPremiumUser = false
    };

    public static StoryContext PremiumUserBookEnglish => new()
    {
        StoryType = "Book",
        Language = "English",
        AgeGroup = "15+",
        Tone = "Dark",
        Genre = "Horror",
        IsPremiumUser = true
    };

    public static StoryContext FreeUserBookEnglish => new()
    {
        StoryType = "Book",
        Language = "English",
        AgeGroup = "15+",
        Tone = "Dark",
        Genre = "Horror",
        IsPremiumUser = false
    };
    public static StoryContext FreeUserEnglish => new()
    {
        StoryType = "Story",
        Language = "English",
        AgeGroup = "15+",
        Tone = "Dark",
        Genre = "Horror",
        IsPremiumUser = false
    };
    public static StoryContext PremiumUserEnglish => new()
    {
        StoryType = "Story",
        Language = "English",
        AgeGroup = "15+",
        Tone = "Dark",
        Genre = "Horror",
        IsPremiumUser = true
    };

    public static IStoryWorkflowHandler PartialWorkflowChain =>
        new StoryTypeHandler()
            .SetNext(new LanguageHandler())
            .SetNext(new ToneHandler())
            .SetNext(new GenreHandler())
            .SetNext(new PromtBuilderHandler());

    public static IStoryWorkflowHandler FullWorkflowChain =>
        new StoryTypeHandler()
            .SetNext(new AgeHandler())
            .SetNext(new LanguageHandler())
            .SetNext(new ToneHandler())
            .SetNext(new GenreHandler())
            .SetNext(new PromtBuilderHandler());
}