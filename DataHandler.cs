using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRG281_Project_Group11
{
    internal class DataHandler
    {
        string connect = @"Data source= (local)\SQLEXPRESS; Initial Catalog= Students; Integrated Security=SSPI";

        public void AddStudent(string stName, string stSurname, Byte[] stImage, string stDOB, string stGender, string stPhone, string stAddress)
        {
            string query = @"INSERT INTO StudentDetails (StudentName,StudentSurname,StudentImage,StudentDOB,StudentGender,StudentPhone,StudentAddress) VALUES ('" + stName + "','" + stSurname + "','" + stImage + "','" + stDOB + "','" + stGender + "','" + stPhone + "','" + stAddress + "')";

            SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student added succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }


        }

        public Student FindStudent(string ID, Student std)
        {
            string query = @"SELECT * FROM StudentDetails WHERE StudentNumber= '" + ID + "'";

            SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();

            con.Open();
            dap.Fill(dtbl);
            if(dtbl.Rows.Count > 0)
            {
                std.Name = dtbl.Rows[0]["StudentName"].ToString();
                std.Surname = dtbl.Rows[0]["StudentSurname"].ToString();
                std.Dob = dtbl.Rows[0]["StudentDOB"].ToString();
                std.Gender = dtbl.Rows[0]["StudentGender"].ToString();
                std.Phone = dtbl.Rows[0]["StudentPhone"].ToString();
                std.Address = dtbl.Rows[0]["StudentAddress"].ToString();
            }
            con.Close();
            return std;
        }

        public void DeleteStudent(string Num)
        {
            string query = @"DELETE FROM StudentDetails WHERE StudentNumber= '" + Num + "'";

            SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student record deleted successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateStudent(string Num, string stName, string stSurname, string stDOB, string stGender, string stPhone, string stAddress)
        {
            string query = @"UPDATE StudentDetails SET StudentName='" + stName + "',StudentSurname='" + stSurname + "',StudentDOB='" + stDOB + "',StudentGender='" + stGender + "',StudentPhone='" + stPhone + "',StudentAddress='" + stAddress + "' WHERE StudentNumber='"+ Num +"'";

            SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student record updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable ViewAllStudents()
        {
            string query = @"SELECT * FROM StudentDetails";

            SqlConnection con = new SqlConnection(connect);
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();

            dap.Fill(dtbl);
            return dtbl;
        }

    }
}
