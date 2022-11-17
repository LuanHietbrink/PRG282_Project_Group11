using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PRG281_Project_Group11
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void btnAdduser_Click(object sender, EventArgs e)
        {
            string username, password;
            string filepath = @"C:\Users\georg\OneDrive\Desktop\PRG282\PRG282_Project\login.txt";

            username = txtUsername.Text;
            password = txtPassword.Text;

           List<string> lines = new List<string>();
           lines = File.ReadAllLines(filepath).ToList();

           

            if(String.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a valid username");
            }
            else if(String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a valid username");
            }
            else 
            {
                lines.Add(username + "," + password);
                File.WriteAllLines(filepath, lines);

                MessageBox.Show("New user succesfully added");
                new Login().Show();
                this.Hide();
            }
            
        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
            
        }
    }
}
