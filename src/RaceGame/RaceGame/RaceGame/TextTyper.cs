using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace RaceGame
{
    public static class TextTyper
    {
        private static string _textString = string.Empty;
        private static KeyboardState _oldKeyboardState = Keyboard.GetState();
        public static KeyboardState SetKeyboardState { get; set; }
        public static bool FinishedTyping { get; set; }

        public static string GetText()
        {
            return _textString;
        }

        public static void Update()
        {
            KeyboardState newKeyboardState = Keyboard.GetState();

            if (SetKeyboardState.GetPressedKeys().Length > 0)
                newKeyboardState = SetKeyboardState;

            Keys[] pressedKeys = newKeyboardState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (_oldKeyboardState.IsKeyUp(key))
                {
                    if (key == Keys.Back && !_textString.Equals(string.Empty))
                        _textString = _textString.Remove(_textString.Length - 1, 1);
                    else if (key == Keys.Space)
                        _textString += " ";
                    else if (key == Keys.Enter)
                        FinishedTyping = true;
                    else
                    {
                        if (ValidKey(key))
                            _textString += key.ToString().ToUpper();
                    }
                }
            }

            _oldKeyboardState = newKeyboardState;
        }

        private static bool ValidKey(Keys key)
        {
            return (key.ToString().ToUpper().Length == 1);
        }
    }
}
