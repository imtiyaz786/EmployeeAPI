using EmployeeAPI.Models;

namespace EmployeeAPI.Repositories
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployee(int id);
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee, int id);
        public void DeleteEmployee(int id);
    }
}
