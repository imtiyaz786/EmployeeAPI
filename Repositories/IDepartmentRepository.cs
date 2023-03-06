using EmployeeAPI.Models;

namespace EmployeeAPI.Repositories
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
        public Department GetDepartment(int id);
        public void AddDepartment(Department department);
        public void UpdateDepartment(Department department, int id);
        public void DeleteDepartment(int id);
    }
}
