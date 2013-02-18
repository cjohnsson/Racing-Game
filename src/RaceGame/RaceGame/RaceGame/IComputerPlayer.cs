using System.Collections.Generic;

namespace RaceGame
{
    public interface IComputerPlayer
    {
        List<Player> Players { get; set; }
        void Update();
    }
}