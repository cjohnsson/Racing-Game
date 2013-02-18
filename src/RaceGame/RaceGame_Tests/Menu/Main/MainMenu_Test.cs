using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RaceGame.Menu;

namespace RaceGame_Tests.Menu.Main
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class MainMenu_Test
    {
        private MainMenu MakeMainMenu()
        {
            return new MainMenu();
        }

        [Test]
        public void ScrollUp_SelectedMenuItemsValueIsGreaterThan0_DecreasesSelectedMenuItemsValue()
        {
            var mainMenu = MakeMainMenu();
            mainMenu.ScrollDown();

            mainMenu.ScrollUp();

            var result = mainMenu.SelectedMenuItem.Text;
            Assert.AreEqual("Number of players: {0}", result);
        }

        [Test]
        public void ScrollUp_SelectedMenuItemsValueIs0_SetsSelectedMenuItemsValueToMaxValue()
        {
            var mainMenu = MakeMainMenu();

            mainMenu.ScrollUp();

            var result = mainMenu.SelectedMenuItem.Text;
            Assert.AreEqual("Number of laps: {0}", result);
        }

        [Test]
        public void ScrollDown_SelectedMenuItemsValueIsLowerThanMaxValue_RaisesSelectedMenuItemsValue()
        {
            var mainMenu = MakeMainMenu();

            mainMenu.ScrollDown();

            var result = mainMenu.SelectedMenuItem.Text;
            Assert.AreEqual("Number of bots: {0}", result);
        }

        [Test]
        public void ScrollDown_SelectedMenuItemsValueIsMaxValue_SetsSelectedMenuItemsValueTo0()
        {
            var mainMenu = MakeMainMenu();
            mainMenu.ScrollUp();

            mainMenu.ScrollDown();

            var result = mainMenu.SelectedMenuItem.Text;
            Assert.AreEqual("Number of players: {0}", result);
        }

        [Test]
        public void RaiseChosenValue_TheValueNrOfPlayersIsLowerThanTheMaximumValue_RaiseValue()
        {
            var mainMenu = MakeMainMenu();

            mainMenu.SelectedMenuItem.RaiseValue();

            int result = mainMenu.NrOfPlayers;
            Assert.AreEqual(2, result);
        }

        [Test]
        public void RaiseChosenValue_TheValueNrOfPlayersIsTheMaximumValue_SetsNrOfPlayersValueToTheMinimumValue()
        {
            var mainMenu = MakeMainMenu();
            mainMenu.SelectedMenuItem.RaiseValue();

            mainMenu.SelectedMenuItem.RaiseValue();

            int result = mainMenu.NrOfPlayers;
            Assert.AreEqual(1, result);
        }

        [Test]
        public void LowerChosenValue_TheValueOfNrOfPlayersIsHigherThanItsMinimumValue_LowerValue()
        {
            var mainMenu = MakeMainMenu();
            mainMenu.SelectedMenuItem.RaiseValue();

            mainMenu.SelectedMenuItem.LowerValue();

            int result = mainMenu.NrOfPlayers;
            Assert.AreEqual(1, result);
        }

        [Test]
        public void LowerChosenValue_TheValueOfNrOfPlayersIsEqualToItsMinimumValue_SetsNrOfPlayersToItsMaximumValue()
        {
            var mainMenu = MakeMainMenu();

            mainMenu.SelectedMenuItem.LowerValue();

            int result = mainMenu.NrOfPlayers;
            Assert.AreEqual(2, result);
        }
    }

    // ReSharper restore InconsistentNaming
}