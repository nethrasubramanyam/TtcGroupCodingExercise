﻿using System;
using System.Windows.Forms;
using TtcGroupRubiksCubeSimulator.Forms;

namespace TtcGroupRubiksCubeSimulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new TtcRubiksForm());
        }
    }
}
