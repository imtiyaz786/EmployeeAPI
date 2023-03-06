using EmployeeAPI.Models;
using EmployeeAPI.Repositories;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        public void UpdateEmployee(Employee employee, int id)
        {
            _employeeRepository.UpdateEmployee(employee, id);
        }
    }
}
