using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceGame
{
    class MainMenu
    {
        public int Index { get; private set; }
        private int nr_of_buttons;

        public void ScrollUp()
        {
            if (Index > 0)
                Index--;
            else if (Index <= 0)
            {
                Index = nr_of_buttons - 1;
            }
        }

        public void ScrollDown()
        {
            if (Index < nr_of_buttons - 1)
                Index++;
            else if (Index >= nr_of_buttons - 1)
            {
                Index = 0;
            }
        }
    }
}
