using Ceusters_Jitze_GameDevelopment.Game.Models.GameElements;
using Ceusters_Jitze_GameDevelopment.Game.Models.GameHero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Managers
{
    public class GameManager
    {
        private Random random = new Random();
        private readonly Map _map;
        private readonly Hero _hero;
        private readonly List<Coin> _coins = new List<Coin>();

        public GameManager()
        {
            _map = new();
            _hero = new(new(500,500));

            
        }

        public void Reset()
        {
            _coins.Clear();
            for (int i = 1; i < 20; i++)
            {
                var random_Y = random.Next((int)_hero._minPos.Y, (int)_hero._maxPos.Y);
                var random_X = random.Next((int)_hero._minPos.X, (int)_hero._maxPos.X);
                _coins.Add(new Coin(new(random_X, random_Y)));
            }

        }

        public void CheckPickupCoins()
        {
            foreach (var coin in _coins.ToArray())
            {
                if (_hero.Rectangle.Intersects(coin.Rectangle))
                {
                    _coins.Remove(coin);
                    _hero.CollectCoins();
                }
            }
        }

        public void Update()
        {
            InputManager.Update();
            _hero.Update();
            CheckPickupCoins();
            foreach (var coin in _coins) coin.Update();
        }

        public void Draw()
        {
            _map.Draw();
            _hero.Draw();
            foreach (var coin in _coins) coin.Draw();
        }
    }
}
