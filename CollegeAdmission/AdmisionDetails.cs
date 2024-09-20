using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmissionApplication
{
    public enum AdmissionStatus{Booked,Cancelled};
    public class AdmisionDetails
    {
        private static int _admissionID = 1000;

        public string AdmissionID{get;set;}
        public string StudentID{get;set;}
        public string DepartmentID{get;set;}
        public DateTime AddmissionDate{get;set;}
        public AdmissionStatus AdmissionStatus{get;set;}

        public AdmisionDetails(string studentID,string departmentID,DateTime date,AdmissionStatus status)
        {
            this.AdmissionID = "ADI" + ++_admissionID;
            this.StudentID = studentID;
            this.DepartmentID = departmentID;
            this.AddmissionDate = date;
            this.AdmissionStatus =status;
        }

       
    }
}