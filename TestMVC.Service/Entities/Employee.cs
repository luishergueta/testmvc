namespace TestMVC.Service.Entities
{
    /// <summary>
    /// Entidad employee->
    /// </summary>
    public class Employee
    {
        public int Id;
        public string Name;
        public string ContractTypeName;
        public int RoleId;
        public string RoleName;
        public string RoleDescription;
        public decimal HourlySalary;
        public decimal MonthlySalary;
        public decimal? AnnualSalary;
    }
}