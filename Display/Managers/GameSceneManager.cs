using Ceusters_Jitze_GameDevelopment.Display.Core;
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
        private MenuScene _menuScene = new("Display/Button/knob","Display/Background/GameBackground", 3);
        private LevelScene _levelScene = new("Display/Button/button", "Display/Background/GameLevelBackground", 3);
        private GameOverScene _gameOverScene = new("Display/Button/menu","Display/Background/GameBackground", 1);
        private GameScene _gameScene = new();
        public override void LoadContent(ContentManager Content)
        {
            _menuScene.LoadContent(Content);
            _levelScene.LoadContent(Content);
            _gameOverScene.LoadContent(Content);
            _gameScene.LoadContent(Content);
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
                case Data.Scenes.Game:
                    _gameScene.Update(gameTime);
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
                case Data.Scenes.Game:
                    _gameScene.Draw(spriteBatch);
                    break;
            }

            Globals.SpriteBatch.End();
        }
    }
}
