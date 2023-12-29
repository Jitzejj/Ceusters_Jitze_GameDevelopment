using Ceusters_Jitze_GameDevelopment.Game.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Graphics
{
    public class Sprite
    {
        public Vector2 Position { get; protected set; }
        public readonly AnimationManager _am = new();
        public Texture2D Texture;
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width / 14, Texture.Height / 18);
        public Vector2 _minPos, _maxPos;

        public Vector2 Origin { get; protected set; }

        public Sprite(Vector2 postion)
        {
        }

        public virtual void Update()
        {
        }

        public void Draw()
        {
            _am.Draw(Position, Vector2.One);
        }

        public void SetBound()
        {
            _minPos = new(0, 0);
            _maxPos = new(1800, 900);
        }
    }
}
