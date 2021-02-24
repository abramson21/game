using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    using System.Drawing;
    class Game
    {
        private static BufferedGraphicsContext _context;

        public static BufferedGraphics Buffer;

        public static int Width { get; set; }

        public static int Height { get; set; }

        public static BaseObject[] _objs;

        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;

            _context = BufferedGraphicsManager.Current;

            g = form.CreateGraphics();


            Width = form.ClientSize.Width;

            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }
        }

        public static void Load()
        {
            _objs = new BaseObject[60];
            Random ran = new Random();
            for (int i = 0; i < _objs.Length / 2; i++)
                //_objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
                _objs[i] = new Meteors(new Point(i * 50, ran.Next(10, 800)), new Point(0, -i), new Size(30, 30));
            for (int i = _objs.Length / 2 ; i < _objs.Length; i++)
                _objs[i] = new Star(new Point(i * ran.Next(10, 50), i * ran.Next(1, 20)), new Point(-i, 0), new Size(5, 5));
            //for (int i = ((_objs.Length * 2) / 3); i < _objs.Length; i++)
            //    //_objs[i] = new Meteors(new Point(i, 0), new Point(i, -i), new Size(30, 30));
            //    _objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
        }

    }
}
