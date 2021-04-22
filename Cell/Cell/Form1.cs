using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Cell
{
    public partial class Form1 : Form
    {
        SoundPlayer simpleSound = new SoundPlayer("vagatrica.wav");
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            gameForm gf = new gameForm(Convert.ToInt32(HardLevel.Value), Convert.ToInt32(MobsCount.Value));
            simpleSound.PlayLooping();
            gf.ShowDialog();
            simpleSound.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
