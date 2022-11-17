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
    }
}
