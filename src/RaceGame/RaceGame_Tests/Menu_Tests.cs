using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RaceGame;


namespace RaceGame_Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class Menu_Tests
    {
        private Menu MakeMenu()
        {
            return new Menu(null, null);
        }

        [Test]
        public void ScrollUp_IndexIsGreaterThan0_DecreasesIndex()
        {
            Menu menu = MakeMenu();

            menu.ScrollUp();
        }

        [Test]
        public void ScrollUp_IndexIs0_SetsIndexToMaxValue()
        {
            Menu menu = MakeMenu();
        }

        [Test]
        public void ScrollDown_IndexIsLowerThanMaxValue_RaisesIndex()
        {
            Menu menu = MakeMenu();
        }

        [Test]
        public void ScrollDown_IndexIsMaxValue_SetsIndexTo0()
        {
            Menu menu = MakeMenu();
        }
    }

    // ReSharper restore InconsistentNaming
}