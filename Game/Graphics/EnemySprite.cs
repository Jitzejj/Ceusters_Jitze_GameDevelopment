using Ceusters_Jitze_GameDevelopment.Game.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Graphics
{
    public abstract class EnemySprite : Sprite, EnemysInterface
    {
        public Random r = new();
        public Vector2 _direction;
        public EnemySprite(Vector2 postion) : base(postion)
        {
            Position = postion;
            BeginDirection();
        }
        public abstract void BeginDirection();
        public abstract void DirectionUpdate();
        
        
    }
}
