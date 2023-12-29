using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Models.GameElements
{
    public class Coin
    {
        private static Texture2D _texture;
        private Vector2 _position;
        private readonly Animation.Animation _anim;

        public Rectangle Rectangle => new((int)_position.X, (int)_position.Y, _texture.Width / 4, _texture.Height);

        public Animation.Animation Anim => _anim;

        public Coin(Vector2 position)
        {
            _texture ??= Globals.Content.Load<Texture2D>("Game/GameElements/coin");
            _anim = new(_texture, 6, 1, 0.1f);
            _position = position;
        }

        public void Update()
        {
            Anim.Update();
        }

        public void Draw()
        {
            Anim.Draw(_position, Vector2.One);
        }
    }
}
