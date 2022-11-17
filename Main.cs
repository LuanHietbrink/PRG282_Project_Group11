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
    public partial class Main : Form
    {
        ModuleDataHandler moduleDataHandler = new ModuleDataHandler();
        DataHandler StudentDataH = new DataHandler();
        public static SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        public Main()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Server=DESKTOP-6OVGGB7\SQLEXPRESS; Initial Catalog =Students; Integrated Security =SSPI");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnModuleAdd_Click(object sender, EventArgs e)
        {
            if (txtModName.Text == "" || txtModDesc.Text == "" || txtModLink.Text == "")
            {
                MessageBox.Show("Please make sure that all fields are filled out");
            }
            else
            {
                moduleDataHandler.SaveModule(txtModName.Text, txtModDesc.Text, txtModLink.Text);
                txtModName.Clear();
                txtModDesc.Clear();
                txtModLink.Clear();
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string StudentName = txtStuName.Text;
            string StudentSurname = txtStuSurname.Text;

            Image img = pbxPhoto.Image;
            byte[] StudentImage;
            ImageConverter conv = new ImageConverter();
            StudentImage = (byte[])conv.ConvertTo(img, typeof(byte[]));

            string StudentDOB = dtpStuDOB.Value.ToString();
            string StudentGender = cbxStuGender.Text;
            string StudentPhone = txtStuPhone.Text;
            string StudentAddress = txtStuAddress.Text;

            
            StudentDataH.AddStudent(StudentName, StudentSurname, StudentImage, StudentDOB, StudentGender, StudentPhone, StudentAddress);
        }

        private void btnFindStudent_Click(object sender, EventArgs e)
        {
            string Num = txtNum.Text;
            Student student = new Student();

            student = StudentDataH.FindStudent(Num,student);
            edtName.Text = student.Name;
            edtSurname.Text = student.Surname;
            dtpDateEdt.Text = student.Dob;
            cbxGenderEdt.Text = student.Gender;
            edtPhone.Text = student.Phone;
            edtAddress.Text = student.Address;


        }       

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            string Num = txtNum.Text;
            StudentDataH.DeleteStudent(Num);
            
        }
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            string Num = txtNum.Text;
            string StudentName = edtName.Text;
            string StudentSurname = edtSurname.Text;
            string StudentDOB = dtpDateEdt.Value.ToString();
            string StudentGender = cbxGenderEdt.Text;
            string StudentPhone = edtPhone.Text;
            string StudentAddress = edtAddress.Text;

            StudentDataH.UpdateStudent(Num, StudentName, StudentSurname, StudentDOB, StudentGender, StudentPhone, StudentAddress);
        }

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            dtStudents.DataSource = StudentDataH.ViewAllStudents();
        }
    }
}
