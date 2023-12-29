using Ceusters_Jitze_GameDevelopment.Game.Animation;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Managers
{
    public class AnimationManager
    {
        private readonly Dictionary<object, Animation.Animation> _anims = new();
        private object _lastKey;

        public void AddAnimation(object key, Animation.Animation animation)
        {
            _anims.Add(key, animation);
            _lastKey ??= key;
        }

        public void Update(object key)
        {
            if (_anims.TryGetValue(key, out Animation.Animation value))
            {
                value.Start();
                _anims[key].Update();
                _lastKey = key;
            }
            else
            {
                _anims[_lastKey].Stop();
                _anims[_lastKey].Reset();
            }
        }

        public void Draw(Vector2 position, Vector2 origin)
        {
            _anims[_lastKey].Draw(position, origin);
        }
    }
}
