using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceGame
{
    interface IGameTime
    {
        TimeSpan GetElapsedTime();
        void Pause();
        void Resume();
        void Reset();
    }
}
