using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG281_Project_Group11
{
    internal class ModuleDataHandler
    {
        private int moduleCode;
        private string moduleName, moduleDescription, moduleLink;

        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        private string connection = @"Server=DESKTOP-6OVGGB7\SQLEXPRESS; Initial Catalog =Students; Integrated Security =SSPI";

        public ModuleDataHandler(int moduleCode, string moduleName, string moduleDescription, string moduleLink)
        {
            this.moduleCode = moduleCode;
            this.moduleName = moduleName;
            this.moduleDescription = moduleDescription;
            this.moduleLink = moduleLink;
        }

        public ModuleDataHandler()
        {

        }

        public void openConnection()
        {
            conn = new SqlConnection(connection);
            conn.Open();
        }

        public void SaveModule(string name, string description, string link)
        {
            string insertQuery = $"Insert into ModuleDetails (ModuleName, ModuleDescription, ModuleLink) Values ('{name}', '{description}', '{link}')";
            openConnection();

            cmd = new SqlCommand(insertQuery, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Module successfully added");
            }
            catch (SqlException err)
            {
                MessageBox.Show("Something went wrong. Please try again");
                MessageBox.Show(err.ToString());
            }
            finally
            {
                conn.Close();
            }

        }

        public void deleteModule(int code)
        {
            string deleteQuery = $"Delete from StudentModules where ModuleCode = {code}; Delete from ModuleDetails where ModuleCode = {code}";
            openConnection();

            cmd = new SqlCommand(deleteQuery, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show($"The module {code} has been successfully deleted");
            }
            catch (SqlException err)
            {
                MessageBox.Show("Something went wrong. Please try again.");
                MessageBox.Show(err.ToString());
            }
            finally
            {
                conn.Close();  
            }
        }


        public void updateModule(int code, string name, string description, string link)
        {
            string updateQuery = $"Update ModuleDetails SET ModuleName = '{name}', ModuleDescription = '{description}', ModuleLink = '{link}'";
            openConnection();

            cmd = new SqlCommand(updateQuery, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Module successfully updated");
            }
            catch (SqlException err)
            {
                MessageBox.Show("Something went wrong. Please try again.");
                MessageBox.Show(err.ToString());

            }
            finally
            {
                conn.Close();
            }
        }


    }
}
