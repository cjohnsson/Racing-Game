using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RaceGame;
using Microsoft.Xna.Framework.Input;

namespace RaceGame_Tests
{
    [TestFixture]
    class TextTyper_Test
    {
        [Test]
        public void GetText_DefaultValue_ReturnsEmptyString() 
        {
            //Arrange

            //Act
            var result = TextTyper.GetText();

            //Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Update_KeyAIsDown_AddsAToText() 
        {
            //Arrange
            KeyboardState fakeKeyboardState = new KeyboardState(Keys.A);
            TextTyper.SetKeyboardState = fakeKeyboardState;

            //Act
            TextTyper.Update();
            
            //Assert
            var result = TextTyper.GetText();
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void Update_MultipleKeysAreDown_AddsValuesThatKeysRepresentToText()
        {
            //Arrange
            KeyboardState fakeKeyboardState = new KeyboardState(Keys.A,Keys.P);
            TextTyper.SetKeyboardState = fakeKeyboardState;

            //Act
            TextTyper.Update();

            //Assert
            var result = TextTyper.GetText();
            Assert.That(result, Is.EqualTo("AP"));
        }

        [Test]
        public void Update_BackspaceKeyIsDownAndTextStringIsEmpty_DoNothing() 
        {
            //Arrange
            KeyboardState fakeKeyboardState = new KeyboardState(Keys.Back);
            TextTyper.SetKeyboardState = fakeKeyboardState;

            //Act
            TextTyper.Update();

            //Assert
            var result = TextTyper.GetText();
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Update_BackspaceKeyIsDownAndTextStringIsNotEmpty_RemoveLastLetterInTextString()
        {
            //Arrange
            KeyboardState fakeKeyboardState = new KeyboardState(Keys.A);
            TextTyper.SetKeyboardState = fakeKeyboardState;
            TextTyper.Update();

            fakeKeyboardState = new KeyboardState(Keys.Back);
            TextTyper.SetKeyboardState = fakeKeyboardState;

            //Act
            TextTyper.Update();

            //Assert
            var result = TextTyper.GetText();
            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}
