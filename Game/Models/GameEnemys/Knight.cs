﻿using Ceusters_Jitze_GameDevelopment.Game.Graphics;
using Ceusters_Jitze_GameDevelopment.Game.Models.GameHero;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Models.GameEnemys
{
    public class Knight : EnemySprite
    {
        public Knight(Vector2 position) : base(position)
        {
            Texture = Globals.Content.Load<Texture2D>("Game/GameEnemys/knitesprite");
            _am.AddAnimation(new Vector2(0, 1), new(Texture, 8, 8, 0.1f, 1));
            _am.AddAnimation(new Vector2(-1, 0), new(Texture, 8, 8, 0.1f, 2));
            _am.AddAnimation(new Vector2(1, 0), new(Texture, 8, 8, 0.1f, 3));
            _am.AddAnimation(new Vector2(0, -1), new(Texture, 8, 8, 0.1f, 4));
        }

        public void Update(Hero hero)
        {
            var toPlayer = hero.Position - Position;
            _am.Update(_direction);
            if (toPlayer.Length() > 4)
            {
                var dir = Vector2.Normalize(toPlayer);
                Position += dir * 100 * Globals.Time;
            }
            _am.Update(_direction);
        }

        public override void BeginDirection()
        {
            _direction.X++;
        }

        public override void DirectionUpdate()
        {
            
        }
    }
}
