using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cell
{
    class Mob
    {
        int x;
        int y;
        int x_velocity;
        int y_velocity;
        int size;
        int win_size_x;
        int win_size_y;
        bool is_inside;
        int inside_counter = 0;

        public bool Get_is_inside() { return is_inside; }
        public void Set_is_inside(bool value) {
            // Если моба пытаются пометить как "внутреннего"
            if (value == true)
            {
                // Если моб больше 4 раз подряд признавался мобом внутри полигона
                if (inside_counter >= 5)
                {
                    is_inside = true;
                }
                else
                {
                    inside_counter++;
                }
            }
            else 
            {
                
                if (inside_counter <= 0)
                {
                    is_inside = false;
                }
                else 
                {
                    inside_counter--;
                }
            }
        }

        public Mob(List<int> position, List<int> velocity, List<int> winSize, int size)
        {
            this.x = position[0];
            this.y = position[1];
            this.x_velocity = velocity[0];
            this.y_velocity = velocity[1];
            this.win_size_x = winSize[0];
            this.win_size_y = winSize[1];
            this.size = size;
            is_inside = false;
        }

        public void Reflection(String orientation) {

            if (orientation == "Vertical") 
            {
                this.y_velocity *= -1;
            }
            if (orientation == "Horizontal")
            {
                this.x_velocity *= -1;
            }
        }
        public void Move()
        {
           // отражение от стен 
            if (this.x <= 0 || this.x >= this.win_size_x - 50) 
            {
                Reflection("Horizontal");
            }
            else if (this.y <= 0 || this.y >= this.win_size_y - 50)
            {
                Reflection("Vertical");
            }

            this.x += this.x_velocity;
            this.y += this.y_velocity;
        }

        public Point GetPosition() 
        {
            return new Point(x, y);
        }

        public int GetSize() {
            return size;
        }

        public Point GetVelocity() {
            return new Point(x_velocity, y_velocity);
        }
    }
}
