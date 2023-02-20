using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        List<string> li = new List<string>()
        {
            "Pankaj",
            "Rahul",
            "Tushar",
            "Aditya",
            "Aniket"
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var item in li)
            {
                checkedListBox1.Items.Add(item);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            if(checkBox1.Checked)
            {
                foreach (var item in li)
                {
                    checkedListBox1.Items.Add(item,true);
                }
            }
            else
            {
                foreach (var item in li)
                {
                    checkedListBox1.Items.Add(item, false);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //avoid duplicate values in the fields
            listBox1.Items.Clear();

            for(int i=0;i<checkedListBox1.Items.Count;i++)
            {
                if(checkedListBox1.GetItemChecked(i))
                {
                    listBox1.Items.Add(checkedListBox1.Items[i]);
                }
            }
        }
    }
}
