using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Graphics
{
    public class TileSprite
    {
        protected Texture2D Texture;
        public Vector2 Position { get; protected set; }
        public Vector2 Origin { get; protected set; }

        public Rectangle Rectangle => new((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        public TileSprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            Origin = new(Texture.Width / 2, Texture.Height / 2);
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
