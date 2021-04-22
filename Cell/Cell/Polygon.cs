using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell
{
    class Polygon//хранит замкнутую линию
    {
        List<Line> lines { get; }

        public Polygon(List<Line> lines)
        {
            this.lines = new List<Line>(lines);
        }
        public bool is_inside(Mob M)
        {
            // выпускаем луч(совпадающий с прямой y = x + b, где b зависит от позиции моба)
            // из позиции моба и считаем количество пересечений со сторонами полигона - 
            // если их нечетное число - моб внутри, иначе - снаружи
            int crossing_counter = 0;
            int crossing_vertex_counter = 0;
            int x, y, b;
            b = M.GetPosition().Y - M.GetPosition().X;

            for (int i = 0; i < lines.Count(); i++)
            {
                // Если линия вертикальная
                if (lines[i].GetStart().X == lines[i].GetEnd().X)
                {
                    // вычисляем координату y пересечения i-той прямой с лучом, x, очевидно, равен lines[i].GetStart().X == lines[i].GetEnd().X
                    x = lines[i].GetStart().X;
                    y = x + b;
                    // Если точка пересечения лежит в 1-ой четверти относительно позиции моба (так мы проверяем пересечение именно луча, а не прямой)
                    if (y > M.GetPosition().Y && x > M.GetPosition().X)
                    {
                        // Если координата y точки пересечения луча и прямой принадлежит отрезку, который и задаёт прямую
                        if ((lines[i].GetStart().Y < y && y < lines[i].GetEnd().Y) || (lines[i].GetEnd().Y < y && y < lines[i].GetStart().Y))
                        {
                            // фиксируем пересечение
                            crossing_counter++;
                            Console.Out.WriteLine("************************");
                            Console.Out.WriteLine(x.ToString());
                            Console.Out.WriteLine(y.ToString());
                            Console.Out.WriteLine("************************");
                        }
                        // Если была пересечена вершина
                        else if ( (x == lines[i].GetStart().X && y == lines[i].GetStart().Y) || (x == lines[i].GetEnd().X && y == lines[i].GetEnd().Y)) {
                            crossing_vertex_counter++;
                        }
                    }
                }
                // Если линия горизонтальная
                else if (lines[i].GetStart().Y == lines[i].GetEnd().Y)
                {
                    // вычисляем координату x пересечения i-той прямой с лучом. y, очевидно, равен lines[i].GetStart().Y == lines[i].GetEnd().Y
                    y = lines[i].GetStart().Y;
                    x = y - b;
                    // Если точка пересечения лежит в 1-ой четверти относительно позиции моба (так мы проверяем пересечение именно луча, а не прямой)
                    if (x > M.GetPosition().X && y > M.GetPosition().Y)
                    {
                        // Если координата x точки пересечения луча и прямой принадлежит отрезку, который и задаёт прямую
                        if ((lines[i].GetStart().X < x && x < lines[i].GetEnd().X) || (lines[i].GetEnd().X < x && x < lines[i].GetStart().X))
                        {
                            // фиксируем пересечение
                            crossing_counter++;
                            Console.Out.WriteLine("************************");
                            Console.Out.WriteLine(x.ToString());
                            Console.Out.WriteLine(y.ToString());
                            Console.Out.WriteLine("************************");
                        }
                    }

                }
            }
            return ((crossing_counter + crossing_vertex_counter) % 2 == 1);
        }
    }
}
