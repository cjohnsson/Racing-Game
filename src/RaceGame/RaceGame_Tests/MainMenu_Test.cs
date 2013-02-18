using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RaceGame.Menu;

namespace RaceGame_Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class Menu_Test
    {
        private MenuItem[] MakeMenuItems()
        {
            MenuItem[] menuItems = new MenuItem[4];
            menuItems[0] = new MenuItem("Number of players: {0}", new RolloverUtility(1, 1, 2));
            menuItems[1] = new MenuItem("Number of bots: {0}", new RolloverUtility(2, 0, 2));
            menuItems[2] = new MenuItem("Selected map: {0}", new RolloverUtility(0, 0, 3));
            menuItems[3] = new MenuItem("Number of laps: {0}", new RolloverUtility(1, 1, 9));
            return menuItems;
        }

        private GeneralMenu MakeMenu()
        {

            return new GeneralMenu(MakeMenuItems());
        }

        [Test]
        public void ScrollUp_IndexIsGreaterThan0_DecreasesIndex()
        {
            var menu = MakeMenu();

            menu.ScrollDown();
            menu.ScrollUp();

            int result = menu.SelectedMenuItem.GetValue();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ScrollUp_IndexIs0_SetsIndexToMaxValue()
        {
            var menu = MakeMenu();

            menu.ScrollUp();

            int result = menu.SelectedMenuItem.GetValue();
            Assert.AreEqual(4, result);
        }

        [Test]
        public void ScrollDown_IndexIsLowerThanMaxValue_RaisesIndex()
        {
            var menu = MakeMenu();

            menu.ScrollDown();

            int result = menu.SelectedMenuItem.GetValue();
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ScrollDown_IndexIsMaxValue_SetsIndexTo0()
        {
            var menu = MakeMenu();

            menu.ScrollUp();
            menu.ScrollDown();

            int result = menu.SelectedMenuItem.GetValue();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RaiseChosenValue_TheValueNrOfPlayersIsHigherThanTheMaximumValue_RaiseValue()
        {
            var menu = MakeMenu();

            menu.RaiseSelectedValue();


            int result = menu.NrOfPlayers;
            Assert.AreEqual(2, result);
        }

        [Test]
        public void RaiseChosenValue_TheValueNrOfPlayersIsTheMaximumValue_SetsNrOfPlayersValueToTheMinimumValue()
        {
            var menu = MakeMenu();

            menu.RaiseSelectedValue();
            menu.RaiseSelectedValue();

            int result = menu.NrOfPlayers;
            Assert.AreEqual(1, result);
        }

        [Test]
        public void LowerChosenValue_TheValueOfNrOfPlayersIsHigherThanItsMinimumValue_LowerValue()
        {
            var menu = MakeMenu();

            menu.RaiseSelectedValue();
            menu.LowerSelectedValue();

            int result = menu.NrOfPlayers;
            Assert.AreEqual(1, result);
        }

        [Test]
        public void LowerChosenValue_TheValueOfNrOfPlayersIsEqualToItsMinimumValue_SetsNrOfPlayersToItsMaximumValue()
        {
            var menu = MakeMenu();

            menu.LowerSelectedValue();

            int result = menu.NrOfPlayers;
            Assert.AreEqual(2, result);
        }
    }

    // ReSharper restore InconsistentNaming
}