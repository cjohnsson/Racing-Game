using System.Collections.Generic;

namespace RaceGame
{
    public interface IComputerPlayersAI
    {
        List<Player> ComputerPlayers { get; set; }
        void Update();
    }
}