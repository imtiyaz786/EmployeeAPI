using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public interface IDepartmentService
    {
        public IEnumerable<Department> GetAllDepartments();
        public Department GetDepartment(int id);
        public void AddDepartment(Department department);
        public void UpdateDepartment(Department department, int id);
        public void DeleteDepartment(int id);
    }
}
