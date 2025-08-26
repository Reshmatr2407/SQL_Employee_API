

using Dapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        //select all employees
        [HttpGet("Getallempdetails")]
        public async Task<IActionResult> Getallempdetails()
        {

            
            string query = "SELECT * FROM Employee"; // Query to fetch all employees
            using var connection = _context.CreateConnectionCompany();
            var employees = await connection.QueryAsync<EmployeeModel>(query); // Using Dapper for query execution
            return Ok(employees); // Return the list of employees as a JSON result

        }




        [HttpGet("Searchbydept/{name}/{dep}", Name = "Searchbyid")]
        public async Task<IActionResult> Searchbydept([FromRoute] string name, string dep)
        {
            string query = "SELECT * FROM Employee WHERE name = @Name AND department = @Department"; // Use named parameters for Oracle

            var parameters = new { Name = name, Department = dep }; // Create an anonymous object for parameters

            using var connection = _context.CreateConnectionCompany();
            var res = await connection.QueryAsync<EmployeeModel>(query, parameters); // Pass the parameters directly

            return Ok(res); // Return the first result or null if no results found
            
        }
        [HttpGet("Searchbydesignation/{des}")]
        public async Task<IActionResult> GetRepoQuery2(string des)
        {
            string query = "SELECT * FROM Employee WHERE designation = @designa"; // Use named parameters for Oracle
            var parameters = new { designa = des }; // Create an anonymous object for parameters
            using var connection = _context.CreateConnectionCompany();
            var res = await connection.QueryAsync<EmployeeModel>(query, parameters); // Pass the parameters directly
            return Ok(res); // Return the first result or null if no results found
        }

        [HttpPost("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee([FromBody] EmployeeModel employee)
        {
            var cmd = "INSERT INTO Employee (Id, Name, designation, department) VALUES (@Id, @Name, @Designation, @Department)"; // Use a parameterized query
            var parameters = new { Id = employee.id, Name = employee.name, Designation = employee.designation, Department = employee.department };

            using var connection = _context.CreateConnectionCompany();
            var res = await connection.ExecuteAsync(cmd, parameters); // Use ExecuteAsync for Dapper

            if (res > 0) // Check if any rows were affected
            {
                return Ok("Successfully inserted"); // Return success message
            }
            else
            {
                return BadRequest("Insertion failed"); // Return failure message if no rows were affected
            }
        }


        [HttpPut("ModifyEmployee")]
            public async Task<IActionResult> ModifyEmployee([FromBody] EmployeeModel employee)
            {
            var cmd = "UPDATE Employee SET  Name=@name,designation=@designation,department=@department WHERE Id=@id"; // Use a parameterized query
            var parameters = new { Id = employee.id, Name = employee.name, Designation = employee.designation, Department = employee.department };

            using var connection = _context.CreateConnectionCompany();
            var res = await connection.ExecuteAsync(cmd, parameters); // Use ExecuteAsync for Dapper

            if (res > 0)
            {
                return Ok("Successfully updated");
            }
            else
            {
                return BadRequest("Failed to Modify employee.");
            }
            
            }
        [HttpDelete("RemoveEmployee/{id}/{name}")]
        public async Task<dynamic> RemoveEmployee([FromRoute] string id, string name)
        {
            var cmd = "DELETE FROM Employee WHERE Id=@id AND Name=@name  "; // Use a parameterized query
            var parameters = new { Id = id, Name = name};

            using var connection = _context.CreateConnectionCompany();
            var res = await connection.ExecuteAsync(cmd, parameters); // Use ExecuteAsync for Dapper

            if (res > 0)
            {
                return Ok("Successfully deleted");
            }
            else
            {
                return BadRequest("Failed to Delete employee.");
            }
            
        }
    }

    }

    
