using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FengSharp.UpdateMaker
{
    static class Program
    {
        internal static bool Running;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Running = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
