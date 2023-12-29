﻿using Ceusters_Jitze_GameDevelopment.Display.Core;
using Ceusters_Jitze_GameDevelopment.Display.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Display.Managers
{
    public class GameSceneManager : Component
    {
        private MenuScene _menuScene = new("Display/Background/GameBackground","Display/Button/knob",3);
        private LevelScene _levelScene = new("Display/Background/GameLevelBackground", "Display/Button/button", 3);
        private GameOverScene _gameOverScene = new("Display/Background/GameBackground", "Display/Button/menu", 1);

        public override void LoadContent(ContentManager Content)
        {
            _menuScene.LoadContent(Content);
            _levelScene.LoadContent(Content);
            _gameOverScene.LoadContent(Content);
        }

        public override void Update(GameTime gameTime)
        {
            switch (Data.CurrentScene)
            {
                case Data.Scenes.Menu:
                    _menuScene.Update(gameTime);
                    break;
                case Data.Scenes.Level:
                    _levelScene.Update(gameTime);
                    break;
                case Data.Scenes.GameOver:
                    _gameOverScene.Update(gameTime);
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Globals.SpriteBatch.Begin();

            switch (Data.CurrentScene)
            {
                case Data.Scenes.Menu:
                    _menuScene.Draw(spriteBatch);
                    break;
                case Data.Scenes.Level:
                    _levelScene.Draw(spriteBatch);
                    break;
                case Data.Scenes.GameOver:
                    _gameOverScene.Draw(spriteBatch);
                    break;
            }

            Globals.SpriteBatch.End();
        }
    }
}