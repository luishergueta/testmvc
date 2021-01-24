using TestMVC.Service.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestMVC.Service.Process
{
    public class Monthly:Employee
    {
        /// <summary>
        /// Calculo del AnnualSalary por mes
        /// </summary>
        /// <param name="Employee"></param>
        public Monthly(Employee Employee)
        {
            Id = Employee.Id;
            Name = Employee.Name;
            ContractTypeName = Employee.ContractTypeName;
            RoleId = Employee.RoleId;
            RoleName = Employee.RoleName;
            RoleDescription = Employee.RoleName;
            HourlySalary = Employee.HourlySalary;
            MonthlySalary = Employee.MonthlySalary;
            AnnualSalary = Employee.MonthlySalary * 12;
        }
    }
}