using InsertDataIntoDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsertDataIntoDB
{
    public partial class Form1 : Form
    {
        bool setImage = false;

        //Students Object
        Students s = new Students();

        //make object of class ClassStudentLogicLayer
        ClassStudentLogicLayer obj = new ClassStudentLogicLayer();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            if(setImage == false)
            {
                //single \ error dega double kardo
                //Alternative
                //single rakho aur @ laga do
                s._image = @"C:\Image\Unknown.webp";
            }

            //now student property bind hogi
            s.Ename = textBox1.Text;
            s.dob = dateTimePicker1.Value;
            s.contact = textBox3.Text;
            

            int i = obj.insert(s);

            if(i != 0 || i != -1)
            {
                //to get the data inserted into the gridview directly 
                dataGridView1.DataSource = obj.gelAllStudents();

                MessageBox.Show("Data Successfully inserted");
            }
            else
            {
                MessageBox.Show("Data not Successfully inserted");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(op.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                s._image = op.FileName;
                setImage = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obj.gelAllStudents();
        }

        //to get the single data using
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            //If it is true
            if (checkBox1.Checked)
            {
                s = obj.GetStudents(Convert.ToInt32(textBox5.Text));
                if (s != null)
                {
                    //Data Bind
                    textBox4.Text = s.Ename;
                    dateTimePicker2.Value = s.dob;
                    textBox2.Text = s.contact;
                }
                else
                {
                    MessageBox.Show("No Records Were Found....");
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //now student property bind hogi
            s.id = Convert.ToInt32(textBox5.Text);
            s.Ename = textBox4.Text;
            s.dob = dateTimePicker2.Value;
            s.contact = textBox2.Text;

            //data coming from update method
            int i = obj.update(s);

            if (i != 0 || i != -1)
            {
                //to get the data inserted into the gridview directly 
                dataGridView1.DataSource = obj.gelAllStudents();

                MessageBox.Show("Data Successfully Updated");
            }
            else
            {
                MessageBox.Show("Data not Successfully Updated");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(op.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                s._image = op.FileName;
                setImage = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClassStudentLogicLayer ly = new ClassStudentLogicLayer();
            List<Students> li =  ly.getStudentsByParameter(textBox6.Text);
            dataGridView1.DataSource = li;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //make object of ClassStudentLogicLayer
            ClassStudentLogicLayer ly = new ClassStudentLogicLayer();
            int msg = ly.delete(Convert.ToInt32(textBox7.Text));
            if(msg == -1)
            {
                MessageBox.Show("Data count not delete");
            }
            else
            {
                MessageBox.Show("Data Deleted Successfully");
            }

            dataGridView1.DataSource = obj.gelAllStudents();
        }
    }
}
