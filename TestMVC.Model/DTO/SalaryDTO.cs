namespace TestMVC.Model
{
    /// <summary>
    /// Data transfer Object Employee->
    /// </summary>
    public class SalaryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public string RoleName { get; set; }
        public decimal AnnualSalary { get; set; }
    }
}