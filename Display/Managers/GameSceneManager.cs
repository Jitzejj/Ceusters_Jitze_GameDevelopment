﻿using Ceusters_Jitze_GameDevelopment.Display.Core;
using Ceusters_Jitze_GameDevelopment.Display.Music;
using Ceusters_Jitze_GameDevelopment.Display.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Display.Managers
{
    public class GameSceneManager : Component
    {
        private MenuScene _menuScene = new("Display/Button/knob","Display/Background/MenuTexture", 3);
        private LevelScene _levelScene = new("Display/Button/button", "Display/Background/LevelTexture", 3);
        private GameOverScene _gameOverScene = new("Display/Button/menu","Display/Background/GameOverTexture", 1);
        private VictoryScene _victoryScene = new("Display/Button/menu", "Display/Background/EndTexture", 1);
        private GameScene _gameScene1 = new(1,"Game/GameElements/TileLevel1");
        private GameScene _gameScene2 = new(3,"Game/GameElements/TileLevel2");

        public override void LoadContent(ContentManager Content)
        {
            _menuScene.LoadContent(Content);
            _levelScene.LoadContent(Content);
            _gameOverScene.LoadContent(Content);
            _gameScene1.LoadContent(Content);
            _gameScene2.LoadContent(Content);
            _victoryScene.LoadContent(Content);
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
                case Data.Scenes.Game1:
                    _gameScene1.Update(gameTime);
                    break;
                case Data.Scenes.Game2:
                    _gameScene2.Update(gameTime);
                    break;
                case Data.Scenes.Victory:
                    _victoryScene.Update(gameTime);
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
                case Data.Scenes.Game1:
                    _gameScene1.Draw(spriteBatch);
                    break;
                case Data.Scenes.Game2:
                    _gameScene2.Draw(spriteBatch);
                    break;
                case Data.Scenes.Victory:
                    _victoryScene.Draw(spriteBatch);
                    break;
            }

            Globals.SpriteBatch.End();
        }
    }
}
