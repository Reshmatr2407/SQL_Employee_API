

using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace SQL_Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeModuleController : ControllerBase

    {


        private readonly DataContext _context;
        public EmployeeModuleController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("Getallempdetails")]

        public async Task<IActionResult> Getallempdetails()
        {

            var cmd = "SELECT * FROM Employee";
            var employees = new List<EmployeeModel>(); // Assuming EmployeeModel is your model class
            using (var connection = _context.CreateConnectionCompany())
            {
                await connection.OpenAsync();
                using var command = new SqlCommand(cmd, connection);
                using (var reader = await command.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        var employee = new EmployeeModel
                        {
                            id = reader.GetInt32(reader.GetOrdinal("Id")),
                            name = reader.GetString(reader.GetOrdinal("Name")),
                            designation = reader.GetString(reader.GetOrdinal("Designation")),
                            department = reader.GetString(reader.GetOrdinal("Department")),
                            // Map other properties as needed
                        };
                        employees.Add(employee);
                    }
            }
            // Return the list of employees as a JSON result
            return Ok(employees);
            //return Json("Test response");
        }
        
        [HttpGet("Searchbydept/{dep}", Name = "Searchbyid")]
        public async Task<IActionResult> Searchbydept([FromRoute] string dep)
        {
            var cmd = "SELECT * FROM Employee WHERE department = @depart";
            // Use a parameterized query
            var employees = new List<EmployeeModel>(); // Assuming EmployeeModel is your model class

            using (var connection = _context.CreateConnectionCompany())
            {
                await connection.OpenAsync();
                using var command = new SqlCommand(cmd, connection);

                // Add the parameter to the command
                command.Parameters.AddWithValue("@depart", dep);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var employee = new EmployeeModel
                        {
                            id = reader.GetInt32(reader.GetOrdinal("Id")),
                            name = reader.GetString(reader.GetOrdinal("Name")),
                            designation = reader.GetString(reader.GetOrdinal("Designation")),
                            department = reader.GetString(reader.GetOrdinal("Department")),
                            // Map other properties as needed
                        };
                        employees.Add(employee);
                    }
                }
            }

            return Ok(employees);
        }

        [HttpPost("InsertEmployee")]
        public async Task<dynamic> InsertEmployee([FromBody] EmployeeModel employee)
        {
            var cmd = "INSERT INTO Employee (Id, Name,designation,department) VALUES (@id, @name,@designation,@department)"; // Use a parameterized query

            using (var connection = _context.CreateConnectionCompany())
            {
                await connection.OpenAsync();
                using var command = new SqlCommand(cmd, connection);

                // Add the parameters to the command
                command.Parameters.AddWithValue("@id", employee.id);
                command.Parameters.AddWithValue("@name", employee.name);
                command.Parameters.AddWithValue("@designation", employee.designation);
                command.Parameters.AddWithValue("@department", employee.department);

                // Execute the command
                int rowsAffected = await command.ExecuteNonQueryAsync();

                // Check if the insert was successful
                if (rowsAffected > 0)
                {
                    return "Successfully inserted";
                }
                else
                {
                    return BadRequest("Failed to Insert employee");
                }
            }
        }
            [HttpPut("ModifyEmployee")]

            public async Task<dynamic> ModifyEmployee([FromBody] EmployeeModel employee)
            {
                if (employee == null || string.IsNullOrWhiteSpace(employee.name))
                {
                    return BadRequest("Invalid employee data.");
                }

                var cmd = "UPDATE Employee SET  Name=@name,designation=@designation,department=@department WHERE Id=@id"; // Use a parameterized query

                using (var connection = _context.CreateConnectionCompany())
                {
                    await connection.OpenAsync();
                    using var command = new SqlCommand(cmd, connection);

                    // Add the parameters to the command
                    command.Parameters.AddWithValue("@id", employee.id);
                    command.Parameters.AddWithValue("@name", employee.name);
                    command.Parameters.AddWithValue("@designation", employee.designation);
                    command.Parameters.AddWithValue("@department", employee.department);

                    //        // Execute the command
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    //        // Check if the insert was successful
                    if (rowsAffected > 0)
                    {
                    return "Successfully updated";
                    }
                    else
                    {
                        return BadRequest("Failed to Modify employee.");
                    }
                }
            }
        [HttpDelete("RemoveEmployee", Name = "RemoveEmployee")]
        public async Task<dynamic> RemoveEmployee([FromBody] EmployeeModel employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.name))
            {
                return BadRequest("Invalid employee data.");
            }

            var cmd = "DELETE FROM Employee WHERE  Name=@name AND Id=@id"; // Use a parameterized query

            using (var connection = _context.CreateConnectionCompany())
            {
                await connection.OpenAsync();
                using var command = new SqlCommand(cmd, connection);

                // Add the parameters to the command
                command.Parameters.AddWithValue("@id", employee.id);
                command.Parameters.AddWithValue("@name", employee.name);

                // Execute the command
                int rowsAffected = await command.ExecuteNonQueryAsync();

                // Check if the insert was successful
                if (rowsAffected > 0)
                {
                    return "Successfully deleted";
                }
                else
                {
                    return BadRequest("Failed to Remove employee");
                }

            }
        }
    }

    }

    
