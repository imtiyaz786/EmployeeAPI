using EmployeeAPI.Models;
using EmployeeAPI.Repositories;

namespace EmployeeAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void AddDepartment(Department department)
        {
            _departmentRepository.AddDepartment(department);
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.DeleteDepartment(id);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        public Department GetDepartment(int id)
        {
            return _departmentRepository.GetDepartment(id);
        }

        public void UpdateDepartment(Department department, int id)
        {

            _departmentRepository.UpdateDepartment(department, id);
        }
    }
}
