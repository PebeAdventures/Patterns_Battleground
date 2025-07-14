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
            var mockData = StoryWorkflowMocks.FreeUserEnglish;
            var basicChain = StoryWorkflowMocks.BasicWorkflowChain;

            //Act
            var result = basicChain.Handle(mockData);

            //Assert
            Assert.True(result.IsBlocked);
            Assert.Equal("Generating books is available only for premium users.", result.BlockReason);
            Assert.Equal(string.Empty, result.Prompt); 
        }
    }
}
