using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cell
{
    class Line
    {
        Point start;
        Point end;
        bool is_closed;

        public Line(Point start, Point end) {
            this.start = start;
            this.end = end;
            this.is_closed = false;
        }

        public Point GetStart() {
            return start;
        }

        public Point GetEnd() {
            return end;
        }

        public bool GetIsClosed() {
            return is_closed;
        }

        public bool IsCollision(Mob M) {


            /*
             * По формуле Герона Sтреугольника = sqrt(p*(p-a)(p-b)(p-c))
               Но S = 1/2 a * h
               Если принять линию, с которой проверяется коллизия, за основание треугольника, а позицую моба - за трертью вершину, то 
                расстояние от линии до моба == h = 2/a * sqrt(p*(p-a)(p-b)(p-c))
                + необходимо потребовать, чтобы углы при основании были <= 90 градусов (нарисуй или позвони 89137569357 я поясню)
             */
            // a, b ,c - длины сторон треугольника(c - основание треугольника)
            // a= корень из( (x1-x2)^2 + (y1-y2)^2 )
            double a = Math.Round(Math.Sqrt(Math.Pow((M.GetPosition().X - start.X), 2) + Math.Pow((M.GetPosition().Y - start.Y), 2)));
            double b = Math.Round(Math.Sqrt(Math.Pow((M.GetPosition().X - end.X), 2) + Math.Pow((M.GetPosition().Y - end.Y), 2)));
            double c = Math.Round(Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2)));
            // Полупериметр для формулы Герона
            double p = (a + b + c) / 2;
            double dist = 0.0;
            if (c != 0.0)
                dist = Math.Round( 2.0/c * Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
            
            List<int> vector_AC = new List<int>();
            vector_AC.Add(M.GetPosition().X - start.X);
            vector_AC.Add(M.GetPosition().Y - start.Y);

            List<int> vector_AB = new List<int>();
            vector_AB.Add(end.X - start.X);
            vector_AB.Add(end.Y - start.Y);

            List<int> vector_BC = new List<int>();
            vector_BC.Add(M.GetPosition().X - end.X);
            vector_BC.Add(M.GetPosition().Y - end.Y);


            // Возвращаем логическое И ограничений на расстояние и углы при основании(тут свойство скалярного произведения)
            return (dist <= (double)M.GetSize()/2 && vector_AB[0] * vector_AC[0] + vector_AB[1] * vector_AC[1] >= 0 && -vector_AB[0] * vector_BC[0] + -vector_AB[1] * vector_BC[1] >= 0);
        
        }
        public void SetIsClosed(bool is_closed) {
            this.is_closed = is_closed;
        }

    }
}
