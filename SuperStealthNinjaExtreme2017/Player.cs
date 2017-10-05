using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperStealthNinjaExtreme2017
{
    class Player
    {
        public Point location;

        /// <summary>
        /// Moves player location up
        /// </summary>
        public void MoveUp()
        {
            if (location.Y > 0)
            {
                location.Y -= 1;
            }
        }

        /// <summary>
        /// Moves player location down
        /// </summary>
        public void MoveDown()
        {
            if (location.Y < 22)
            {
                location.Y += 1;
            }
        }

        /// <summary>
        /// Moves player location right
        /// </summary>
        public void MoveRight()
        {
            if (location.X < 24)
            {
                location.X += 1;
            }
        }

        /// <summary>
        /// Moves player location left
        /// </summary>
        public void MoveLeft()
        {
            if (location.X > 0)
            {
                location.X -= 1;
            }
        }

        /// <summary>
        /// Creates Player instance on the specified location
        /// </summary>
        /// <param name="startLocation">
        /// The start location of the player
        /// </param>
        public Player(Point startLocation)
        {
            if (startLocation.X < 24 || startLocation.X > 0 || startLocation.Y < 20 || startLocation.Y > 0)
            {
                location = startLocation;
            }
            else
            {
                MessageBox.Show("Start Location Outside Playzone");
            }
        }

        /// <summary>
        /// Prints X and Y value of Player instance
        /// </summary>
        public void PrintLocation()
        {
            Console.WriteLine("X: " + location.X.ToString() + " Y: " + location.Y.ToString());
        }
    }
}
