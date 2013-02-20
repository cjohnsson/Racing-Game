using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceGame
{
    [Serializable]
    public class Score
    {
        private string _name;
        private TimeSpan _time;

        public Score(string newName, TimeSpan newTime)
        {
            _name = newName;
            _time = newTime;
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public TimeSpan Time
        {
            get { return _time; }
            private set { _time = value; }
        }
    }
}

    

