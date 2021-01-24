using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMVC.Model;
using TestMVC.Service.Process;

namespace TestMVC.WebAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProcess _employeeProcess;
        public EmployeeController(IEmployeeProcess employeeProcess)
        {
            _employeeProcess = employeeProcess;
        }
        [HttpGet]
        public async Task<ActionResult<List<SalaryDTO>>> Employee()
        {
            var result = await _employeeProcess.EmployeeGet(null);
            return Ok(result);
        }
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<List<SalaryDTO>>> Employee(int id)
        {
            var result = await _employeeProcess.EmployeeGet(id);
            return Ok(result);
        }
    }
}