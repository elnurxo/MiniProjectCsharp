using System;
using System.Collections.Generic;
using System.Text;
using CsharpMiniProjectElnurKhalil.PositionsEnum;
using CsharpMiniProjectElnurKhalil.Models;

namespace CsharpMiniProjectElnurKhalil.Interfaces
{
    interface IhumanResourceManager
    {
        // DEPARTMENT ARRAY
        Department[] Departments { get; }
        //METHOD TO ADD NEW DEPARTMENT
        public void AddDepartment(string name, int workerlimit, double salarylimit);
        // METHOD TO LIST DEPARTMENTS
        public Department[] ListDepartment();
        //METHOD TO MAKE CHANGE ON DEPARTMENTS
        public void EditDepartment(string oldname, string newname);
        // METHOD TO ADD NEW EMPLOYEE
        public void AddEmployee(string fullname, Enums position, int salary, int departmentindex);
        //METHOD TO REMOVE EXISTING EMPLOYEE
        public void RemoveEmployee(string depname, string workerno, string workername);
        //METHOD TO MAKE CHANGE ON EXISTING EMPLOYEE
        public void EditEmployee(string no, double salary, Enums position);
    }
}
