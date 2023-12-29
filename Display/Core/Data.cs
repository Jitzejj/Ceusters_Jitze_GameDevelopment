using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Display.Core
{
    public class Data
    {
        public static bool Exit { get; set; } = false;
        public enum Scenes { Menu, Level, GameOver, Game1,Game2}
        public static Scenes CurrentScene { get; set; } = Scenes.Menu;
    }
}
