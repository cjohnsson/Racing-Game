using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
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
            Texture2D[] textures = new Texture2D[3];
            textures[0] = null;
            textures[1] = null;
            textures[2] = null;
            return new Menu(null, textures );
        }

        [Test]
        public void ScrollUp_IndexIsGreaterThan0_DecreasesIndex()
        {
            Menu menu = MakeMenu();

            menu.ScrollDown();
            menu.ScrollUp();

            Assert.AreEqual(0,menu.Index);
        }

        [Test]
        public void ScrollUp_IndexIs0_SetsIndexToMaxValue()
        {
            Menu menu = MakeMenu();

            menu.ScrollUp();

            Assert.AreEqual(2,menu.Index);
        }

        [Test]
        public void ScrollDown_IndexIsLowerThanMaxValue_RaisesIndex()
        {
            Menu menu = MakeMenu();

            menu.ScrollDown();

            Assert.AreEqual(1,menu.Index);
        }

        [Test]
        public void ScrollDown_IndexIsMaxValue_SetsIndexTo0()
        {
            Menu menu = MakeMenu();

            menu.ScrollUp();
            menu.ScrollDown();
            
            Assert.AreEqual(0,menu.Index);
        }
    }

    // ReSharper restore InconsistentNaming
}