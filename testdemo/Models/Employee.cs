using System.ComponentModel.DataAnnotations;

namespace testdemo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? EmployeeName { get; set; }

        [Required]
        public string? EmployeePhone { get; set; }  

        public string? EmployeeEmail { get; set; }  

        public string? EmployeeAge { get; set; }  

        public string? EmployeeSalary { get; set; } 


    }
}
