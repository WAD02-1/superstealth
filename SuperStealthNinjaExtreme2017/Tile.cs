using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperStealthNinjaExtreme2017
{
    public class Tile
    {
        // X & Y Coordinaten
        private Point TileCoordinate;

        public string TileType { get; set; }
        public bool IsDeadly { get; set; }
        public bool IsCollidable { get; set; }
        public Color TileColor { get; set; }

        // Tile type (Muur/niet muur, etc) (Ook meegeven in constructor)
        // 32 * 32 pixels

        public Tile(string tiletype, int x, int y)
        {
            TileType = tiletype;
            TileCoordinate.X = x;
            TileCoordinate.Y = y;

            if (tiletype == "lava")
            {
                IsDeadly = true;
                IsCollidable = false;
                TileColor = Color.OrangeRed;
            }
            else if (tiletype == "wall")
            {
                IsDeadly = false;
                IsCollidable = true;
                TileColor = Color.DarkRed;
            }
            else
            {
                IsDeadly = false;
                IsCollidable = false;
                TileColor = Color.LightGray;
            }
        }

        public int getX()
        {
            return TileCoordinate.X;
        }

        public int getY()
        {
            return TileCoordinate.Y;
        }

        public string getType()
        {
            return TileType;
        }
    }
}
