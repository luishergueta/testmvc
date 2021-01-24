using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMVC.Data.Repository;
using TestMVC.Service.Process;
using System.Net.Http;
using System.Threading.Tasks;
using TestMVC.Model;
using System.Collections.Generic;
using TestMVC.Service.Interfaces;
using TestMVC.Service.Entities;

namespace TestMVC.TestUnit
{
    [TestClass]
    public class UnitTest1
    {
        async Task<List<Employee>> EmployeeFake()
        {
            return new List<Employee>() {
                new Employee()
                { Name = "Luis",AnnualSalary=null, MonthlySalary = 10000, HourlySalary = 2500, ContractTypeName = "HourlySalaryEmployee", Id = 9, RoleName = "Contable" },
                new Employee()
                { Name = "David", AnnualSalary=null, MonthlySalary = 15000, HourlySalary = 200000, ContractTypeName = "MonthlySalaryEmployee", Id = 10, RoleName = "Admin" }
            };
        }
        [DataTestMethod]
        [DataRow(null)]
        public async Task GetEmployee_ShouldReturnEmployees(int? value)
        {
            // Arrange
            var valueExpected = true;

            // Act
            var mock = new Mock<IEmployeeRepo>();
            mock.Setup(p => p.EmployeesGet()).Returns(EmployeeFake());
            var service = new EmployeeProcess(mock.Object);
            var result = await service.EmployeeGet(value);

            // Assert
            Assert.AreEqual(valueExpected, result.Count > 1);
        }
        [DataTestMethod]
        [DataRow(2)]
        public async Task GetEmployee_ShouldNotReturnOneEmployees(int? value)
        {
            // Arrange
            var valueExpected = 0;

            // Act
            var mock = new Mock<IEmployeeRepo>();
            mock.Setup(p => p.EmployeesGet()).Returns(EmployeeFake());
            var service = new EmployeeProcess(mock.Object);
            var result = await service.EmployeeGet(value);

            // Assert
            Assert.AreEqual(valueExpected, result.Count);
        }
        [DataTestMethod]
        [DataRow(9)]
        [DataRow(10)]
        public async Task GetEmployee_ShouldReturnOneEmployee(int? value)
        {
            // Arrange
            var valueExpected = 1;

            // Act
            var mock = new Mock<IEmployeeRepo>();
            mock.Setup(p => p.EmployeesGet()).Returns(EmployeeFake());
            var service = new EmployeeProcess(mock.Object);
            var result = await service.EmployeeGet(value);

            // Assert
            Assert.AreEqual(valueExpected, result.Count);
        }
        [DataTestMethod]
        [DataRow(9)]
        public async Task GetEmployee_ShouldReturnCalcEmployee9(int? value)
        {
            // Arrange
            var valueExpected = 3600000;

            // Act
            var mock = new Mock<IEmployeeRepo>();
            mock.Setup(p => p.EmployeesGet()).Returns(EmployeeFake());
            var service = new EmployeeProcess(mock.Object);
            var result = await service.EmployeeGet(value);

            // Assert
            Assert.AreEqual(valueExpected, result[0].AnnualSalary);
        }
        [DataTestMethod]
        [DataRow(10)]
        public async Task GetEmployee_ShouldReturnCalcEmployee10(int? value)
        {
            // Arrange
            var valueExpected = 180000;

            // Act
            var mock = new Mock<IEmployeeRepo>();
            mock.Setup(p => p.EmployeesGet()).Returns(EmployeeFake());
            var service = new EmployeeProcess(mock.Object);
            var result = await service.EmployeeGet(value);

            // Assert
            Assert.AreEqual(valueExpected, result[0].AnnualSalary);
        }
    }
}