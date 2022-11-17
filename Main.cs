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
            string StudentImage = pbxPhoto.Image.ToString();
            string StudentDOB = dtpStuDOB.Value.ToString();
            string StudentGender = cbxStuGender.Text;
            string StudentPhone = txtStuPhone.Text;
            string StudentAddress = txtStuAddress.Text;

            if(StudentName == null || StudentSurname == null || StudentGender == null || StudentPhone == null || StudentAddress == null || StudentName == null || StudentName == null || StudentImage == null)
            {
                MessageBox.Show("Please make sure that all fields are filled out");
            }
            else
            {
                StudentDataH.AddStudent(StudentName, StudentSurname, StudentImage, StudentDOB, StudentGender, StudentPhone, StudentAddress);
            }
            
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

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            string image;
            try
            {
                OpenFileDialog imageUpload = new OpenFileDialog();
                imageUpload.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (imageUpload.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    image = imageUpload.FileName;
                    pbxPhoto.ImageLocation = image;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error occurred");
            }
        }

        private void btnModuleFind_Click(object sender, EventArgs e)
        {
            if (txtModCodeFind.Text != "")
            {
                bool found = moduleDataHandler.searchMethod(int.Parse(txtModCodeFind.Text));

                if (found)
                {
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                    string searcQuery = ($"SELECT*FROM ModuleDetails WHERE ModuleCode = {txtModCodeFind.Text}");
                    connection.Open();
                    command = new SqlCommand(searcQuery, connection);

                    try
                    {
                        reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            txtModNameFind.Text = reader[1].ToString();
                            txtModDescFind.Text = reader[2].ToString();
                            txtModLinkFind.Text = reader[3].ToString();
                        }
                        

                    }
                    catch (SqlException err)
                    {

                        MessageBox.Show(err.Message);
                    }
                    finally
                    {

                        if (connection != null)
                        {
                            connection.Close();
                        }

                        reader.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a module code");
            }
        }

        private void txtModCodeFind_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;

            if (!double.TryParse(txtModCodeFind.Text, out parsedValue))
            {
                txtModCodeFind.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            moduleDataHandler.deleteModule(int.Parse(txtModCodeFind.Text));
            clearEditFields();
        }

        public void clearEditFields()
        {
            txtModCodeFind.Clear();
            txtModDescFind.Clear();
            txtModLinkFind.Clear();
            txtModNameFind.Clear();

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }


        private void btnViewModules_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                command = new SqlCommand("select*from ModuleDetails", connection);

                reader = command.ExecuteReader();

                BindingSource source = new BindingSource();
                source.DataSource = reader;

                dtModules.DataSource = source;
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
        }

        private void btnAddForStudent_Click(object sender, EventArgs e)
        {
            addStudentModule(int.Parse(txtStudentModule.Text), int.Parse(txtModuleAdd.Text));
            try
            {
                connection.Open();
                command = new SqlCommand($"select StudentNumber, ModuleDetails.ModuleCode, ModuleName, ModuleDescription from ModuleDetails Join StudentModules on ModuleDetails.ModuleCode = StudentModules.Modulecode where StudentNumber = {txtStudentModule.Text}", connection);

                reader = command.ExecuteReader();

                BindingSource source = new BindingSource();
                source.DataSource = reader;

                dtModules.DataSource = source;
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
            txtStudentModule.Clear();
            txtModuleAdd.Clear();
        }

        public void addStudentModule(int student, int module)
        {
            bool modulefound = moduleDataHandler.searchMethod(module);

            bool searchStudent = false;

            string searcQuery = ($"SELECT*FROM StudentDetails WHERE StudentNumber = {student}");
            connection.Open();
            command = new SqlCommand(searcQuery, connection);

            try
            {
                reader = command.ExecuteReader();

                if (reader.Read())
                {

                    searchStudent = true;
                }
                else
                {
                    searchStudent = false;
                }

            }
            catch (SqlException err)
            {

                MessageBox.Show(err.Message);
            }
            finally
            {

                if (connection != null)
                {
                    connection.Close();
                }

                reader.Close();
            }


            if (modulefound == true && searchStudent == true)
            {
                string searchQuery = ($"SELECT*FROM StudentModules WHERE StudentNumber = {student} and ModuleCode = {module}");
                connection.Open();
                command = new SqlCommand(searchQuery, connection);

                try
                {
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("This student already has this module");
                    }
                    else
                    {
                        reader.Close();
                        string insertQuery = ($"Insert into StudentModules (StudentNumber, ModuleCode) Values ({student},{module}) ");
                        SqlCommand addsm = new SqlCommand(insertQuery, connection);
                        try
                        {
                            addsm.ExecuteNonQuery();
                            MessageBox.Show("Module successfully added");
                        }
                        catch (SqlException err)
                        {
                            MessageBox.Show("Something went wrong. Please try again");
                            MessageBox.Show(err.ToString());
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                }
                catch (SqlException err)
                {

                    MessageBox.Show(err.Message);
                }
                finally
                {

                    if (connection != null)
                    {
                        connection.Close();
                    }

                    reader.Close();
                }
            }
        }
    }
}
