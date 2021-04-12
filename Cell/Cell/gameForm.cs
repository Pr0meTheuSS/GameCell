﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell
{
    public partial class gameForm : Form
    {
        Color bg_clr = Color.Red;
        Graphics gr;
        Player p;
        Mob M1;

        List<Mob> Mobs = new List<Mob>();
        string sym;

        public gameForm(int speed, int mobsCount)
        {
            InitializeComponent();
            gr = this.CreateGraphics();
            this.KeyDown += Form2_KeyDown;
            p = new Player(pictureBox1.Location.X, pictureBox1.Location.Y);
            List<int> pos = new List<int>();
            List<int> vel = new List<int>();
            List<int> winSize = new List<int>();

            vel.Add(speed);
            vel.Add(speed);
            winSize.Add(this.Size.Width);
            winSize.Add(this.Size.Height);

            //генерация мобов
            Random random = new Random();

            for (int i = 0; i < mobsCount; i++)
            {
                pos.Clear();
                pos.Add(random.Next(0, winSize[0]));
                pos.Add(random.Next(0, winSize[1]));
                Mobs.Add(new Mob(pos, vel, winSize));
            }


        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            this.pictureBox1.Location = p.Move(e.KeyData.ToString());
        }
        private void gameForm_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.gr.Clear(this.bg_clr);
            //this.M1.Move();

            //каждый моб перемещается
            foreach(Mob mob in Mobs)
            {
                mob.Move();
                List<int> pos = mob.GetPosition();
                Rectangle R = new Rectangle(pos[0], pos[1], 5, 5);
                Pen pen = new Pen(Color.Blue, 6);
                this.gr.DrawEllipse(pen, R);
            }


        }
    }
}