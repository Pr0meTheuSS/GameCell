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
    public partial class gameForm : Form
    {
        Color bg_clr = Color.White;
        Graphics gr;
        Player p;
        List<Mob> Mobs = new List<Mob>();

        public gameForm(int speed, int mobsCount)
        {
            InitializeComponent();
            gr = this.CreateGraphics();
            DoubleBuffered = true;
           
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            
            this.KeyDown += Form2_KeyDown;
            List<int> pos = new List<int>();
            List<int> vel = new List<int>();
            List<int> winSize = new List<int>();

            Random random = new Random();
            winSize.Add(this.Size.Width);
            winSize.Add(this.Size.Height);
            pictureBox1.BackColor = Color.Red;
            p = new Player(pictureBox1.Location.X, pictureBox1.Location.Y, winSize);

            //генерация мобов

            for (int i = 0; i < mobsCount; i++)
            {
                pos.Clear();
                pos.Add(random.Next(50, winSize[0] - 50));
                pos.Add(random.Next(50, winSize[1] - 50));

                vel.Clear();
                int signX = random.Next(-1, 1);
                int signY = random.Next(-1, 1);
                vel.Add(speed * signX);
                while(true)
                {
                    if (signX == signY && signY == 0)
                    {
                        signY = random.Next(-1, 1);
                        continue;
                    }
                    else
                        break;

                }
                vel.Add(speed);

                Mobs.Add(new Mob(pos, vel, winSize, 6));

            }
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
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
            // создание буфера для нового кадра
            Bitmap Image = new Bitmap(Width, Height);
            gr = Graphics.FromImage(Image);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int closed_mob_counter = 0;
            this.gr.Clear(this.bg_clr);
            // разные цвета для отрисовки линий
            Pen pen_blue = new Pen(Color.Blue, 6);
            Pen pen_green = new Pen(Color.Green, 6);

            for (int i = 0; i < p.GetLines().Count(); i++)
            {
                if (p.GetLines()[i].GetIsClosed())
                    this.gr.DrawLine(pen_green, p.GetLines()[i].GetStart(), p.GetLines()[i].GetEnd());
                else
                    this.gr.DrawLine(pen_blue, p.GetLines()[i].GetStart(), p.GetLines()[i].GetEnd());
            }

            closed_mob_counter = 0;
            //каждый моб перемещается
            foreach (Mob mob in Mobs)
            {
                
                Point pos = mob.GetPosition();
                Rectangle R = new Rectangle(pos.X, pos.Y, mob.GetSize(), mob.GetSize());

                p.check_mob_inside(mob);
                p.check_collision(mob);

                if (mob.Get_is_inside())
                {
                    closed_mob_counter++;
                }
                if (mob.Get_is_inside())
                    this.gr.DrawEllipse(pen_green, R);
                else
                    this.gr.DrawEllipse(pen_blue, R);
                mob.Move();
            }
            if (closed_mob_counter == Mobs.Count()) {
                timer1.Stop();
                MessageBox.Show("Game Over!");
                Close();
            }
            // теперь нужно скопировать кадр на канвас формы
            var FormG = CreateGraphics();
            FormG.DrawImageUnscaled(Image, 0, 0);

            // освобождаем задействованные в операции ресурсы
            gr.Dispose();
            Image.Dispose();
            FormG.Dispose();
        }
    }
}