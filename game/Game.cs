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

        public static Bullet _bullet;

        public static Asteroid[] _asteroids;

        //public static Cat _cat;

        public static Meteors[] _meteors;

        public static Cat _cat = new Cat(new Point(200, 200), new Point(20, 20), new Size(5, 5));

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

            foreach (Meteors meteors in _meteors)
            {
                meteors.Draw();
            }

            _cat.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }

            foreach (Meteors meteors in _meteors )
            {
                meteors.Update();
                if (meteors.Collision(_cat)) { System.Media.SystemSounds.Hand.Play(); }
            }

            
            _cat.Update();
        }

        public static void Load()
        {
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _cat = new Cat(new Point(200, 200), new Point(20, 20), new Size(5, 5));
            _asteroids = new Asteroid[3];
            _meteors = new Meteors[200];
            var rnd = new Random();
            
            for (int i = 0; i < _meteors.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _meteors[i] = new Meteors(new Point(i * 70, rnd.Next(0, Game.Height)), new Point(r, -r), new Size(50, 50));
            }

            for (int i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(600, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
            }



            //for (int i = 0; i < 10; i++)
            //{
            //    int r = rnd.Next(5, 50);
            //    _asteroids[i] = new Asteroid(new Point(600, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(r, r));
            //}

            //for (int i = 0; i < _objs.Length / 2; i++)
            //    //_objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            //    _objs[i] = new Meteors(new Point(i * 50, ran.Next(10, 800)), new Point(0, -i), new Size(30, 30));
            //for (int i = _objs.Length / 2 ; i < _objs.Length; i++)
            //    _objs[i] = new Star(new Point(i * ran.Next(10, 50), i * ran.Next(1, 20)), new Point(-i, 0), new Size(5, 5));
            ////for (int i = ((_objs.Length * 2) / 3); i < _objs.Length; i++)
            ////    //_objs[i] = new Meteors(new Point(i, 0), new Point(i, -i), new Size(30, 30));
            ////    _objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            //_objs[_objs.Length - 1] = new Cat(new Point(200, 200), new Point(20, 20), new Size(5, 5));

        }

    }
}
