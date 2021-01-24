using TestMVC.Model;
using TestMVC.Service.Entities;
using TestMVC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVC.Service.Process
{
    public class EmployeeProcess : IEmployeeProcess
    {
        private readonly IEmployeeRepo _employeeRepo;

        /// <summary>
        /// inyeccion de dependencias para el repo ->
        /// </summary>
        /// <param name="employeeRepo"></param>
        public EmployeeProcess(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        /// <summary>
        /// obtener employee ->
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<SalaryDTO>> EmployeeGet(int? id)
        {
            try
            {
                List<Employee> result = await ReadEmployees(id);
                return ProcessEmployees(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Proceso de calculo ->
        /// </summary>
        /// <param name="result">lista de empleados</param>
        /// <returns></returns>
        private List<SalaryDTO> ProcessEmployees(List<Employee> result)
        {
            List<SalaryDTO> employeesDTO = new List<SalaryDTO>();
            foreach (Employee item in result)
            {
                Employee employee = GetEmployee(item);

                if (employee != null)
                {
                    SalaryDTO employeeDTO = new SalaryDTO();
                    employeeDTO.Id = item.Id;
                    employeeDTO.Name = item.Name;
                    employeeDTO.RoleName = item.RoleName;
                    employeeDTO.ContractTypeName = item.ContractTypeName;
                    employeeDTO.AnnualSalary = employee.AnnualSalary.Value;
                    employeesDTO.Add(employeeDTO);
                }
            }
            return employeesDTO;
        }

        /// <summary>
        /// filtro de empleado por id ->
        /// </summary>
        /// <param name="id">id Employee</param>
        /// <returns></returns>
        private async Task<List<Employee>> ReadEmployees(int? id)
        {
            List<Employee> result = await _employeeRepo.EmployeesGet();
            if (id.HasValue)
            {
                result = result.Where(x => x.Id == id).ToList();
            }

            return result;
        }

        /// <summary>
        /// creacion de objeto employee ->
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        public Employee GetEmployee(Employee Employee)
        {
            return Employee.ContractTypeName.ToLower() == "hourlysalaryemployee" ?
                new Hourly(Employee) :
                (Employee)new Monthly(Employee);
        }
    }
}