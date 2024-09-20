using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CollegeAdmissionApplication
{
    public enum Gender{Male,Female,Others};
    public class StudentDetails
    {
        private static int _studentID = 3000;

        public string StudentID{get;set;}
        public string Name{get;set;}
        public string FatherName{get;set;}
        public DateTime DOB{get;set;}
        public Gender Gender{get;set;}
        public double Physics{get;set;}
        public double Chemistry{get;set;}
        public double Maths{get;set;}

        public StudentDetails(string name,string fatherName,DateTime dob,Gender gender,double physics,double chemistry, double maths){

            this.StudentID = "SF" + ++_studentID;
            this.Name = name;
            this.FatherName = fatherName;
            this.DOB = dob;
            this.Gender = gender;
            this.Physics = physics;
            this.Chemistry = chemistry;
            this.Maths = maths;
        }

        
    }
}