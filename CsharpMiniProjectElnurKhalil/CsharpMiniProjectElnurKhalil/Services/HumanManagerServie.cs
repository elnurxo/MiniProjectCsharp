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
                if (oldname==item.Name)
                {
                    item.Name = newName;
                    Console.WriteLine("The Change is Saved!");
                    return;
                }
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
                        for (int i = 0; i < department.Employees.Length; i++)
                        {
                            if (department.Employees[i]!=null)
                            {
                                continue;
                            }
                            for (int j = 0; j < department.Employees.Length; j++)
                            {
                                if (department.Employees[i]==null)
                                {
                                    continue;
                                    department.Employees[i] = department.Employees[j];
                                    department.Employees[j] = null;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no such worker in Department!");
            }
        }
        //METHOD TO CREATE NEW WORKER
        public void AddEmployee(string fullname, Enums position, double salary, Department department)
        {
            if (department.WorkerLimit > department.Employees.Length)
            {
                if (department.SalaryLimit > CalcSalarySum() + salary)
                {
                    Employee employee = new Employee(fullname, position, salary, department);
                    department.AddEmployye(employee);
                    Console.WriteLine("Worker is Created!");
                    
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
        //METHOD TO CALCULATE ALL SALARY TO KNOW IF IT EXCEEDED SALARY LIMIT
        public double CalcSalarySum()
        {
            double sum = 0;
            foreach (var item in _departments)
            {
                foreach (var item2 in item.Employees)
                {
                    if (item2 != null)
                    {
                        sum = sum + item2.Salary;
                    }
                }
            }
            return sum;
        }
    }
}
