using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Meteors : BaseObject
    {
        public Meteors(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            SolidBrush browBrush = new SolidBrush(Color.Brown);
            //Game.Buffer.Graphics.DrawEllipse(new Pen(Color.Brown), new Rectangle(Pos.X, Pos.Y, Pos.X + Dir.X, Pos.Y+Dir.Y));
            Game.Buffer.Graphics.FillEllipse(browBrush, Pos.X, Pos.Y, Size.Width, Size.Height);
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
