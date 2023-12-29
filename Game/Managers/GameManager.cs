using Ceusters_Jitze_GameDevelopment.Game.Models.GameElements;
using Ceusters_Jitze_GameDevelopment.Game.Models.GameEnemys;
using Ceusters_Jitze_GameDevelopment.Game.Models.GameHero;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
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

        //GameElements
        private readonly Map _map;
        private readonly List<Coin> _coins = new List<Coin>();
        private Gate _gate;
        private readonly Texture2D _closegate;
        private readonly Texture2D _opengate;

        //GameHero
        private readonly Hero _hero;

        //GameEnemys
        private readonly List<RedDragon> _redDragons = new List<RedDragon>();
        private readonly List<GreenDragon> _greenDragons = new List<GreenDragon>();
        private readonly List<Knight> _knights = new List<Knight>();

        //Extra
        public bool NextLevel { get; set; } = false;
        public bool GameOver { get; set; } = false;
        private int posX;
        private int posY;


        public GameManager(int green, int red, int knight)
        {
            _closegate = Globals.Content.Load<Texture2D>("");
            _opengate = Globals.Content.Load<Texture2D>("");

            _map = new();
            _hero = new(new(500,500));
            Reset();

            for (int i = 0; i < green; i++)
            {
                posX = random.Next(0, 1000);
                posY = random.Next(0, 1000);
                _greenDragons.Add(new GreenDragon(new(posX, posY)));
            }

            for (int i = 0; i < red; i++)
            {
                posX = random.Next(0, 1000);
                posY = random.Next(0, 1000);
                _redDragons.Add(new RedDragon(new(posX, posY)));
            }

            for (int i = 0; i < knight; i++)
            {
                posX = random.Next(0, 1000);
                posY = random.Next(0, 1000);
                _knights.Add(new Knight(new(posX, posY)));
            }
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
            _gate = new(_closegate, _opengate, new(320, 400), 2, _hero);
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

        public void CheckCollision()
        {
            foreach (var redDragon in _redDragons)
            {
                if (_hero.Rectangle.Intersects(redDragon.Rectangle))
                    GameOver = true;
            }
            foreach (var greenDragon in _greenDragons)
            {
                if (_hero.Rectangle.Intersects(greenDragon.Rectangle))
                    GameOver = true;
            }
            foreach (var knight in _knights)
            {
                if (_hero.Rectangle.Intersects(knight.Rectangle))
                    GameOver = true;
            }
        }

        public void Update()
        {
            InputManager.Update();
            _hero.Update();
            CheckPickupCoins();
            CheckCollision();
            foreach (var coin in _coins) coin.Update();
            foreach (var redDragon in _redDragons) redDragon.Update();
            foreach (var greenDragon in _greenDragons) greenDragon.Update();
            foreach (var knight in _knights) knight.Update(_hero);

            if (_hero._coins > 18)
            {
                _gate.UpdateGate();

                if (_hero.Rectangle.Intersects(_gate.Rectangle))
                {
                    NextLevel = true;
                }
            }
        }

        public void Draw()
        {
            _map.Draw();
            _hero.Draw();
            foreach (var coin in _coins) coin.Draw();
            foreach (var redDragon in _redDragons) redDragon.Draw();
            foreach (var greenDragon in _greenDragons) greenDragon.Draw();
            foreach (var knight in _knights) knight.Draw();
            _gate.Draw();
        }
    }
}
