using Ceusters_Jitze_GameDevelopment.Game.Graphics;
using Ceusters_Jitze_GameDevelopment.Game.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Models.GameHero
{
    public class Hero : Sprite
    {
        private readonly float Speed = 300f;

        public int _coins { get; set; }
        public Hero(Vector2 position) : base(position)
        {
            Texture = Globals.Content.Load<Texture2D>("Spel/Hero/herosprite");
            _am.AddAnimation(new Vector2(0, 1), new(Texture, 8, 8, 0.1f, 1));
            _am.AddAnimation(new Vector2(-1, 0), new(Texture, 8, 8, 0.1f, 2));
            _am.AddAnimation(new Vector2(1, 0), new(Texture, 8, 8, 0.1f, 3));
            _am.AddAnimation(new Vector2(0, -1), new(Texture, 8, 8, 0.1f, 4));
            _am.AddAnimation(new Vector2(-1, 1), new(Texture, 8, 8, 0.1f, 5));
            _am.AddAnimation(new Vector2(-1, -1), new(Texture, 8, 8, 0.1f, 6));
            _am.AddAnimation(new Vector2(1, 1), new(Texture, 8, 8, 0.1f, 7));
            _am.AddAnimation(new Vector2(1, -1), new(Texture, 8, 8, 0.1f, 8));

            Origin = new(Texture.Width / 2, Texture.Height / 2);
            Position = position;
        }

        public void CollectCoins()
        {
            _coins++;
        }

        public override void Update()
        {
            if (InputManager.Moving)
            {
                Position += Vector2.Normalize(InputManager.Direction) * Speed * Globals.Time;

                Position = Vector2.Clamp(Position, _minPos, _maxPos);

                _am.Update(InputManager.Direction);

            }
        }

    }
}
