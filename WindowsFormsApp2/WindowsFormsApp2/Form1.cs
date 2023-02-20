using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //richTextBox2.Text = textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "Name : " + textBox1.Text + System.Environment.NewLine + "Email : " + textBox2.Text + System.Environment.NewLine + "Address : " + textBox3.Text;
        }
    }
}
