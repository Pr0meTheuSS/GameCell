using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cell
{
    class Player
    {
        private int x, y;

        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point Move(string sym) 
        {
            if (sym == "W")
            {
                y -= 5;
            }
            if (sym == "S")
            {
                y += 5;
            }
            if (sym == "D")
            {
                x += 5;
            }
            if (sym == "A")
            {
                x -= 5;
            }
            return new Point(x, y);
        }
    }
}
