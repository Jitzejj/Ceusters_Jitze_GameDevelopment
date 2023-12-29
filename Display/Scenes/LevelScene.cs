using Ceusters_Jitze_GameDevelopment.Display.Core;
using Ceusters_Jitze_GameDevelopment.Display.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Display.Scenes
{
    public class LevelScene : SceneSprite
    {
        public LevelScene(string buttonName,string backgroundName, int number) : base(buttonName, backgroundName, number)
        {
        }

        public override async void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (_mouseState.LeftButton == ButtonState.Pressed && _mouseRectangle.Intersects(_rectangles[0]))
            {
                await Task.Delay(200);
                Data.CurrentScene = Data.Scenes.Game;
            }
            else if (_mouseState.LeftButton == ButtonState.Pressed && _mouseRectangle.Intersects(_rectangles[1]))
            {
                await Task.Delay(200);
                Data.CurrentScene = Data.Scenes.Game;
            }
            else if (_mouseState.LeftButton == ButtonState.Pressed && _mouseRectangle.Intersects(_rectangles[2]))
            {
                await Task.Delay(200);
                Data.CurrentScene = Data.Scenes.Menu;
            }
        }
    }
}
