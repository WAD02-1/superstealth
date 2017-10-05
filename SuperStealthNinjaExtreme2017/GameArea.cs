using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperStealthNinjaExtreme2017
{
    public class GameArea
    {
        public static List<Tile> gamearea { get; private set; }
        public List<Tile> XmlList { get; private set; }

        public GameArea()
        {
            gamearea = new List<Tile>();

            // Fill Xml list 
            // !! TEMPORARY !!
            XmlList = new List<Tile>();

            for (int Y = 0; Y < 24; Y++)
            {
                XmlList.Add(new Tile("wall", 0, Y));
                XmlList.Add(new Tile("lava", 1, Y));
                XmlList.Add(new Tile("lava", 2, Y));
                XmlList.Add(new Tile("lava", 3, Y));
                XmlList.Add(new Tile("lava", 4, Y));
            }

            for (int Y = 0; Y < 24; Y++)
            {
                XmlList.Add(new Tile("wall", 21, Y));
            }

            XmlList.Add(new Tile("wall", 15,10));
            XmlList.Add(new Tile("wall", 16, 10));
            XmlList.Add(new Tile("wall", 17, 10));
            XmlList.Add(new Tile("wall", 18, 10));
            XmlList.Add(new Tile("wall", 19, 10));
            XmlList.Add(new Tile("wall", 20, 10));

            XmlList.Add(new Tile("wall", 15, 12));
            XmlList.Add(new Tile("wall", 16, 12));
            XmlList.Add(new Tile("wall", 17, 12));
            XmlList.Add(new Tile("wall", 18, 12));
            XmlList.Add(new Tile("wall", 19, 12));
            

            XmlList.Add(new Tile("wall", 15, 14));
            XmlList.Add(new Tile("wall", 16, 14));
            XmlList.Add(new Tile("wall", 17, 14));
            XmlList.Add(new Tile("wall", 18, 14));
            XmlList.Add(new Tile("wall", 19, 14));
            XmlList.Add(new Tile("wall", 20, 14));

            int x = 0;
            int y = 0;

            // fill gamearea with tiles
            while (gamearea.Count < 525)
            {
                Tile TempTile = new Tile("concrete", x, y);

                if ( !gamearea.Contains(TempTile) )
                {
                    gamearea.Add(TempTile);
                }

                if (y < 24)
                {
                    y++;
                }
                else
                {
                    x++;
                    y = 0;
                }
            }



            // Replace default tile with special tile
            foreach (Tile xmlTile in XmlList)
            {
                gamearea.Add(xmlTile);
            }


        }

        public static string GetTileType(int x, int y)
        {
            if (!(x < 20) && !(y < 24)) return null;

            Tile TempTile = new Tile("", x, y);

            foreach (Tile tile in gamearea)
            {
                if (tile.getX() == x && tile.getY() == y)
                {
                    TempTile.TileType = tile.getType();
                }
            }

            return TempTile.TileType;
        }










    }
}
