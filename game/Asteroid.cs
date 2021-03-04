using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Asteroid : BaseObject
    {
        public int Power { get; set; }

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Aqua, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X;
            Pos.Y = Pos.Y - Dir.Y;

            //if (Pos.Y < 0)
            //{
            //    Pos.Y = Game.Height;
            //}

            if (Pos.Y > Game.Height)
            {
                Pos.Y = 0;
            }

        }
    }
}
