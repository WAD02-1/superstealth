using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperStealthNinjaExtreme2017
{
    public partial class Screen : Form
    {

        Player p = new Player(new Point(6, 2));

        public GameArea ga { get; set; }
        public Screen(GameArea ga)
        {
            this.ga = ga;
            InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics dc = e.Graphics;

            foreach (Tile t in GameArea.gamearea)
            {
                // Create pen for border.
                Pen borderPen = new Pen(Color.Black, 1);

                // Create solid brush.
                SolidBrush tileFillBrush = new SolidBrush(t.TileColor);

                // Assign variables.
                int tX = t.getX();
                int tY = t.getY();
                int TopMargin = 0;

                // Create rectangle.
                Rectangle rect = new Rectangle((tX * 32), (tY * 32) + TopMargin, 32, 32);

                // Fill rectangle to screen.
                dc.FillRectangle(tileFillBrush, rect);
                dc.DrawRectangle(borderPen, (tX * 32), (tY * 32) + TopMargin, 32, 32);

            }
            Pen pen = new Pen(Color.Black, 1);
            dc.DrawEllipse(pen, p.location.X * 32, p.location.Y * 32, 32, 32);
            p.PrintLocation();
        }


        private void Screen_KeyDown(object sender, KeyEventArgs e)
        {



            

            if (e.KeyCode == Keys.Left && GameArea.GetTileType(p.location.X - 1, p.location.Y) != "wall")
            {
                if (GameArea.GetTileType(p.location.X - 1, p.location.Y) == "lava")
                {
                    p.MoveLeft();
                    this.Refresh();
                    MessageBox.Show("Dead");
                }
                else
                {
                    p.MoveLeft();
                }
            }

            else if(e.KeyCode == Keys.Right && GameArea.GetTileType(p.location.X + 1, p.location.Y) != "wall")
            {
                if (GameArea.GetTileType(p.location.X + 1, p.location.Y) == "lava")
                {
                    p.MoveRight();
                    this.Refresh();
                    MessageBox.Show("Dead");
                }
                else
                {
                    p.MoveRight();
                }
            }

            else if (e.KeyCode == Keys.Up && GameArea.GetTileType(p.location.X, p.location.Y - 1) != "wall")
            {
                if (GameArea.GetTileType(p.location.X, p.location.Y - 1) == "lava")
                {
                    p.MoveUp();
                    this.Refresh();
                    MessageBox.Show("Dead");
                }
                else
                {
                    p.MoveUp();
                }
            }

            else if (e.KeyCode == Keys.Down && GameArea.GetTileType(p.location.X, p.location.Y + 1) != "wall")
            {
                if (GameArea.GetTileType(p.location.X, p.location.Y + 1) == "lava")
                {
                    p.MoveDown();
                    this.Refresh();
                    MessageBox.Show("Dead");
                }
                else
                {
                    p.MoveDown();
                }
            }

            




            this.Refresh();
        }

        private void Screen_Load(object sender, EventArgs e)
        {

        }
    }
}
