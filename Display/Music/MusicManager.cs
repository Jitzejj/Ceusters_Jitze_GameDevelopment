using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Display.Music
{
    public class MusicManager
    {
        public Song _song;

        public string songName;
        public MusicManager(string nameSong)
        {
            songName = nameSong;
            _song = Globals.Content.Load<Song>(songName);
        }

        public void Play()
        {
            MediaPlayer.Play(_song);
        }

        public void Stop()
        {
            MediaPlayer.Stop();
        }
    }
}
