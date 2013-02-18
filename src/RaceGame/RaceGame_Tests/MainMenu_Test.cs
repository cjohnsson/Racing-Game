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

            Assert.AreEqual(0, menu.SelectedMainMenuItem);
        }

        [Test]
        public void ScrollUp_IndexIs0_SetsIndexToMaxValue()
        {
            MainMenu menu = MakeMenu();

            menu.ScrollUp();

            Assert.AreEqual(4, menu.SelectedMainMenuItem);
        }

        [Test]
        public void ScrollDown_IndexIsLowerThanMaxValue_RaisesIndex()
        {
            MainMenu menu = MakeMenu();

            menu.ScrollDown();

            Assert.AreEqual(1, menu.SelectedMainMenuItem);
        }

        [Test]
        public void ScrollDown_IndexIsMaxValue_SetsIndexTo0()
        {
            MainMenu menu = MakeMenu();

            menu.ScrollUp();
            menu.ScrollDown();

            Assert.AreEqual(0, menu.SelectedMainMenuItem);
        }

        [Test]
        public void RaiseChosenValue_TheValueNrOfPlayersIsHigherThanTheMaximumValue_RaiseValue()
        {
            MainMenu menu = MakeMenu();

            menu.RaiseSelectedValue();

            Assert.AreEqual(2, menu.NrOfPlayers);
        }

        [Test]
        public void RaiseChosenValue_TheValueNrOfPlayersIsTheMaximumValue_SetsNrOfPlayersValueToTheMinimumValue()
        {
            MainMenu menu = MakeMenu();

            menu.RaiseSelectedValue();
            menu.RaiseSelectedValue();

            Assert.AreEqual(1, menu.NrOfPlayers);
        }

        [Test]
        public void LowerChosenValue_TheValueOfNrOfPlayersIsHigherThanItsMinimumValue_LowerValue()
        {
            MainMenu menu = MakeMenu();

            menu.RaiseSelectedValue();
            menu.LowerSelectedValue();

            Assert.AreEqual(1, menu.NrOfPlayers);
        }

        [Test]
        public void LowerChosenValue_TheValueOfNrOfPlayersIsEqualToItsMinimumValue_SetsNrOfPlayersToItsMaximumValue()
        {
            MainMenu menu = MakeMenu();

            menu.LowerSelectedValue();

            Assert.AreEqual(2, menu.NrOfPlayers);
        }
    }

    // ReSharper restore InconsistentNaming
}