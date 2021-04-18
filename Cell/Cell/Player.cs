﻿using System;
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
        private int win_width, win_height;
        private String direction;
        List<Line> Lines = new List<Line>();
        List<Polygon> Polygons = new List<Polygon>();
        private bool is_drawing;// флаг активации режима рисования
        public Player(int x, int y, List<int> winSize)
        {
            this.x = x;
            this.y = y;
            this.win_width = winSize[0];
            this.win_height = winSize[1];
        }
        public Point Move(string sym) 
        {
            if (sym == "Space")
            {
                is_drawing = !is_drawing;
                if(!is_drawing)
                {
                    for(int i = 0; i < Lines.Count; i++)
                    {
                        if (!Lines[i].GetIsClosed())
                        {
                            Lines.Remove(Lines[i]);
                            i--;
                        }
                    }
                }
            }
            // проверка пересечений с линиями при включенном режиме отрисовки
            if (is_drawing) 
            {
                check_crossing();
            }

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

            // Проверка выхода за границы окна
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            if (x > win_width - 30)
                x = win_width - 30;
            if (y > win_height - 50)
                y = win_height - 50;


            if (is_drawing) 
            {
                // Если изменилось направление движения - строим линию от конца последней построенной линии до текущего положения игрока
                if (sym != this.direction)
                {
                    // Если последняя линия незамкнута
                    if (!Lines.Last().GetIsClosed())
                        Lines.Add(new Line(Lines.Last().GetEnd(), new Point(x, y)));
                    else
                        Lines.Add(new Line(new Point(x, y), new Point(x, y)));
                }
                else
                {
                    // Если направление игрока не менялось - модифицируем последнюю(текущую) линию, "отодвигая" конец линии к текущему положению игрока
                    if (!Lines.Last().GetIsClosed())
                    {
                        Point start = Lines.Last().GetStart();
                        Point new_end = new Point(x, y);
                        Lines.Remove(Lines.Last());
                        Lines.Add(new Line(start, new_end));
                    }
                    else
                    {
                        Lines.Add(new Line(new Point(x, y), new Point(x, y)));
                    }
                }
            }
            if (sym != "Space") 
            {
                direction = sym;
            }

            return new Point(x, y);
        }

        public void check_crossing() 
        {
            // Проверка на пересечение со всеми линиями кроме последней(текущей)
            for (int i = 0; i < Lines.Count() - 1; i++)
            {
                int min_x = (Lines[i].GetStart().X < Lines[i].GetEnd().X) ? Lines[i].GetStart().X : Lines[i].GetEnd().X;
                int min_y = (Lines[i].GetStart().Y < Lines[i].GetEnd().Y) ? Lines[i].GetStart().Y : Lines[i].GetEnd().Y;
                int max_x = (Lines[i].GetStart().X > Lines[i].GetEnd().X) ? Lines[i].GetStart().X : Lines[i].GetEnd().X;
                int max_y = (Lines[i].GetStart().Y > Lines[i].GetEnd().Y) ? Lines[i].GetStart().Y : Lines[i].GetEnd().Y;
                // Если позиция игрока совпадает с некоторой прямой(переcечение) (впоследствии необходимо добавить проверку флага is_drawing)
                if ((this.x == Lines[i].GetStart().X && this.x == Lines[i].GetEnd().X && min_y <= this.y && this.y <= max_y) ||
                    (this.y == Lines[i].GetStart().Y && this.y == Lines[i].GetEnd().Y && min_x <= this.x && this.x <= max_x)
                    )
                {
                    // Если линия, с которой зафиксировано пересечение, незамкнута
                    if (!Lines[i].GetIsClosed())
                    {

                        // Корректируем первую линию в петле, отрезая "хвост" 
                        Point start = new Point(x, y);
                        Point end = Lines.ElementAt(i).GetEnd();
                        Lines.RemoveAt(i);
                        Lines.Insert(i, new Line(start, end));
                        Lines[i].SetIsClosed(true);
                        // Удаляем незамкнутые линии до i-той линии( то есть до первой в петле)
                        while (i > 0)
                        {
                            i--;
                            if (!Lines[i].GetIsClosed())
                            {
                                Lines.RemoveAt(i);
                            }
                        }
                        // Помечаем замкнутыми линии от пересеченной до текущей (последней в списке линий)
                        for (int t = 0; t < Lines.Count(); t++)
                        {
                            Lines[t].SetIsClosed(true);
                        }
                        // Корректируем последнюю(текущую) линию, отрезая "хвост"
                        start = Lines.Last().GetStart();
                        end = new Point(x, y);
                        Lines.Remove(Lines.Last());
                        Lines.Add(new Line(start, end));
                        Lines.Last().SetIsClosed(true);
                        // При замыкании переключаем режим отрисовки
                        is_drawing = !is_drawing;
                        break;
                    }
                }
            }
        }

        public void check_collision(Mob M)
        {
            for (int i = 0; i < Lines.Count(); i++)
            {
                // проверяем каждую прямую на замкнутость и пересечение с координатами моба
                if (Lines[i].IsCollision(M))
                {
                    if (!Lines[i].GetIsClosed())
                    {
                        for (int t = 0; t < Lines.Count(); t++)
                        {
                            if (!Lines[t].GetIsClosed())
                            // Если коллизия и линия не замкнута
                            {
                                Lines.Remove(Lines[t]);
                                t--;
                            }
                        }
                    }
                    else 
                    {
                        Console.Out.WriteLine("Reflection!");
                        // Если коллизия и линия замкнута - отражение моба от стенки
                        if (Lines[i].GetStart().X == Lines[i].GetEnd().X)
                        {
                            M.Reflection("Horizontal");
                        }
                        else if (Lines[i].GetStart().Y == Lines[i].GetEnd().Y)
                        {
                            M.Reflection("Vertical");
                        }
                    }
                }
            }
            // Чтобы список линий не был пустым, а то сделаю атата!
            if (Lines.Count() == 0)
            {
                Lines.Add(new Line(new Point(x, y), new Point(x, y)));
            }
        }

        public Point GetCurPos() 
        {
            return new Point(x, y);
        }
        public List<Line> GetLines() 
        {
            return Lines;
        }
    }
}
