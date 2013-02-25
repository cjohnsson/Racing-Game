using Microsoft.Xna.Framework.Graphics;

namespace RaceGame.Holders
{
    public interface ITexture2DHolder
    {
        Texture2D GetTexture2D();
        int GetTexture2DWidth();
        int GetTexture2DHeight();
    }
}