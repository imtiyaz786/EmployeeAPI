using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [ForeignKey("Department")]
        public int DeptID { get; set; }
    }
    
}
