using Ceusters_Jitze_GameDevelopment.Game.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Models.GameEnemys
{
    public class GreenDragon : Sprite
    {
        private Random r = new();
        private Vector2 _direction;

        public GreenDragon(Vector2 position) : base(position)
        {
            Texture = Globals.Content.Load<Texture2D>("Spel/Vijanden/greendragonsprite");
            _am.AddAnimation(new Vector2(0, 1), new(Texture, 8, 8, 0.1f, 1));
            _am.AddAnimation(new Vector2(-1, 0), new(Texture, 8, 8, 0.1f, 2));
            _am.AddAnimation(new Vector2(1, 0), new(Texture, 8, 8, 0.1f, 3));
            _am.AddAnimation(new Vector2(0, -1), new(Texture, 8, 8, 0.1f, 4));
            _am.AddAnimation(new Vector2(-1, 1), new(Texture, 8, 8, 0.1f, 5));
            _am.AddAnimation(new Vector2(-1, -1), new(Texture, 8, 8, 0.1f, 6));
            _am.AddAnimation(new Vector2(1, 1), new(Texture, 8, 8, 0.1f, 7));
            _am.AddAnimation(new Vector2(1, -1), new(Texture, 8, 8, 0.1f, 8));

            Position = position;
            BeginDirection();

        }

        public override void Update()
        {
            Position += _direction * Globals.Time * 100;

            DirectionUpdate();

            _am.Update(_direction);
        }

        public void BeginDirection()
        {
            _direction.X--;
        }



        public void DirectionUpdate()
        {
            SetBound();
            if (Position.X >= 1800)
                _direction.X--;
            else if (Position.X <= 0)
                _direction.X++;
        }
    }
}
