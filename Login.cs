using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PRG281_Project_Group11
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string Username;
            string Password;
            string filePath = @"C:\Users\georg\OneDrive\Desktop\PRG282\PRG282_Project\login.txt";

            Username = txtUsername.Text;
            Password = txtPassword.Text;

            bool verif = false;
            string[] lines = System.IO.File.ReadAllLines(@filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] field = lines[i].Split(',');

                if (field[0].Equals(Username) && field[1].Equals(Password))
                {
                    verif = true;
                }
            }

            if (verif == true)
            {
                new Form1().Show();
                this.Hide();
            }
            else if (verif == false)
            {
                MessageBox.Show("Password or Username incorrect");
                txtPassword.Clear();
                txtUsername.Clear();
            }

        }

        private void btnCreateNewUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CreateUser().Show();
            
            
        }
    }
}
