using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell
{
    class Mob
    {
        int x;
        int y;
        int x_velocity;
        int y_velocity;
        int win_size_x;
        int win_size_y;

        public Mob(List<int> position, List<int> velocity, List<int> winSize){
            this.x = position[0];
            this.y = position[1];
            this.x_velocity = velocity[0];
            this.y_velocity = velocity[1];
            this.win_size_x = winSize[0];
            this.win_size_y = winSize[1];
        }

        public void Move() {
           // отражение от стен (вычитание 45 от win_size костыль, но иначе моб выпадает за пределы окна)
            if (this.x <= 0 || this.x >= this.win_size_x - 45) {
                this.x_velocity *= -1;
            }
            if (this.y <= 0 || this.y >= this.win_size_y - 45)
            {
                this.y_velocity *= -1;
            }

            this.x += this.x_velocity;
            this.y += this.y_velocity;
        }

        public List<int> GetPosition() {
            List<int> ret = new List<int>();
            ret.Add(this.x);
            ret.Add(this.y);
            return ret;
        }
    }
}
