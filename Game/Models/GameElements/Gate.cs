using Ceusters_Jitze_GameDevelopment.Game.Graphics;
using Ceusters_Jitze_GameDevelopment.Game.Models.GameHero;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Models.GameElements
{
    public class Gate : TileSprite
    {
        private readonly Texture2D _open;
        private readonly int _coins;

        public Gate(Texture2D closed, Texture2D open, Vector2 pos, int coins, Hero hero) : base(closed, pos)
        {
            _open = open;
            _coins = coins;
        }

        public void UpdateGate()
        {
            Texture = _open;
        }
    }
}
