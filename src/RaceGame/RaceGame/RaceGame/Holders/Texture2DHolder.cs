using Microsoft.Xna.Framework.Graphics;

namespace RaceGame.Holders
{
    public class Texture2DHolder : ITexture2DHolder
    {
        private Texture2D _texture2D;

        public Texture2DHolder(Texture2D texture2D)
        {
            _texture2D = texture2D;
        }

        public Texture2D GetTexture2D()
        {
            if (_texture2D == null)
                throw new Texture2DIsNullException();
            return _texture2D;
        }

        public int GetTexture2DWidth()
        {
            if (_texture2D == null)
                throw new Texture2DIsNullException();
            return _texture2D.Bounds.Width;
        }

        public int GetTexture2DHeight()
        {
            if (_texture2D == null)
                throw new Texture2DIsNullException();
            return _texture2D.Bounds.Height;
        }
    }
}