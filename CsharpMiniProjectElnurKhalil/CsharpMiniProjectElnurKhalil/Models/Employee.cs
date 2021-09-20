using CsharpMiniProjectElnurKhalil.PositionsEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpMiniProjectElnurKhalil.Models
{
    //THIS CLASS CONTAINS INFORMATION ABOUT EMPLOYEEES
    class Employee
    {
        private static int _no = 1000;
        public string No;
        public string FullName;
        public Enums Position;
        public double Salary;
        public string DepartmentName;

        //CONSTRUCTOR TO SET NEEDED VALUES BEFORE CREATING OBJECT
        public Employee(string fullname, Enums position, double salary, Department departmentname)
        {
            _no++;
            FullName = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentname.Name;
            No = departmentname.Name.Substring(0, 2).ToUpper() + _no;
        }
    }
   
}
