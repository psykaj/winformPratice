using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace InsertDataIntoDB.Model
{
    class ClassStudentLogicLayer
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;


        //Data Insert Logic
        public int insert(Students svm) //svm = student view model
        {
            int msg = -1;

            //Establish Connection
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                //Command -> storedProcedure or query , connection obj = con
                SqlCommand cmd = new SqlCommand("insertStudents", con);
                //open connection
                con.Open();

                //Give parameter 
                cmd.Parameters.Add("@Ename", SqlDbType.VarChar,50).Value = svm.Ename;
                cmd.Parameters.Add("@dob", SqlDbType.Date).Value = svm.dob;
                cmd.Parameters.Add("@_image", SqlDbType.VarChar).Value = svm._image;
                cmd.Parameters.Add("@contact", SqlDbType.VarChar, 50).Value = svm.contact;

                //command type is stored procedure 
                cmd.CommandType = CommandType.StoredProcedure;
                //ExecuteNonQuery -> when we perform insert,update,delete  
                msg = cmd.ExecuteNonQuery();
                //close connection
                con.Close();
            }
            catch (Exception)
            {
                msg = 0;


                throw;
            }
            return msg;
        } //Method close

        //Data retrivel code in grid view
        public List<Students> gelAllStudents()
        {
            //Make list object
            List<Students> li = new List<Students>();

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("getAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //ExecuteReader -> will read all data line by line
                SqlDataReader rdr = cmd.ExecuteReader();

                //There are more tham 1 data so..
                //jab tak rdr is true it will read
                while(rdr.Read())
                {
                    //make object of db table
                    Students s = new Students();

                    //cause left side id is string and right side id is int 
                    //comming from db so convert.ToInt32
                    s.id = Convert.ToInt32(rdr["id"].ToString());
                    s.Ename = rdr["Ename"].ToString();
                    s.dob = Convert.ToDateTime(rdr["dob"].ToString());
                    s.contact = rdr["contact"].ToString();
                    //s._image = rdr["-image"].ToString();

                    //Records will individually create and add it into the list
                    li.Add(s);
                }

                con.Close();
            }
            catch(Exception)
            {
                //for these message box use namespace -> using System.Windows.Forms;
                MessageBox.Show("Some Error....");
                //throw;
            }

            return li;
        } //Method close

        //get single student data using id
        public Students GetStudents(int id)
        {
            //make object of db table
            Students s = new Students();

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("getStudentById", con);

                //Add parameter which we have to see
                //And also make sure SqlDbType starts with capital S
                //And argument wale id se search hoga
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //ExecuteReader -> will read all data line by line
                SqlDataReader rdr = cmd.ExecuteReader();

                //There are more tham 1 data so..
                //jab tak rdr is true it will read
                while (rdr.Read())
                {
                    //cause left side id is string and right side id is int 
                    //comming from db so convert.ToInt32
                    s.id = Convert.ToInt32(rdr["id"].ToString());
                    s.Ename = rdr["Ename"].ToString();
                    s.dob = Convert.ToDateTime(rdr["dob"].ToString());
                    s.contact = rdr["contact"].ToString();
                    s._image = rdr["_image"].ToString();
                }
            }
            catch (Exception)
            {
                //for these message box use namespace -> using System.Windows.Forms;
                MessageBox.Show("No record Found....");
                //throw;
            }

            return s;
        } //Method close

        public int update(Students svm) //svm = student view model
        {
            int msg = -1;

            //Establish Connection
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                //Command -> storedProcedure or query , connection obj = con
                SqlCommand cmd = new SqlCommand("updateStudent", con);
                //open connection
                con.Open();

                //Give parameter 
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = svm.id;
                cmd.Parameters.Add("@Ename", SqlDbType.VarChar, 50).Value = svm.Ename;
                cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = svm.dob;
                cmd.Parameters.Add("@_image", SqlDbType.VarChar).Value = svm._image;
                cmd.Parameters.Add("@contact", SqlDbType.VarChar, 50).Value = svm.contact;

                //command type is stored procedure 
                cmd.CommandType = CommandType.StoredProcedure;

                //ExecuteNonQuery -> when we perform insert,update,delete  
                msg = cmd.ExecuteNonQuery();

                //close connection
                con.Close();
            }
            catch (Exception)
            {
                msg = 0;


                throw;
            }
            return msg;
        } //Method close

        public List<Students> getStudentsByParameter(string param)
        {
            //Make list object
            List<Students> li = new List<Students>();

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("searchStudent", con);
                cmd.Parameters.Add("@param", SqlDbType.VarChar,50).Value = param;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //ExecuteReader -> will read all data line by line
                SqlDataReader rdr = cmd.ExecuteReader();

                //There are more tham 1 data so..
                //jab tak rdr is true it will read
                while (rdr.Read())
                {
                    //make object of db table
                    Students s = new Students();

                    //cause left side id is string and right side id is int 
                    //comming from db so convert.ToInt32
                    s.id = Convert.ToInt32(rdr["id"].ToString());
                    s.Ename = rdr["Ename"].ToString();
                    s.dob = Convert.ToDateTime(rdr["dob"].ToString());
                    s.contact = rdr["contact"].ToString();
                    //s._image = rdr["-image"].ToString();

                    //Records will individually create and add it into the list
                    li.Add(s);
                }

                con.Close();
            }
            catch (Exception)
            {
                //for these message box use namespace -> using System.Windows.Forms;
                MessageBox.Show("Some Error....");
                //throw;
            }

            return li;
        } //Method close

        public int delete(int id) //svm = student view model
        {
            int msg = -1;

            //Establish Connection
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                //Command -> storedProcedure or query , connection obj = con
                SqlCommand cmd = new SqlCommand("deleteStudent", con);
                //open connection
                con.Open();

                //Give parameter 
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
        
                //command type is stored procedure 
                cmd.CommandType = CommandType.StoredProcedure;

                //ExecuteNonQuery -> when we perform insert,update,delete  
                msg = cmd.ExecuteNonQuery();

                //close connection
                con.Close();
            }
            catch (Exception)
            {
                msg = 0;


                throw;
            }
            return msg;
        } //Method close

    }
}
