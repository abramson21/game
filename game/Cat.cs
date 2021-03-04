using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Cat : BaseObject
    {/*= "../../cat"*/
        private readonly string file = "../../icon.png";

        public Cat(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Bitmap cat = new Bitmap(file);
            Game.Buffer.Graphics.DrawImage(cat, Pos.X, Pos.Y);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;

            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
            if (Pos.Y < 0) Pos.Y = Dir.Y = -Dir.Y;
        }
    }
}
