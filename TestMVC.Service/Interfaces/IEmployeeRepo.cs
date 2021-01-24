using TestMVC.Service.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestMVC.Service.Interfaces
{
    public interface IEmployeeRepo : IDisposable
    {
        Task<List<Employee>> EmployeesGet();
    }
}