using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RaceGame.Menu.Main;


namespace RaceGame_Tests.Menu.Main
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class MainMenuItemTests
    {
        private MenuItem MakeMainMenuItem()
        {
            return new MenuItem();
        }

        [Test]
        public void ToString_DefaultText_ReturnsEmptyString()
        {
            //Arrange
            var mainMenuItem = MakeMainMenuItem();

            //Act
            var result = mainMenuItem.ToString();

            //Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void ToString_GiveString_ReturnsString()
        {
            //Arrange
            string expected = "Number of players: {0}";
            var mainMenuItem = new MenuItem(expected);

            //Act
            var result = mainMenuItem.ToString();

            //Assert
            Assert.AreEqual(expected,result);
        }

        [Test]
        public void ToString_GiveStringAndValue_ReturnsStringAndValue()
        {
            //Arrange
            string expected = "Number of players: {0}";
            var rolloverUtility = new RolloverUtility(1, 1, 2);
            var mainMenuItem = new MenuItem(expected, rolloverUtility);

            //Act
            var result = mainMenuItem.ToString();

            //Assert
            Assert.AreEqual("Number of players: 1",result);
        }

        [Test]
        public void RaiseValue_RolloverUtilityNull_DoesNotThrowNullReferenceException()
        {
            //Arrange
            string text = "START THE GAME";
            var mainMenuItem = new MenuItem(text);
            
            //Act
            mainMenuItem.RaiseValue();

            //Assert
            
        }

        [Test]
        public void LowerValue_RolloverUtilityNull_DoesNotThrowNullReferenceException()
        {
            //Arrange
            string text = "START THE GAME";
            var mainMenuItem = new MenuItem(text);

            //Act
            mainMenuItem.LowerValue();

            //Assert
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetValue_RolloverUtilityNull_ThrowsNullReferenceException()
        {
            //Arrange
            string text = "START THE GAME";
            var mainMenuItem = new MenuItem(text);

            //Act
            mainMenuItem.GetValue();

            //Assert
        }
    }

    // ReSharper restore InconsistentNaming
}