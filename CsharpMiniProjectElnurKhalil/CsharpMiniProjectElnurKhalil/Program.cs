using System;
using CsharpMiniProjectElnurKhalil.PositionsEnum;
using System.Linq;
using CsharpMiniProjectElnurKhalil.Services;

namespace CsharpMiniProjectElnurKhalil
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanManagerService programcs = new HumanManagerService();
        #region Menu Console WriteLine
            #region Design
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"                ▄█     █▄     ▄████████  ▄█        ▄████████  ▄██████▄    ▄▄▄▄███▄▄▄▄      ▄████████ 
                ███     ███   ███    ███ ███       ███    ███ ███    ███ ▄██▀▀▀███▀▀▀██▄   ███    ███ 
                ███     ███   ███    █▀  ███       ███    █▀  ███    ███ ███   ███   ███   ███    █▀
                ███     ███  ▄███▄▄▄     ███       ███        ███    ███ ███   ███   ███  ▄███▄▄▄
                ███     ███ ▀▀███▀▀▀     ███       ███        ███    ███ ███   ███   ███ ▀▀███▀▀▀
                ███     ███   ███    █▄  ███       ███    █▄  ███    ███ ███   ███   ███   ███    █▄
                ███ ▄█▄ ███   ███    ███ ███▌    ▄ ███    ███ ███    ███ ███   ███   ███   ███    ███ 
                ▀███▀███▀    ██████████ █████▄▄██ ████████▀   ▀██████▀   ▀█   ███   █▀    ██████████ 
                                                                                     ");
        #endregion
        tryagain:
            Console.WriteLine("\t\t\t\t\t\t- -DEPARTMENT MANAGEMENT SYSTEM- -");
            Console.WriteLine("\t\t\t\t\t* * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("\t\t\t\t\t1.List of Departaments");
            Console.WriteLine("\t\t\t\t\t2.Create a Departament");
            Console.WriteLine("\t\t\t\t\t3.Make changes on Departament");
            Console.WriteLine("\t\t\t\t\t4.List of Workers");
            Console.WriteLine("\t\t\t\t\t5.List of workers of Department");
            Console.WriteLine("\t\t\t\t\t6.Add new Worker");
            Console.WriteLine("\t\t\t\t\t7.Make changes on Worker");
            Console.WriteLine("\t\t\t\t\t8.Remove worker from Departament");
            Console.WriteLine("\t\t\t\t\t9.Exit");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            #endregion
            Console.Write("Enter the Operation that you want to Perform : ");
            string enter = Console.ReadLine();
            int ienter;
            while (!int.TryParse(enter, out ienter))
            {
                Console.Write("Enter the Operation that you want to Perform :");
                enter = Console.ReadLine();
            }           
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - -");
            switch (ienter)
            {
                #region CASE 1
                case 1:
                    programcs.InfoDepartment();
                    goto tryagain;
                #endregion
                #region CASE 2
                case 2:
                    AddDepartment(ref programcs);
                    goto tryagain;
                #endregion
                #region CASE 3
                case 3:
                    EditDepartment(ref programcs);
                    goto tryagain;
                #endregion
                #region CASE 4
                case 4:
                    ShowEmployees(ref programcs);
                    goto tryagain;
                #endregion
                #region CASE 5
                case 5:
                    programcs.ListDepartment();
                    Console.Write("Enter Department Name: ");
                    string dprtname = Console.ReadLine();

                    foreach (var item in programcs.ListDepartment())
                    {
                        if (item.Name.ToUpper() == dprtname.ToUpper())
                        {
                            for (int i = 0; i < item.Employees.Length; i++)
                            {
                                foreach (var item1 in item.Employees)
                                {
                                    if (item1.FullName != null)
                                    {
                                        Console.WriteLine($"Full Name: {item1.FullName} \nNo: {item1.No} \nDepartment: {item1.DepartmentName} \nPosition: {item1.Position} \nSalary: {item1.Salary}");
                                        break;
                                    }
                                    else
                                    {
                                        i++;
                                    }
                                }
                            }
                        }

                    }
                    goto tryagain;
                #endregion
                #region CASE 6
                case 6:
                    AddEmployee(ref programcs);
                    goto tryagain;
                #endregion
                #region CASE 7
                case 7:
                    EditEmployee(ref programcs);
                    goto tryagain;
                #endregion
                #region CASE 8
                case 8:
                    RemoveEmoployee(ref programcs);
                    goto tryagain;
                #endregion
                #region CASE 9
                case 9:
                    Console.WriteLine("Successfully Logged Out from the System!");
                    Console.WriteLine(DateTime.Now);                  
                    return;
                #endregion
                #region DEFAULT CASE
                default:
                    Console.WriteLine("Make Sure that you entered correct Information!");
                    Console.WriteLine("Please Try Again : ");
                    goto tryagain;
                    #endregion

            }
        }
        //METHOD TO CREATE NEW DEPARTMENT
        static void AddDepartment(ref HumanManagerService programcs)
        {
            tryagain1:
            Console.Write("Enter the Name of Department:");
            string name = Console.ReadLine();
            if (name.Length<=1)
            {
                Console.WriteLine("Department Name cannot be less than 2 letters. Please Try Again!");
                goto tryagain1;
            }
        ChoiseWorkerLimit:
            Console.Write("Enter Worker Limit of Department:");
            int workerlimit;
            bool number = int.TryParse(Console.ReadLine(), out workerlimit);
            if (!number)
            {
                Console.WriteLine(
                    "\n" +
                    "Please Enter Integer Value!");
                goto ChoiseWorkerLimit;
            }
        tryagainsalarylimit:
        ChoiseSalaryLimit:
            Console.Write("Enter Salary Limit of Department:");
            double salarylimit;
            bool number1 = double.TryParse(Console.ReadLine(), out salarylimit);
            if (!number1)
            {
                Console.WriteLine(
                    "\n" +
                    "Please Enter Proper Value!");
                goto ChoiseSalaryLimit;
            }
            if (salarylimit > workerlimit * 250 && workerlimit >= 1)
            {
                programcs.AddDepartment(name, workerlimit, salarylimit);
                Console.WriteLine($"* * * * * * * * * * * * * * * * * * *\nDepartament Name:{name} \nWorker Limit of Department:{workerlimit} \nSalary Limit of Department: {salarylimit}\n* * * * * * * * * * * * * * * * * * *");
            }
            else
            {
                Console.WriteLine("Minimum Salary should be 250AZN per Worker \nMinimum Worker Limit shhould be at least 1!\n");
                Console.WriteLine("Please Try Again:");
                goto tryagainsalarylimit;
            }

        }
        //METHOD TO MAKE CHANGE ON EXISTING DEPARTMENT
        static void EditDepartment(ref HumanManagerService programcs)
        {
        tryagain1:
            Console.Write("Enter the Name of Department that you want to make changes about :");
            string oldname = Console.ReadLine();

            foreach (var item in programcs.Departments)
            {
                if (oldname == item.Name)
                {
                    Console.WriteLine("Department is found!");

                    Console.Write("Enter new name of Department:");
                    string newname = Console.ReadLine();
                    foreach (var item1 in programcs.Departments)
                    {
                        if (newname == item1.Name)
                        {
                            Console.WriteLine("There is a department with the name you entered!");

                            goto tryagain1;
                        }

                    }
                    if (item.Name == newname)
                    {
                        Console.WriteLine("The new name you enter is the same as the existing department name!");
                        goto tryagain1;
                    }
                    else
                    {
                        programcs.EditDepartment(oldname, newname);
                        foreach (var item1 in programcs.Departments)
                        {
                            foreach (var item2 in item1.Employees)
                            {
                                item2.No = item2.No.Replace(item2.No.Substring(0, 2), newname.ToUpper().Substring(0, 2));
                                item2.DepartmentName = newname;
                            }
                        }
                        Console.WriteLine("The Operation Was Performed Successfully!");
                        break;

                    }

                }
                else
                {
                    Console.WriteLine("There is no such Department!");
                    goto tryagain1;
                }

            }


        }
        //METHOD TO CREATE NEW EMPLOYEE
        static void AddEmployee(ref HumanManagerService programcs)
        {
            Console.Write("Name Surname:");
            string fullname = Console.ReadLine();

            for (int j = 0; j < programcs.Departments.Length; j++)
            {
                Console.WriteLine($"{j + 1} - {programcs.Departments[j].Name}");
            }
            tryagain2:
            Console.Write("Enter the Department number that you want to Add New Worker: ");
            string dprtStr = Console.ReadLine();
            int dprtInt;
            while (!int.TryParse(dprtStr, out dprtInt))
            {
                Console.Write("Enter the Department number that you want to Add New Worker:");
                dprtStr = Console.ReadLine();
            }
            if (dprtInt>programcs.Departments.Length)
            {
                Console.WriteLine("There's no such Depaertment, Please Try Again!");
                goto tryagain2;

            }
            string[] positiontype = Enum.GetNames(typeof(Enums));
            for (int i = 0; i < positiontype.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {positiontype[i]}");
            }
            string typestr;
            int typeint;
            Console.Write("Position:");
            typestr = Console.ReadLine();
            while (!int.TryParse(typestr, out typeint) || typeint < 1 || typeint > positiontype.Length)
            {
                Console.WriteLine("Please Try Again: ");
                typestr = Console.ReadLine();

            }
            Enums enums = (Enums)typeint;


        tryagain:
            Console.Write("Salary : ");
            int salary = Convert.ToInt32(Console.ReadLine());
            if (salary <= 250)
            {
                Console.WriteLine("Minimum Salary should be 250AZN");
                goto tryagain;
            }

            programcs.AddEmployee(fullname, enums, salary, (dprtInt - 1));
        }
        //METHOD TO MAKE CHANGE ON EXISTING EMPLOYEE
        static void EditEmployee(ref HumanManagerService programcs)
        {
            Console.WriteLine("Enter NO of Worker: ");

            string no = Console.ReadLine();
            foreach (var item in programcs.Departments)
            {
                foreach (var item1 in item.Employees)
                {
                    if (no == item1.No)
                    {
                        Console.WriteLine("Worker is Found!");
                        Console.WriteLine($"Full Name: {item1.FullName} \nPosition: {item1.Position} \nSalary: {item1.Salary} \n* * * * * * * * * * * * * * * * * * *");

                        // Positions
                        string[] positiontype = Enum.GetNames(typeof(Enums));
                        for (int i = 0; i < positiontype.Length; i++)
                        {
                            Console.WriteLine($"{i + 1} - {positiontype[i]}");
                        }

                        string typestr;
                        int typeint;
                        Console.Write("Position:");
                        typestr = Console.ReadLine();
                        while (!int.TryParse(typestr, out typeint) || typeint < 1 || typeint > positiontype.Length)
                        {
                            Console.WriteLine("Please Try Again: ");
                            typestr = Console.ReadLine();

                        }
                        Enums enums = (Enums)typeint;
                        item1.Position = enums;
                        Console.WriteLine("Done!");

                        Console.Write("Enter new Salary:");
                        double newsalary = int.Parse(Console.ReadLine());
                        item1.Salary = newsalary;

                        return;
                    }
                }
            }
        }
        //METHOD TO LIST EMPLOYEES
        static void ShowEmployees(ref HumanManagerService programcs)
        {

            foreach (var item in programcs.Departments)
            {

                foreach (var item1 in item.Employees)
                {

                    if (item1 != null)
                    {
                        Console.WriteLine($"NO: {item1.No} \nFull Name: {item1.FullName} \nPosition: {item1.Position} \nSalary: {item1.Salary}");

                    }
                }
            }

        }
        //METHOD TO REMOVE EXISTING EMPLOYEE
        static void RemoveEmoployee(ref HumanManagerService programcs)
        {
            Console.Write("Enter the department of the employee that you want to Delete:");
            string depname = Console.ReadLine();
            Console.Write("Enter Full Name of the employee that you want to Delete:");
            string workername = Console.ReadLine();
            Console.Write("Enter NO of the employee that you want to Delete:");
            string workerno = Console.ReadLine();
            programcs.RemoveEmployee(depname, workerno, workername);

        }
    }
}

