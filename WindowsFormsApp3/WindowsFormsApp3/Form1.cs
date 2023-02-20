using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        List<string> li = new List<string>()
        {
            "--select--",
            "India",
            "Pakistan",
            "China",
            "Dubai",
            "America"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Bad Pratice
            //comboBox1.Items.Add("India");
            //comboBox1.Items.Add("Pakistan");
            //comboBox1.Items.Add("China");
            //comboBox1.Items.Add("Dubai");
            //comboBox1.Items.Add("America");
            comboBox1.DataSource = li;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string s = comboBox1.SelectedValue.ToString();
            //MessageBox.Show(s);

            string str = comboBox1.SelectedIndex.ToString();
            
            if(str.Equals("0"))
            {
                MessageBox.Show("Please select the value", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //MessageBox.Show(str);
                MessageBox.Show(comboBox1.SelectedValue.ToString());
            }
        }
    }
}
