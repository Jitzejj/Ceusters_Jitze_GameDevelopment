using Ceusters_Jitze_GameDevelopment.Display.Core;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceusters_Jitze_GameDevelopment.Display.Graphics;
using Ceusters_Jitze_GameDevelopment.Display.Music;

namespace Ceusters_Jitze_GameDevelopment.Display.Scenes
{
    public class VictoryScene : SceneSprite
    {
        public MusicManager menuMusic = new MusicManager("Display/Sound/MedievalMusic");
        public VictoryScene(string buttonName, string backgroundName, int number) : base(buttonName, backgroundName, number)
        {
            menuMusic.Play();
        }

        public override async void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (_mouseState.LeftButton == ButtonState.Pressed && _mouseRectangle.Intersects(_rectangles[0]))
            {
                await Task.Delay(200);
                Data.CurrentScene = Data.Scenes.Menu;
            }
        }
    }
}
