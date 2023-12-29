﻿using Ceusters_Jitze_GameDevelopment.Display.Core;
using Ceusters_Jitze_GameDevelopment.Game.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Display.Scenes
{
    public class GameScene : Component
    {
        private GameManager _gameManager;
        private int red = 1;
        private int green = 1;
        private int knight = 1;
        private int counter = 0;

        public override void LoadContent(ContentManager Content)
        {
            _gameManager = new(green, red, knight);
        }

        public override void Update(GameTime gameTime)
        {
            _gameManager.Update();

            if(_gameManager.GameOver)
            {
                Data.CurrentScene = Data.Scenes.GameOver;
                counter = 0;
                Reset();
                _gameManager.GameOver = false;
            }

            if(_gameManager.NextLevel)
            {
                counter++;
                _gameManager = new(green, red, knight);
                _gameManager.NextLevel = false;
            }

            if(counter == 2)
            {
                Data.CurrentScene = Data.Scenes.Menu;
                counter = 0;
            } 
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _gameManager.Draw();
        }

        public void Reset()
        {
            _gameManager = new(1, 1, 1);
        }
    }
}
