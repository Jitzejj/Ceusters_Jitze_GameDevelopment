using Ceusters_Jitze_GameDevelopment.Game.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceusters_Jitze_GameDevelopment.Game.Models.GameElements
{
    public class Map
    {
        private readonly Point _mapTileSize = new(8, 5);
        private readonly TileSprite[,] _tiles;
        
        public Point TileSize { get; private set; }
        public Point MapSize { get; private set; }

        public Map(string textureName)
        {
            _tiles = new TileSprite[_mapTileSize.X, _mapTileSize.Y];
            
            List<Texture2D> textures = new(4);
            for (int i = 1; i <= 4; i++) { textures.Add(Globals.Content.Load<Texture2D>($"{textureName}")); }

            TileSize = new(textures[0].Width, textures[0].Height);
            MapSize = new(TileSize.X * _mapTileSize.X, TileSize.Y * _mapTileSize.Y);

            Random r = new();

            for (int y = 0; y < _mapTileSize.Y; y++)
            {
                for (int x = 0; x < _mapTileSize.X; x++)
                {
                    int random = r.Next(0, textures.Count);
                    _tiles[x, y] = new(textures[random], new(x * TileSize.X, y * TileSize.Y));
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < _mapTileSize.Y; y++)
            {
                for (int x = 0; x < _mapTileSize.X; x++) _tiles[x, y].Draw();
            }
        }
    }
}
