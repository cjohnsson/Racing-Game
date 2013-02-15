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

            Assert.AreEqual(0, menu.Index);
        }

        [Test]
        public void ScrollUp_IndexIs0_SetsIndexToMaxValue()
        {
            MainMenu menu = MakeMenu();

            menu.ScrollUp();

            Assert.AreEqual(4, menu.Index);
        }

        [Test]
        public void ScrollDown_IndexIsLowerThanMaxValue_RaisesIndex()
        {
            MainMenu menu = MakeMenu();

            menu.ScrollDown();

            Assert.AreEqual(1, menu.Index);
        }

        [Test]
        public void ScrollDown_IndexIsMaxValue_SetsIndexTo0()
        {
            MainMenu menu = MakeMenu();

            menu.ScrollUp();
            menu.ScrollDown();

            Assert.AreEqual(0, menu.Index);
        }

        [Test]
        public void RaiseChosenValue_TheValueNrOfPlayersIsLowerThanMaxValue_RaisesValue()
        {
            MainMenu menu = MakeMenu();

            menu.RaiseChosenValue();

            Assert.AreEqual(2, menu.NrOfPlayers);
        }

        [Test]
        public void RaiseChosenValue_TheValueNrOfPlayersIsMaxValue_SetsValueTo1()
        {
            MainMenu menu = MakeMenu();

            menu.RaiseChosenValue();
            menu.RaiseChosenValue();

            Assert.AreEqual(1, menu.NrOfPlayers);
        }

        [Test]
        public void LowerChosenValue_TheValueNrOfPlayersIsHigherThanMinValue_LowerValue()
        {
            MainMenu menu = MakeMenu();

            menu.RaiseChosenValue();
            menu.LowerChosenValue();

            Assert.AreEqual(1, menu.NrOfPlayers);
        }

        [Test]
        public void LowerChosenValue_TheValueNrOfPlayersIsMinValue_SetsValueTo2()
        {
            MainMenu menu = MakeMenu();

            menu.LowerChosenValue();

            Assert.AreEqual(2, menu.NrOfPlayers);
        }
    }

    // ReSharper restore InconsistentNaming
}