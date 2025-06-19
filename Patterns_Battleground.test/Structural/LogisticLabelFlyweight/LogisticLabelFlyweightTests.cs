using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Flyweight.LogisticLabelsFlyweight.Core;

namespace Patterns_Battleground.test.Structural.LogisticLabelFlyweight
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
        public void GetLabel_WhenCallGetLabelWhenTwoExistedParameters_ShouldCreateNewLabel()
        {
            //Arrange
            LabelFlyweightFactory labelFactory = new();

            //Act
            // create label that should exist in label list - instead of creating, should return existing object.
            var createdLabel = labelFactory.GetLabel("LABEL2", "ICON", "RED");
            var secondCreatedLabel = labelFactory.GetLabel("LABEL2", "ICON", "BLUE");

            //Assert
            Assert.NotEqual(createdLabel, secondCreatedLabel);
        }

        [Fact]
        public void GetLabel_WhenCallGetLabelWhenOneExistedParameters_ShouldCreateNewLabel()
        {
            //Arrange
            LabelFlyweightFactory labelFactory = new();
            
            //Act
            // create label that should exist in label list - instead of creating, should return existing object.
            var createdLabel = labelFactory.GetLabel("LABEL2", "ICON", "RED");
            var secondCreatedLabel = labelFactory.GetLabel("LABEL3", "ICON", "BLUE");
            var thirdCreatedLabel = labelFactory.GetLabel("LABEL3", "ICON", "BLUE");

            //Assert
            Assert.NotEqual(createdLabel, secondCreatedLabel);
            Assert.Same(secondCreatedLabel, thirdCreatedLabel);
        }

    }
}
