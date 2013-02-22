using Microsoft.Xna.Framework.Graphics;
using RaceGame.Holders;

namespace RaceGame_Tests.Holders
{
    class StubTexture2DHolder: ITexture2DHolder
    {
        public Texture2D GetTexture2D()
        {
            return null;
        }

        public int GetTexture2DWidth()
        {
            return 20;
        }

        public int GetTexture2DHeight()
        {
            return 10;
        }
    }
}
