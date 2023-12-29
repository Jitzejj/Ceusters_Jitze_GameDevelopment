using Ceusters_Jitze_GameDevelopment.Display.Core;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Display.Graphics
{
    public class SceneSprite : Component
    {
        public Texture2D[] _buttons;
        public Rectangle[] _rectangles;

        //Interaction
        public MouseState _mouseState, _oldMouseState;
        public Rectangle _mouseRectangle;

        //Extra
        private Texture2D BackgroundTexture;
        private string _backgroundName;
        private string _buttonName;

        public SceneSprite(string buttonName, string backgroundName, int number)
        {
            _backgroundName = backgroundName;
            _buttonName = buttonName;
            _buttons = new Texture2D[number];
            _rectangles = new Rectangle[number];
        }

        public override void LoadContent(ContentManager Content)
        {
            BackgroundTexture = Content.Load<Texture2D>($"{_backgroundName}");
            const int INCREMENT_VALUE = 125;
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i] = Content.Load<Texture2D>($"{_buttonName} {i}");
                _rectangles[i] = new Rectangle(725, 270 + (INCREMENT_VALUE * i), _buttons[i].Width / 2, _buttons[i].Height / 2);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _oldMouseState = _mouseState;
            _mouseState = Mouse.GetState();
            _mouseRectangle = new Rectangle(_mouseState.X, _mouseState.Y, 1, 1);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundTexture, new Vector2(0, 0), Color.White);

            for (int i = 0; i < _buttons.Length; i++)
            {
                spriteBatch.Draw(_buttons[i], _rectangles[i], Color.White);
                if (_mouseRectangle.Intersects(_rectangles[i]))
                {
                    spriteBatch.Draw(_buttons[i], _rectangles[i], Color.Gray);
                }
            }
        }
    }
}
