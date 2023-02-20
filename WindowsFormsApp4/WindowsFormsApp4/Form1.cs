using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        //Best Pratice
        List<string> li = new List<string>()
        {
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven"
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Monday");
            listBox1.Items.Add("Tuesday");
            listBox1.Items.Add("Wednesday");
            listBox1.Items.Add("Thrusday");
            listBox1.Items.Add("Friday");
            listBox1.Items.Add("Saturday");
            listBox1.Items.Add("Sunday");
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox2.DataSource = li;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(listBox1.SelectedItem.ToString());
            foreach(var item in listBox1.SelectedItems)
            {
                MessageBox.Show(item.ToString());
            }
        }
    }
}
