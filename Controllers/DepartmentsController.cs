using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentsController> _logger;
        public DepartmentsController(IDepartmentService departmentService, ILogger<DepartmentsController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetAllDepartments()
        {
            _logger.LogInformation("Getting all departments");
            return Ok(_departmentService.GetAllDepartments());
        }
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            _logger.LogInformation("Getting record for department with id: {id}", id);
            var department = _departmentService.GetDepartment(id);
            if (department == null)
            {
                _logger.LogWarning("There is no department with id: {id}", id);
                return NotFound();
            }
            _logger.LogDebug("Successfully retrieved record for department with id: {id}", id);
            return Ok(department);
        }
        [HttpPost]
        public ActionResult<Department> AddDepartment(Department department)
        {
            _logger.LogInformation("Inserting new department");
            _departmentService.AddDepartment(department);
            _logger.LogDebug("Successfully inserted record for new department");
            return CreatedAtAction(nameof(GetDepartment), new { id = department.DeptID}, department);
        }
        [HttpPut("{id}")]
        public ActionResult<Department> UpdateDepartment(int id, Department department)
        {
            _logger.LogInformation("Updating department records with id: {id}", id);
            if (id != department.DeptID)
            {
                _logger.LogWarning("There is no record to update for employee with id: {id}", id);
                return BadRequest();
            }
            _departmentService.UpdateDepartment(department, id);
            _logger.LogDebug("Record for department with id: {id} has been updated", id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartment(int id)
        {
            _logger.LogInformation("Deleting department record with id: {id}", id);
            var department = _departmentService.GetDepartment(id);
            if (department == null)
            {
                _logger.LogWarning("There is no record to delete for department with id: {id}", id);
                return BadRequest();
            }
            _departmentService.DeleteDepartment(id);
            _logger.LogDebug("Record for department with id: {id} has been deleted", id);
            return NoContent();
        }

    }
}




