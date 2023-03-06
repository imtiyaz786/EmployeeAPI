using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; }
        public string? DeptName { get; set; }
    }
}
