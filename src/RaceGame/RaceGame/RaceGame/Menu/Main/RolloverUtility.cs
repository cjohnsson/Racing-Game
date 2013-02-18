using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceGame.Menu.Main
{
    public class RolloverUtility
    {
        private int _maxValue;
        private int _minValue;
        public int Value { get; private set; }

        public RolloverUtility(int value, int minValue, int maxValue)
        {
            Value = value;
            _maxValue = maxValue;
            _minValue = minValue;
        }

        public void RaiseValue()
        {
            if (Value < _maxValue)
                Value++;
            else
                Value = _minValue;
        }

        public void LowerValue()
        {
            if (Value > _minValue)
                Value--;
            else
                Value = _maxValue;
        }
    }
}
