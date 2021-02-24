﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form form = new Form();

            form.Width = 800;
            form.Height = 600;
            Game.Init(form);

            Game.Draw();

            Application.Run(form);
        }
    }
}
