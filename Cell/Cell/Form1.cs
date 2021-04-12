using System;
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
    public partial class Form1 : Form
    {
        Color bg_clr = Color.Red;
        Graphics gr;
        Player p = new Player();
        Mob M1;
        string sym;
        public Form1()
        {
            InitializeComponent();
            gr = this.CreateGraphics();
            this.KeyDown += Form1_KeyDown;
            
            List<int> pos = new List<int>();
            List<int> vel = new List<int>();
            List<int> winSize = new List<int>();

            pos.Add(50);
            pos.Add(50);

            vel.Add(0);
            vel.Add(5);

            winSize.Add(this.Size.Width);
            winSize.Add(this.Size.Height);

            this.M1 = new Mob(pos, vel, winSize);
        }
        //описание обработчика события
        private void Form1_KeyDown(object sender, KeyEventArgs e ) 
        {
            // надо заменить на p.Move(e.KeyData.ToString());
            var x = this.pictureBox1.Location.X;
            var y = this.pictureBox1.Location.Y;

            if (e.KeyData.ToString() == "W") {
                
                y -= 5;
            }
            if (e.KeyData.ToString() == "S")
            {
                y += 5;
            }
            if (e.KeyData.ToString() == "D")
            {
                x += 5;
            }
            if (e.KeyData.ToString() == "A")
            {
                x -= 5;
            }

            this.pictureBox1.Location = new Point(x, y);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.gr.Clear(this.bg_clr);
            this.M1.Move();
            List<int> pos = this.M1.GetPosition();
            Rectangle R = new Rectangle(pos[0], pos[1], 5, 5);

            Pen pen = new Pen(Color.Blue, 6);
            this.gr.DrawEllipse(pen, R);
        }
    }
}
