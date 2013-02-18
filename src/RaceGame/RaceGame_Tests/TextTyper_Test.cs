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
            TextTyper textTyper = new TextTyper();

            Assert.That(textTyper.GetText(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Update_KeyAIsDown_AddsAToText() 
        {
            //Arrange
            TextTyper textTyper = new TextTyper();
            KeyboardState fakeKeyboardState = new KeyboardState(Keys.A);
            textTyper.SetKeyboardState = fakeKeyboardState;

            //Act
            textTyper.Update();
            
            //Assert
            var result = textTyper.GetText();
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void Update_MultipleKeysAreDown_AddsValuesThatKeysRepresentToText()
        {
            //Arrange
            TextTyper textTyper = new TextTyper();
            KeyboardState fakeKeyboardState = new KeyboardState(Keys.A,Keys.P);
            textTyper.SetKeyboardState = fakeKeyboardState;

            //Act
            textTyper.Update();

            //Assert
            var result = textTyper.GetText();
            Assert.That(result, Is.EqualTo("AP"));
        }

        [Test]
        public void Update_BackspaceKeyIsDownAndTextStringIsEmpty_DoNothing() 
        {
            //Arrange
            TextTyper textTyper = new TextTyper();
            KeyboardState fakeKeyboardState = new KeyboardState(Keys.Back);
            textTyper.SetKeyboardState = fakeKeyboardState;

            //Act
            textTyper.Update();

            //Assert
            var result = textTyper.GetText();
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Update_BackspaceKeyIsDownAndTextStringIsNotEmpty_RemoveLastLetterInTextString()
        {
            //Arrange
            TextTyper textTyper = new TextTyper();

            KeyboardState fakeKeyboardState = new KeyboardState(Keys.A);
            textTyper.SetKeyboardState = fakeKeyboardState;
            textTyper.Update();

            fakeKeyboardState = new KeyboardState(Keys.Back);
            textTyper.SetKeyboardState = fakeKeyboardState;

            //Act
            textTyper.Update();

            //Assert
            var result = textTyper.GetText();
            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}
