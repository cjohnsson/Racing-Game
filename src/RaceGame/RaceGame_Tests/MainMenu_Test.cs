using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using NUnit.Framework;
using RaceGame;

namespace RaceGame_Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class MainMenu_Test
    {
        private MainMenu MakeMenu()
        {
            return new MainMenu();
        }

        [Test]
        public void ScrollUp_IndexIsGreaterThan0_DecreasesIndex()
        {
            MainMenu menu = MakeMenu();

            menu.ScrollDown();
            menu.ScrollUp();

            int result = menu.SelectedMainMenuItem.GetValue();
            Assert.AreEqual(0, result );
        }

        [Test]
        public void ScrollUp_IndexIs0_SetsIndexToMaxValue()
        {
            MainMenu menu = MakeMenu();

            menu.ScrollUp();

            int result = menu.SelectedMainMenuItem.GetValue();
            Assert.AreEqual(4, result);
        }

        [Test]
        public void ScrollDown_IndexIsLowerThanMaxValue_RaisesIndex()
        {
            MainMenu menu = MakeMenu();

            menu.ScrollDown();

            int result = menu.SelectedMainMenuItem.GetValue();
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ScrollDown_IndexIsMaxValue_SetsIndexTo0()
        {
            MainMenu menu = MakeMenu();

            menu.ScrollUp();
            menu.ScrollDown();

            int result = menu.SelectedMainMenuItem.GetValue();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RaiseChosenValue_TheValueNrOfPlayersIsHigherThanTheMaximumValue_RaiseValue()
        {
            MainMenu menu = MakeMenu();

            menu.RaiseSelectedValue();


            int result = menu.NrOfPlayers;
            Assert.AreEqual(2, result);
        }

        [Test]
        public void RaiseChosenValue_TheValueNrOfPlayersIsTheMaximumValue_SetsNrOfPlayersValueToTheMinimumValue()
        {
            MainMenu menu = MakeMenu();

            menu.RaiseSelectedValue();
            menu.RaiseSelectedValue();

            int result = menu.NrOfPlayers;
            Assert.AreEqual(1, result);
        }

        [Test]
        public void LowerChosenValue_TheValueOfNrOfPlayersIsHigherThanItsMinimumValue_LowerValue()
        {
            MainMenu menu = MakeMenu();

            menu.RaiseSelectedValue();
            menu.LowerSelectedValue();

            int result = menu.NrOfPlayers;
            Assert.AreEqual(1, result);
        }

        [Test]
        public void LowerChosenValue_TheValueOfNrOfPlayersIsEqualToItsMinimumValue_SetsNrOfPlayersToItsMaximumValue()
        {
            MainMenu menu = MakeMenu();

            menu.LowerSelectedValue();

            int result = menu.NrOfPlayers;
            Assert.AreEqual(2, result);
        }
    }

    // ReSharper restore InconsistentNaming
}