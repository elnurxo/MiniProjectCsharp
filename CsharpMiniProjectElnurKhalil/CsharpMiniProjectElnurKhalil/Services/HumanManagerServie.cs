using System;
using System.Collections.Generic;
using System.Text;
using CsharpMiniProjectElnurKhalil.Models;
using CsharpMiniProjectElnurKhalil.Interfaces;
using CsharpMiniProjectElnurKhalil.PositionsEnum;

namespace CsharpMiniProjectElnurKhalil.Services
{
    class HumanManagerService : IhumanResourceManager
    {
        private Department[] _departments;
        public Department[] Departments => _departments;
        public HumanManagerService()
        {
            _departments = new Department[0];
        }
        //METHOD TO CREATE NEW DEPARTMENT
        public void AddDepartment(string name, int workerlimit, double salarylimit)
        {
            Department department = new Department(name, workerlimit, salarylimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
            Console.WriteLine("Department Successfully Added!");

        }
        //METHOD TO LIST DEPARTMENTS
        public Department[] ListDepartment()
        {
            return _departments;
        }
        //METHOD TO LIST WORKERS
        public void ListofEmployee()
        {
        }
        //METHOD TO MAKE CHANGE ON EXISTING DEPARTMENT
        public void EditDepartment(string oldname, string newName)
        {
            foreach (Department item in Departments)
            {
                //if (item.Name == oldname)
                //{
                item.Name = newName;
                Console.WriteLine("The Change is Saved!");
                return;
            }
        }
        //METHOD TO MAKE CHANGE ON EXISTING WORKER
        public void EditEmployee()
        {
            throw new NotImplementedException();
        }
        //METHOD TO LIST WORKERS OF SELECTED DEPARTMENT
        public void GetDepartment()
        {
            foreach (Department item in _departments)
            {
                Console.WriteLine(item);
            }
        }
        //METHOD TO REMOVE THE WORKER
        public void RemoveEmployee(string depname, string workerno, string workername)
        {
            Department department = null; 
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == depname.ToLower())
                {
                    department = item;
                    break;

                }

            }
            Employee employee = null;

            if (department != null)
            {
                foreach (Employee item in department.Employees)
                {

                    if (item.FullName.ToUpper() == workername.ToUpper())
                    {
                        employee = item;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ther is no such Department!");
            }
            if (employee != null)
            {
                foreach (var item in department.Employees)
                {
                    if (item.No.ToUpper() == workerno.ToUpper())
                    {
                        int index = Array.IndexOf(department.Employees, employee);
                        Array.Clear(department.Employees, index, 1);
                        Console.WriteLine("Worker successfully Removed!");
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no such worker in Department!");
            }
        }
        //METHOD TO CREATE NEW WORKER
        public void AddEmployee(string fullname, Enums position, int salary, int departmentindex)
        {
            Department department = _departments[departmentindex];
            if (department.WorkerLimit > department.Employees.Length)
            {
                if (department.SalaryLimit > salary)
                {
                    Employee employee = new Employee(fullname, position, salary, department);
                    department.AddEmployye(employee);
                    Console.WriteLine("Worker is Created!");
                    return;
                }
                else
                {
                    Console.WriteLine("You have exceeded the Salary Limit!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("You have exceeded the Worker Limit!");
                return;
            }
        }
        //METHOD TO SHOW INFO OF DEPARTMENT
        public void InfoDepartment()
        {

            foreach (var item in Departments)
            {
                for (int i = 0; i < Departments.Length; i++)
                {
                    if (item.Employees == null)
                    {
                        i++;
                    }
                    else
                    {
                        Console.WriteLine($"Department Name: {item.Name} || Number of Workers: {item.Employees.Length}  || Average Salary : {item.CalcSum()}");
                        break;
                    }
                }
            }
        }
        //METHOD TO MAKE CHANGE ON EXISTING EMPLOYEE
        public void EditEmployee(string no, double salary, Enums position)
        {
        }
    }
}
