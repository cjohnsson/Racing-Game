using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceGame.Menu.Main
{
    public class MainMenuItem
    {
        private string _text;
        private RolloverUtility _rolloverUtility;

        public MainMenuItem()
            : this(string.Empty)
        {

        }

        public MainMenuItem(string text)
            : this(text, null)
        {

        }

        public MainMenuItem(string text, RolloverUtility rolloverUtility)
        {
            _text = text;
            _rolloverUtility = rolloverUtility;
        }

        public void RaiseValue()
        {
            if (_rolloverUtility != null)
                _rolloverUtility.RaiseValue();
        }

        public void LowerValue()
        {
            if (_rolloverUtility != null)
                _rolloverUtility.LowerValue();
        }

        public int GetValue()
        {
            return _rolloverUtility.Value;
        }

        public override string ToString()
        {
            if (_rolloverUtility == null)
                return _text;
            return String.Format(_text, _rolloverUtility.Value);
        }

    }
}
