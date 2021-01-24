using TestMVC.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestMVC.Service.Process
{
    public interface IEmployeeProcess
    {
        Task<List<SalaryDTO>> EmployeeGet(int? id);
    }
}