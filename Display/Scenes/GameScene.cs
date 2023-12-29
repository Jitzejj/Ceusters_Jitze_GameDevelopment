using Ceusters_Jitze_GameDevelopment.Display.Core;
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
        private int numberEnemys;
        private int counter = 0;

        public GameScene(int numberEnemys)
        {
            this.numberEnemys = numberEnemys;
        }

        public override void LoadContent(ContentManager Content)
        {
            _gameManager = new(numberEnemys, numberEnemys, numberEnemys);
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
                Reset();
                _gameManager.NextLevel = false;
            }

            if(counter == 4)
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
            _gameManager = new(numberEnemys, numberEnemys, numberEnemys);
        }
    }
}
