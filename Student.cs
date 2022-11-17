using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281_Project_Group11
{
    internal class Student
    {
        private string name;
        private string surname;
        private string dob;
        private string gender;
        private string phone;
        private string address;

        

        public Student(string name, string surname, string dob, string gender, string phone, string address)
        {
            Name = name;
            Surname = surname;
            Dob = dob;
            Gender = gender;
            Phone = phone;
            Address = address;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public Student()
        {
        }
    }
}
