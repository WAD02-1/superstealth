using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperStealthNinjaExtreme2017
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameArea hoi = new GameArea();
            Form gameform = new Screen(hoi);

            gameform.MaximumSize = new System.Drawing.Size(817, 776);
            gameform.MinimumSize = new System.Drawing.Size(817, 776);

            gameform.StartPosition = FormStartPosition.CenterScreen;
            gameform.ShowDialog();
        }
    }
}
