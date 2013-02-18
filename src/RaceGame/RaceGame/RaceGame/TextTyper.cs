using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace RaceGame
{
    public class TextTyper : ITextTyper
    {
        private string _textString = string.Empty;
        private KeyboardState oldKeyboardState;

        public KeyboardState SetKeyboardState { get; set; }

        public TextTyper()
        {
            oldKeyboardState = Keyboard.GetState();
        }

        public string GetText()
        {
            return _textString;
        }

        public void Update()
        {
            KeyboardState newKeyboardState = Keyboard.GetState();

            if (SetKeyboardState != null)
                newKeyboardState = SetKeyboardState;

            Keys[] pressedKeys = newKeyboardState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (oldKeyboardState.IsKeyUp(key))
                {
                    if (key == Keys.Back && !_textString.Equals(string.Empty))
                        _textString = _textString.Remove(_textString.Length - 1, 1);
                    else if (key == Keys.Space)
                        _textString += " ";
                    else
                    {
                        if(ValidKey(key))
                        _textString += key.ToString().ToUpper();
                    }
                }
            }

            oldKeyboardState = newKeyboardState;
        }

        private bool ValidKey(Keys key)
        {
            return (key.ToString().ToUpper().Length == 1);
        }
    }
}
