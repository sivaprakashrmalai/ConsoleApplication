using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CollegeAdmissionApplication{
    class Program{
            static List<AdmisionDetails> admisionDetail = new List<AdmisionDetails>();  //create list for admission details
            static List<DepartmentDetails> deptDetail = new List<DepartmentDetails>(); // create list for department detail.
            static List<StudentDetails> studentDetail = new List<StudentDetails>(); //create an list for student detail.
            static StudentDetails logedStudent;
        public static void Main(){
            
            Console.WriteLine("Syncfusion college of Engineering and Technology:");
            
            DefaultValues();  //method calling for default values.
            bool exit1 = false;
            do
            {
                Console.WriteLine("Main Menu");  //main menu
                Console.WriteLine("Option 1 : Student Registration");
                Console.WriteLine("Option 2 : Student Login");
                Console.WriteLine("Option 3 : Department wise Seat Availability");
                Console.WriteLine("Option 4 : Exit");
                Console.WriteLine("Enter the Option:");
                string option = Console.ReadLine().Trim();

                switch(option)
                {
                    case "1":
                    {
                        Console.WriteLine("STUDENT REGISTRATION FORM: ");
                        Console.WriteLine();

                        StudentRegistration();  //method calling for studentRegistration
                        break;
                    }

                    case "2":
                    {
                        StudentLogin();   //method calling for StudentLogin.
                        break;
                    }
                    case "3":
                    {
                        DepartmentWiseSeatAvailable();  //method calling for department details.
                        break;
                    }
                    case "4":
                    {
                        exit1 = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please choose a correct option.");
                        break;
                    }
                        
                }
            }while(!exit1); 
            
        }

        public static void DefaultValues()   //method creation for default values stored into the lists.
        {
            StudentDetails std1 = new StudentDetails("Ravichandran E","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentDetails std2 = new StudentDetails("Baskaran S","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            
            studentDetail.Add(std1);
            studentDetail.Add(std2);

            DepartmentDetails dept1 = new DepartmentDetails("EEE",29);
            DepartmentDetails dept2 = new DepartmentDetails("CSE",29);
            DepartmentDetails dept3 = new DepartmentDetails("MECH",30);
            DepartmentDetails dept4 = new DepartmentDetails("ECE",30);
            
            deptDetail.Add(dept1);
            deptDetail.Add(dept2);
            deptDetail.Add(dept3);
            deptDetail.Add(dept4);

            AdmisionDetails ads1 = new AdmisionDetails("SF3001","DID101",new DateTime(2022,05,11),AdmissionStatus.Booked);
            AdmisionDetails ads2 = new AdmisionDetails("SF3002","DID102",new DateTime(2022,05,12),AdmissionStatus.Booked);
            
            admisionDetail.Add(ads1);
            admisionDetail.Add(ads2);
           
        }

        public static void StudentRegistration()  //method creation for student registration.
        {
            // Collect details from User:
            string name;
            bool nameCheck;
            do
            {
                nameCheck=false;
                Console.WriteLine("Enter your Name: ");  
                name = Console.ReadLine().Trim();
                if(name.Contains("  ") || string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Enter your name properly");
                    nameCheck = true;
                }
                else
                {
                    for(int i=0;i<name.Length;i++)
                    {
                        if(char.IsPunctuation(name[i]) || char.IsDigit(name[i]))
                        {
                            Console.WriteLine("Enter your name properly");
                            nameCheck = true;
                            break;
                        }
                    }
                }
                
                
            }while(nameCheck);

            // Collect details from User:
            string fatherName;
            bool fnameCheck;
            do
            {
                fnameCheck=false;
                Console.WriteLine("Enter your father Name: ");
                fatherName = Console.ReadLine().Trim();

                if(fatherName.Contains("  ") || string.IsNullOrWhiteSpace(fatherName))
                {
                    Console.WriteLine("Enter your fathername properly");
                    fnameCheck = true;
                }
                else
                {
                    for(int i=0;i<fatherName.Length;i++)
                    {
                        if(char.IsPunctuation(fatherName[i]) || char.IsDigit(fatherName[i]))
                        {
                            Console.WriteLine("Enter your fathername properly");
                            fnameCheck = true;
                            break;
                        }
                    }
                
                }
                
            }while(fnameCheck);

            DateTime dob;
            bool dobCheck2;
            do
            {
                dobCheck2=false;
                Console.WriteLine("Enter DateOfBirth (dd/MM/yyyy): ");
                bool dobCheck = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dob);
                if(!dobCheck )
                {
                    Console.WriteLine("Please enter your date of birth in correct format");
                    dobCheck2=true;
                }
                if(DateTime.Now.Year-16 < dob.Year)
                {
                    Console.WriteLine("this course only for 18 age students.");
                    dobCheck2=true;
                }

            }while(dobCheck2);
                        
            bool gendercheck1=true;
            Gender gender=0;
            do
            {
                gendercheck1 = true;
                Console.WriteLine("Enter Your Gender");
                string userGender = Console.ReadLine().Trim();
                if(Enum.TryParse<Gender>(userGender,true,out gender))
                {
                    if(!Regex.IsMatch(userGender,@"[a-zA-Z]+$"))
                    {
                        Console.WriteLine("Enter Your Gender Correctly, please enter male,female, or others.");
                        gendercheck1=false;
                    }
                }
                else
                {
                    Console.WriteLine("Enter Your Gender Correctly, please enter male,female, or others.");
                    gendercheck1=false;
                }
            }while(!gendercheck1);

            bool phyCheck;
            double physics;
            do
            {
                phyCheck=false;
                Console.WriteLine("Enter Your Physics");
                bool phyCheck2 = double.TryParse(Console.ReadLine().Trim(),null,out physics);
                if(!phyCheck2)
                {
                    Console.WriteLine("Please Enter The Correct Physics mark: ");
                    phyCheck=true;
                }
                else
                {
                    if(physics<35)
                    {
                        Console.WriteLine("Sorry,You Are Not Eligible");
                        return;
                    }
                    else if( physics != Math.Round(physics,2) || physics>100 || physics<0)
                    {
                        Console.WriteLine("Please Enter The Correct Physics mark");
                        phyCheck=true;
                    }
                    
                }
                    
            }while(phyCheck);

            bool chyCheck;
            double chemistry;
            do
            {
                chyCheck=false;
                Console.WriteLine("Enter Your Chemistry mark.");
                bool chyCheck2 = double.TryParse(Console.ReadLine().Trim(),null,out chemistry);
                if(!chyCheck2)
                {
                    Console.WriteLine("Please Enter The Correct chemisry mark: ");
                    chyCheck=true;
                }
                else
                {
                    if(chemistry<35)
                    {
                        Console.WriteLine("Sorry,You Are Not Eligible");
                        return;
                    }
                    else if( chemistry != Math.Round(chemistry,2) || chemistry>100 || chemistry<0)
                    {
                        Console.WriteLine("Please Enter The Correct chemistry mark");
                        chyCheck=true;
                    }
                    
                }
                    
            }while(chyCheck);

             bool mathCheck;
            double maths;
            do
            {
                mathCheck=false;
                Console.WriteLine("Enter Your Maths mark");
                bool mathCheck2 = double.TryParse(Console.ReadLine().Trim(),null,out maths);
                if(!mathCheck2)
                {
                    Console.WriteLine("Please Enter The Correct Maths mark: ");
                    mathCheck=true;
                }
                else
                {
                    if(maths<35)
                    {
                        Console.WriteLine("Sorry,You Are Not Eligible");
                        return;
                    }
                    if( maths != Math.Round(maths,2) || maths > 100 && maths<0)
                    {
                        Console.WriteLine("Please Enter The Correct maths mark");
                        mathCheck=true;
                    }
                    
                }
                    
            }while(mathCheck);

            StudentDetails student = new StudentDetails(name,fatherName,dob,gender,physics,chemistry,maths);  //store all the information into the object of class

            studentDetail.Add(student);  // store ann object of class into te list.
                    
            Console.WriteLine("Student Register Successfully and StudentID is: "+student.StudentID);  //Show student  the student id.
        }

        public static void StudentLogin()    //method creation for student login
        {
            Console.WriteLine("Student Login: ");
            Console.WriteLine("Enter your StudentID");  //ask student id from student
            string stdID = Console.ReadLine().ToUpper();
            int idx = studentDetail.FindIndex(c=>c.StudentID == stdID);   //check student id in student list.

            if(idx == -1)
            {
                Console.WriteLine("Invalid StudentID, please Try Again");
            }

            else
            {
                bool exit2 = false;
                logedStudent = studentDetail[idx];
                do
                {
                    Console.WriteLine("Sub Menu...");
                    Console.WriteLine("option 1 : Check Eligibility");
                    Console.WriteLine("option 2 : Show Details");
                    Console.WriteLine("option 3 : Take Admission");
                    Console.WriteLine("option 4 : Cancel Admission");
                    Console.WriteLine("option 5 : Show Admission Details");
                    Console.WriteLine("option 6 : Exit");

                    Console.WriteLine("Enter the option to choose the sub menu:");
                    string option2 = Console.ReadLine().Trim();

                    switch(option2)
                    {
                        case "1":
                        {
                            if(CheckEligibility()) //method calling for eligibility:
                            {
                                Console.WriteLine("Student is Eligible to take admission");
                            }
                            else
                            {
                                Console.WriteLine("Student is not Eligible");
                            }
                            break;
                        }
                        case "2":
                        {
                            StudentInfo();  //method calling for student info
                            break;
                        }
                        case "3":
                        {
                            TakeAdmission();  //method calling for take admission
                            break;                          
                        }
                        case "4":
                        {
                            CancelAdmission();      // method calling for cancel admission.
                            break;
                        }

                        case "5":
                        {
                           ShowAdmissionDetails();   // method calling for showadmissiondetails.
                           break;
                        }
                        case "6":
                        {
                            exit2 = true;
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Please choose a correct option.");
                            break;
                        }
                    }
                }while(!exit2);
            }             
        }
        
        public static bool CheckEligibility()   //method creation for eligibility
        {  
            if((logedStudent.Physics+logedStudent.Chemistry+logedStudent.Maths)/3 >= 75)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void StudentInfo()   //method creation for student information.
        {
            foreach(StudentDetails std in studentDetail)
            {
                if(std.StudentID == logedStudent.StudentID)
                {
                    Console.WriteLine("student ID "+ std.StudentID+" student Name: "+std.Name+" Father Name: "+std.FatherName+" Date Of Birth: "+std.DOB+" Gender: "+std.Gender+" Physics Mark: "+std.Physics+" Chemistry Mark: "+std.Chemistry+" Maths Mark: "+std.Maths);
                    break;
                }
            }
        }  

        public static void TakeAdmission()  //method creation for take admission.
        {
            Console.WriteLine("The below Departments Are Available");
            bool check2=false;

            DepartmentWiseSeatAvailable(); //method calling for seat available in every department:
            
            Console.WriteLine("Enter the department ID"); //ask department id from student
            string deptID = Console.ReadLine().ToUpper();
                                                    
            for(int i=0;i<deptDetail.Count;i++)
            {
                bool check3 = false;
                                                        
                if(deptDetail[i].DepartmentID == deptID)  //check department is available or not
                {
                    check2 = true;
                    if(CheckEligibility()==false)   
                    {  
                        Console.WriteLine("Student is not Eligible");
                        break;
                    }
                        
                    else
                    {
                        if(deptDetail[i].NumberOfSeat > 0)  // check seat is available or not in the department
                        { 

                            check3 = false;
                            for(int j=0;j<admisionDetail.Count;j++) // check student is already admitted or not
                            {
                                if(admisionDetail[j].StudentID == logedStudent.StudentID && admisionDetail[j].AdmissionStatus==AdmissionStatus.Booked)
                                {
                                    check3 = true;
                                    Console.WriteLine("You are Already Admitted");
                                    break;
                                }
                                                                        
                            }
                            if(!check3)  // if not admitted then take admission.
                            {
                                deptDetail[i].NumberOfSeat--;
                                            
                                AdmisionDetails admission = new AdmisionDetails(logedStudent.StudentID,deptDetail[i].DepartmentID,DateTime.Now,AdmissionStatus.Booked);
                                admisionDetail.Add(admission);

                                Console.WriteLine("Admission Took Successfully. your Admission ID is "+admission.AdmissionID);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("This Department seat is full, so please another department.");
                            break;
                        }
                    }
                }
                if(check3)
                {
                    break; 
                }
                                                    
            }
            if(!check2)
            {
                Console.WriteLine("Invalid Department ID ,Please enter correct DEPT id:");
            }
           
        }
        public static void CancelAdmission()  //create an method for cancel method,.
        {
            for(int i=0;i<admisionDetail.Count;i++)
            {
                if(admisionDetail[i].StudentID == logedStudent.StudentID && admisionDetail[i].AdmissionStatus==AdmissionStatus.Booked) //check student id is booked or not.
                {
                    Console.WriteLine("AdmissionID : "+admisionDetail[i].AdmissionID);
                    Console.WriteLine("StudentID : "+admisionDetail[i].StudentID);
                    Console.WriteLine("DepartmentID : "+admisionDetail[i].DepartmentID);
                    Console.WriteLine("Admission Date : "+admisionDetail[i].AddmissionDate);
                    Console.WriteLine("Admission Status : "+admisionDetail[i].AdmissionStatus);
                    Console.WriteLine();
                    admisionDetail[i].AdmissionStatus = AdmissionStatus.Cancelled;
                    for(int j=0;j<deptDetail.Count;j++)
                    {
                        if(deptDetail[j].DepartmentID == admisionDetail[i].DepartmentID)
                        {
                            deptDetail[j].NumberOfSeat++;
                            break;
                        }
                    }
                    break;
                }
            }
            Console.WriteLine("Your Admission has been Successfully cancelled");
                                      
        }

        public static void ShowAdmissionDetails()  //create an method for show admission detail.
        {
            for(int i=0;i<admisionDetail.Count;i++)
            {
                if(admisionDetail[i].StudentID == logedStudent.StudentID && admisionDetail[i].AdmissionStatus==AdmissionStatus.Booked)
                {
                    Console.WriteLine("Admission ID: "+admisionDetail[i].AdmissionID+" Student ID: "+admisionDetail[i].StudentID+" Department ID: "+admisionDetail[i].DepartmentID+" Admission Date: "+admisionDetail[i].AddmissionDate+" Admission Status: "+admisionDetail[i].AdmissionStatus);                               
                    break;
                }
            }
        }

        public static void DepartmentWiseSeatAvailable()  //craete an method for show department detail.
        {
            foreach(DepartmentDetails std in deptDetail)
            {
                Console.Write("DepartMentID : "+std.DepartmentID+"   "+"DepartmentName : "+std.DepartmentName+"  "+"NoOFSeats : "+std.NumberOfSeat);
                Console.WriteLine();
            }
        }

    }  
}

    

