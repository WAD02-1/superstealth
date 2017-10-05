using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;

namespace SuperStealthNinjaExtreme2017
{
    class LevelLoader
    {
        private XmlDocument xmlFile; //The xml level we are loading
        public List<Tile> Tiles { get; } //Loaded tiles will fill this List
        public Player playerObject { get; set; } //Player location from xml file
        public bool LoadingSucceeded { get; } //gets set to true when we are sure the loaded file is actually a level

        //The constructor checks if the file exists, otherwise an exception is thrown
        public LevelLoader(string file)
        {
            //initialize the tile list
            Tiles = new List<Tile>();

            //if the file exists, try to load it
            bool exists = false;
            if (File.Exists(file))
            {
                xmlFile = new XmlDocument();

                //Catch the exception if we try to load something other than an Xml file
                try
                {
                    xmlFile.Load(file);
                    exists = true;
                } catch(System.Xml.XmlException ex) { }
            }

            //Only continue if the xml file exists and contains a level tag
            if(exists && xmlFile.SelectSingleNode("//level") != null)
            {
                LoadingSucceeded = true;
                readXml(xmlFile);
            }
        }

        private void readXml(XmlDocument xmlFile)
        {
            if (LoadingSucceeded)
            {
                //Player
                //initiate x and y variables
                int playerX, playerY;

                //load player
                XmlNode player = xmlFile.SelectSingleNode("//level/player");

                //Parse x and y from the xml file, only do something if a value is found, use -1 for both x and y
                try
                {
                    XmlNode playerXEntry = player.SelectSingleNode("x");
                    XmlNode playerYEntry = player.SelectSingleNode("y");
                    Int32.TryParse(playerXEntry.InnerText, out playerX);
                    Int32.TryParse(playerYEntry.InnerText, out playerY);
                } catch(System.NullReferenceException ex) { playerX = -1; playerY = -1; } //use default values if the required lines don't exist in the xml file

                playerObject = new Player(new Point(playerX, playerY));


                //load the tiles
                XmlNodeList tiles = xmlFile.SelectNodes("//level/tiles/tile");
                foreach(XmlNode tile in tiles)
                {
                    //Create required variables
                    int x, y;
                    string type;

                    //Parse x and y from the xml file, only do something if a value is found
                    try
                    {
                        XmlNode xEntry = tile.SelectSingleNode("x");
                        XmlNode yEntry = tile.SelectSingleNode("y");
                        Int32.TryParse(xEntry.InnerText, out x);
                        Int32.TryParse(yEntry.InnerText, out y);

                        //get type
                        XmlNode typeEntry = tile.Attributes.GetNamedItem("type");
                        type = typeEntry.InnerText;

                        Tiles.Add(new Tile(type, x, y));
                    } catch(System.NullReferenceException ex) { }
                }

                //load the enemies
                XmlNodeList enemies = xmlFile.SelectNodes("//level/enemies/enemy");
                foreach (XmlNode enemy in enemies)
                {
                    //The default x and y are -1, in case tiles can't be loaded
                    int x, y, direction;
                    string type;
                    //Parse x and y from the xml file, only do something if a value is found
                    try
                    {
                        XmlNode xEntry = enemy.SelectSingleNode("x");
                        XmlNode yEntry = enemy.SelectSingleNode("y");
                        Int32.TryParse(xEntry.InnerText, out x);
                        Int32.TryParse(yEntry.InnerText, out y);
                    } catch(System.NullReferenceException ex) { continue; } //go to next tile if this gives an exception

                    //Do the same for direction
                    try
                    {
                        XmlNode directionEntry = enemy.SelectSingleNode("start_direction");
                        Int32.TryParse(directionEntry.InnerText, out direction);
                    } catch(System.NullReferenceException ex) { direction = 0; } //the default start_direction is 0, it doesn't have to be defined

                    //get type
                    XmlNode typeEntry = enemy.SelectSingleNode("type");
                    try
                    {
                        type = typeEntry.InnerText;
                    } catch(System.NullReferenceException ex) { type = "standing"; } //default is standing is no type is defined

                    Console.WriteLine(type + ": " + x + "," + y+"; direction: "+direction);
                }
            }
        }
    }
}