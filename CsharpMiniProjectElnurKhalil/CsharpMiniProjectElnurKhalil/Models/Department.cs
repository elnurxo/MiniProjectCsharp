using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpMiniProjectElnurKhalil.Models
{
    //THIS CLASS CONTAINS INFORMATION ABOUT DEPARTMENTS
    class Department
    {
        public string Name;
        public int WorkerLimit;
        public double SalaryLimit;
        public Employee[] Employees;

        public Department(string name, int workerlimit, double salarylimit)
        {
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
            Employees = new Employee[0];
        }
        // METHOD TO ADD NEW EMPLOYEE TO RESIZED ARRAY
        public void AddEmployye(Employee employee)
        {
            Array.Resize(ref Employees, Employees.Length + 1);
            Employees[Employees.Length - 1] = employee;

        }
        // METHOD TO CALCULATE AVERAGE SALARY
        public double CalcSum()
        {
            double sum = 0;
            foreach (var item in Employees)
            {
                sum += item.Salary;
            }
            double average = sum / Employees.Length;
            return average;
        }


    }
}
