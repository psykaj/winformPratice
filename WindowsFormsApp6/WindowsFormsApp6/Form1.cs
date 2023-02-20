using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\HDC\source\repos\WindowsFormsApp6\WindowsFormsApp6\Resources\image5.jpeg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image Files(*.jpg ; *.jpeg ; *.gif ; *.bmp) | *.jpg ; *.jpeg ; *.gif ; *.bmp";
            if(op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(op.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                textBox1.Text = op.FileName;
            }
        }
    }
}
