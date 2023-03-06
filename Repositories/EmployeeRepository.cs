using EmployeeAPI.Models;
using System.Data.SqlClient;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string? connectionString = Environment.GetEnvironmentVariable("EmployeeDBConnection", EnvironmentVariableTarget.Machine);
        public IEnumerable<Employee> GetAllEmployees()
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            List<Employee> employees = new();
            using SqlCommand command = new("select * from employees", connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(new Employee { 
                EmpID = (int)reader["EmpID"], FirstName = (string)reader["FirstName"], LastName = (string)reader["LastName"], DeptID = (int)reader["DeptID"] });
            }
 
            return employees;
        }
        public Employee GetEmployee(int id)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            Employee? employee = null;
            using SqlCommand command = new("select * from employees where EmpID = @EmpID", connection);
            command.Parameters.AddWithValue("@EmpID", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                employee = new Employee() { EmpID = (int)reader["EmpID"], FirstName = (string)reader["FirstName"], LastName = (string)reader["LastName"], DeptID = (int)reader["DeptID"] };


            }
            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using SqlCommand command = new("Insert into employees (FirstName, LastName, DeptID) values (@FirstName, @LastName, @DeptID)", connection);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@DeptID", employee.DeptID);
            command.ExecuteNonQuery();
        }


        public void UpdateEmployee(Employee employee, int id)
        {

            using SqlConnection connection = new(connectionString);
            connection.Open();
            using SqlCommand command = new("Update employees set FirstName = @FirstName, LastName = @LastName, DeptID = @DeptID where EmpID = @EmpID", connection);
            command.Parameters.AddWithValue("@EmpID", id);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@DeptID", employee.DeptID);
            command.ExecuteNonQuery();
        }
        public void DeleteEmployee(int id)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using SqlCommand command = new("Delete From employees where EmpID = @EmpID", connection);
            command.Parameters.AddWithValue("@EmpID", id);
            command.ExecuteNonQuery();
        }


    }
}
