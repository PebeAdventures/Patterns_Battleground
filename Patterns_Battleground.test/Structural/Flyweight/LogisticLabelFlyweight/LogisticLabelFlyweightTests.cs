using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Flyweight.LogisticLabelsFlyweight.Core;

namespace Patterns_Battleground.test.Structural.Flyweight.LogisticLabelFlyweight
{
    public class LogisticLabelFlyweightTests
    {
        // Co ja mogę testować? 
        // np. factory - czy tworzy poprawne obiekty Label
        // czy wymagając obiektu x,x,x jeżeli znajduje się w db zwraca istniejącą instancję
        // czy wymagajC OBIEKTU yyy którego nie ma, tworzy nową instanację
        // czy jeżeli wymaga obiektu gdzie pokrywają się 2 warunki tworzy nowy, to samo do jednego warunku
        // + ew. jeżeli null/empty
        [Fact]
        public void GetLabel_WhenLabelIsCreated_ShouldCreateCorrectLabel()
        {
            //Arrange
            LabelFlyweightFactory labelFactory = new();
            var expected = new LabelFlyweight("LABEL1", "ICON", "RED");

            //Act
            var createdLabel = labelFactory.GetLabel("LABEL1", "ICON", "RED");
            
            //Assert
            Assert.Equal(expected, createdLabel);
        }

        [Fact]
        public void GetLabel_WhenLabelExistInList_ShouldReturnExistedLabel()
        {
            //Arrange
            LabelFlyweightFactory labelFactory = new();
            //create new label
            var firstLabel = labelFactory.GetLabel("LABEL1", "ICON", "RED");

            //Act
            // create label that should exist in label list - instead of creating, should return existing object.
            var createdLabel = labelFactory.GetLabel("LABEL1", "ICON", "RED");

            //Assert
            Assert.Same(firstLabel, createdLabel);
        }

        [Fact]
        public void GetLabel_WhenCallGetLabelWhenTwoKeyDiffers_ShouldCreateNewLabel()
        {
            //Arrange
            LabelFlyweightFactory labelFactory = new();

            //Act
            // create label that should exist in label list - instead of creating, should return existing object.
            var createdLabel = labelFactory.GetLabel("LABEL2", "ICON", "RED");
            var secondCreatedLabel = labelFactory.GetLabel("LABEL2", "ICON", "BLUE");

            //Assert
            Assert.NotSame(createdLabel, secondCreatedLabel);
        }

        [Fact]
        public void GetLabel_WhenCallGetLabelWhenOneKeyDiffers_ShouldCreateNewLabel()
        {
            //Arrange
            LabelFlyweightFactory labelFactory = new();
            
            //Act
            // create label that should exist in label list - instead of creating, should return existing object.
            var createdLabel = labelFactory.GetLabel("LABEL1", "ICON", "RED");
            var secondCreatedLabel = labelFactory.GetLabel("LABEL2", "ICON", "BLUE");
            var thirdCreatedLabel = labelFactory.GetLabel("LABEL2", "ICON", "BLUE");

            //Assert
            Assert.NotSame(createdLabel, secondCreatedLabel);
            Assert.Same(secondCreatedLabel, thirdCreatedLabel);
        }

        [Fact]
        public void GetLabel_WhenCalledMultipleTimes_ShouldReturnSameInstance()
        {
            //Arrange
            LabelFlyweightFactory labelFactory = new();

            //Act
            var firstLabel = labelFactory.GetLabel("LABEL1", "ICON", "RED");
            var secondLabel = labelFactory.GetLabel("LABEL1", "ICON", "RED");
            var thirdLabel = labelFactory.GetLabel("LABEL1", "ICON", "RED");

            //Assert
            Assert.Same(firstLabel, secondLabel);
            Assert.Same(secondLabel, thirdLabel);
        }

        [Fact]
        public async Task GetLabel_WhenCalledConcurrently_ShouldReturnSameInstance()
        {
            //Arrange
            LabelFlyweightFactory labelFactory = new();
            var labels = new ILabelFlyweight[100];
            var tasks = new List<Task>();

            //Act
            for(int i = 0; i < 100; i++)
            {
                int index = i;
                tasks.Add(Task.Run(() =>
                {
                    labels[index] = labelFactory.GetLabel("LABEL1", "ICON", "RED");
                }));
            }
            await Task.WhenAll(tasks);
            //Assert
            var reference = labels[0];

            foreach(var label in labels)
            {
                Assert.Same(reference, label);
            }

        }
    }
}
