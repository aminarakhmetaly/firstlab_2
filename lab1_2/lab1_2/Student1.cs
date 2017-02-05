using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_2
{
    class Student1//creating class student
    {
        public string Fname;
        public string Lname;
        public int course;
        public float gpa;


        public Student1(string Fname, string Lname, int course, float gpa)//konstruktor of a class
        {
            this.Fname = Fname;
            this.Lname = Lname;
            this.course = course;
            this.gpa = gpa;
        }
        public Student1(string Fname, string Lname, int course)
        {
            this.Fname = Fname;
            this.Lname = Lname;
            this.course = course;
        }

        public override string ToString()
        {
            return string.Format("Student\nFname:{0}\nLname: {1}\ncourse: {2}\ngpa: {3}", Fname, Lname, course, gpa);//outputing and formating
        }
    }
}
