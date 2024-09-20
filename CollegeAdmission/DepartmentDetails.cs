using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmissionApplication
{
    public class DepartmentDetails
    {
        private static int _deptID = 100;
        
        public string DepartmentID{get;set;}
        public string DepartmentName{get;set;}
        public int NumberOfSeat{get;set;}

        public DepartmentDetails(string departmentName,int noOfSeat){
            this.DepartmentID = "IDI"+ ++_deptID;
            this.DepartmentName = departmentName;
            this.NumberOfSeat = noOfSeat;
        }
    }
}