using TestMVC.Service.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestMVC.Service.Process
{
    public class Hourly:Employee
    {
        /// <summary>
        /// Calculo del AnnualSalary por hora
        /// </summary>
        /// <param name="Employee"></param>
        public Hourly(Employee Employee)
        {
            Id = Employee.Id;
            Name = Employee.Name;
            ContractTypeName = Employee.ContractTypeName;
            RoleId = Employee.RoleId;
            RoleName = Employee.RoleName;
            RoleDescription = Employee.RoleName;
            HourlySalary = Employee.HourlySalary;
            MonthlySalary = Employee.MonthlySalary;
            AnnualSalary = 120 * Employee.HourlySalary * 12;
        }
    }
}