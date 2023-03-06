using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeesController> _logger;
        public EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            _logger.LogInformation("Getting all employees");
            return Ok(_employeeService.GetAllEmployees());
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            _logger.LogInformation("Getting record for employee with id: {id}", id);
            var employee = _employeeService.GetEmployee(id);
            if (employee == null)
            {
                _logger.LogWarning("There is no employee with id: {id}", id);
                return NotFound();
            }
            _logger.LogDebug("Successfully retrieved record for employee with id: {id}", id);  
            return Ok(employee);
        }
        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            _logger.LogInformation("Inserting new employee");
            _employeeService.AddEmployee(employee);
            _logger.LogDebug("Successfully inserted record for new employee");
            return CreatedAtAction(nameof(GetEmployee),new {id = employee.EmpID}, employee);
        }
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, Employee employee)
        {
            _logger.LogInformation("Updating employee record with id: {id}", id);
            if (id != employee.EmpID)
            {
                _logger.LogWarning("There is no record to update for employee with id: {id}", id);
                return BadRequest();
            }
            _employeeService.UpdateEmployee(employee, id);
            _logger.LogDebug("Record for employee with id: {id} has been deleted", id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            _logger.LogInformation("Deleting employee record with id: {id}", id);
            Employee employee = _employeeService.GetEmployee(id);
            if(employee == null)
            {
                _logger.LogWarning("There is no record to delete for employee with id: {id}", id);
                return BadRequest();
            } 
            _employeeService.DeleteEmployee(id);
            _logger.LogDebug("Record for employee with id: {id} has been deleted", id);
            return NoContent();
        }

    }
}
