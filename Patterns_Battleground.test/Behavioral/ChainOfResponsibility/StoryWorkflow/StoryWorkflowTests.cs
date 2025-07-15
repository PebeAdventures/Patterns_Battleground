using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Battleground.test.Behavioral.ChainOfResponsibility.StoryWorkflow
{
    public class StoryWorkflowTests
    {
        [Fact]
        public void HandleStoryTypeBook_WhenUserIsNotPremium_ShouldBlockChain()
        {
            //Arrange
            var mockData = StoryWorkflowMocks.FreeUserBookEnglish;
            var basicChain = StoryWorkflowMocks.PartialWorkflowChain;

            //Act
            var result = basicChain.Handle(mockData);

            //Assert
            Assert.True(result.IsBlocked);
            Assert.Equal("Generating books is available only for premium users.", result.BlockReason);
            Assert.Equal(string.Empty, result.Prompt); 
        }

        [Fact]
        public void Handle_WhenOnlyPartialDataProvided_ShouldReturnPartialPromt()
        {
            //Arrange
            var mockData = StoryWorkflowMocks.FreeUserPartialData;
            var basicChain = StoryWorkflowMocks.FullWorkflowChain;
            var expectedPrompt = "Create a story, in English, for age group 15+.";
            //Act
            var result = basicChain.Handle(mockData);

            //Assert
            Assert.False(result.IsBlocked);
            Assert.Equal(expectedPrompt, result.Prompt);
        }

        [Fact]
        public void Handle_WhenDataProvided_ShouldReturnPromt()
        {
            //Arrange
            var mockData = StoryWorkflowMocks.FreeUserEnglish;
            var basicChain = StoryWorkflowMocks.FullWorkflowChain;
            var expectedPrompt = "Create a story, in English, for age group 15+, with a dark tone, and horror theme.";
            //Act
            var result = basicChain.Handle(mockData);

            //Assert
            Assert.False(result.IsBlocked);
            Assert.Equal(expectedPrompt, result.Prompt);
        }

        [Fact]
        public void Handle_WhenUserIsPremium_ShouldAllowBookGeneration()
        {
            //Arrange
            var mockData = StoryWorkflowMocks.PremiumUserBookEnglish;
            var basicChain = StoryWorkflowMocks.FullWorkflowChain;

            //Act
            var result = basicChain.Handle(mockData);

            //Assert
            Assert.False(result.IsBlocked);
            Assert.Contains("book", result.Prompt.ToLower());
        }

        [Fact]
        public void Handle_WhenUserIsPremium_ShouldAllowPolishGeneration()
        {
            //Arrange
            var mockData = StoryWorkflowMocks.PremiumUserPolish;
            var basicChain = StoryWorkflowMocks.FullWorkflowChain;

            //Act
            var result = basicChain.Handle(mockData);

            //Assert
            Assert.False(result.IsBlocked);
            Assert.Contains(mockData.Language.ToLower(), result.Prompt.ToLower());
        }

        [Fact]
        public void Handle_WhenUserIsPremium_ShouldAllowBookPolishGeneration()
        {
            //Arrange
            var mockData = StoryWorkflowMocks.PremiumUserBookPolish;
            var basicChain = StoryWorkflowMocks.FullWorkflowChain;

            //Act
            var result = basicChain.Handle(mockData);

            //Assert
            Assert.False(result.IsBlocked);
            Assert.Contains(mockData.Language.ToLower(), result.Prompt.ToLower());
            Assert.Contains(mockData.StoryType.ToLower(), result.Prompt.ToLower());
        }
        [Fact]
        public void Handle_WhenOnlyToneAndGenreProvided_ShouldReturnPartialPrompt()
        {
            //Arrange
            var context = new StoryContext
            {
                Tone = "Mysterious",
                Genre = "Fantasy",
                IsPremiumUser = true
            };

            var chain = StoryWorkflowMocks.FullWorkflowChain;

            //Act
            var result = chain.Handle(context);

            //Assert
            Assert.False(result.IsBlocked);
            Assert.Equal("Create with a mysterious tone, and fantasy theme.", result.Prompt);
        }
    }
}
