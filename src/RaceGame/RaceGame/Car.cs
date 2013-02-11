using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceGame
{
    public class Car
    {
        public Car()
        {
            Speed = 0;
        }

        private float _speed;
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public void Accelerate()
        {
            Speed += 0.1f;
        }
    }
}
