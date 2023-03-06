using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployee(int id);
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee, int id);
        public void DeleteEmployee(int id);
    }
}
