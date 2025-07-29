//using DataAccess.Context;
//using DataAccess.Models;
//using Microsoft.AspNetCore.Mvc;

//using System.Data.SqlClient;



//namespace DataAccess.EmployeeModuleRepository
//{
//    public class EmployeeRepo : ControllerBase
//    {
//        private DataContext _context;
//        private EmployeeModel _model;


//public EmployeeRepo(EmployeeModel model, DataContext context)
//{

//    _context = context;
//    _model = model;

//}
//public async Task<dynamic> GetnameRepo(string name)
//{

//    var res = "My name is " + name;
//    return res;
//}

//public async Task<IActionResult> GetAllempdetailsrepo()
//{
//    var cmd = "SELECT * FROM Employee";
//    var employees = new List<EmployeeModel>(); // Assuming EmployeeModel is your model class
//    using (var connection = _context.CreateConnectionCompany())
//    {
//        await connection.OpenAsync();
//        using var command = new SqlCommand(cmd, connection);

//        using (var reader = await command.ExecuteReaderAsync())
//        {
//            while (await reader.ReadAsync())
//            {
//                var employee = new EmployeeModel
//                {
//                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                    Name = reader.GetString(reader.GetOrdinal("Name")),
//                    Designation = reader.GetString(reader.GetOrdinal("Designation")),
//                    Department = reader.GetString(reader.GetOrdinal("Department")),
//                    // Map other properties as needed
//                };
//                employees.Add(employee);
//            }
//        }
//    }

//    // Return the list of employees as a JSON result
//    return Ok(employees);
//    //return Json("Test response");

//}

//public async Task<IActionResult> GetEmpnamesrepo()
//{
//    var cmd = "SELECT name FROM Employee";
//    var employees = new List<EmployeeModel>(); // Assuming Employee is your model class
//    using (var connection = _context.CreateConnectionCompany())
//    {
//        await connection.OpenAsync();
//        using var command = new SqlCommand(cmd, connection);

//        using (var reader = await command.ExecuteReaderAsync())
//        {
//            while (await reader.ReadAsync())
//            {
//                var employee = new EmployeeModel
//                {
//                    //Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                    Name = reader.GetString(reader.GetOrdinal("Name")),
//                    //Designation = reader.GetString(reader.GetOrdinal("Designation")),
//                    //Department = reader.GetString(reader.GetOrdinal("Department")),
//                    // Map other properties as needed
//                };
//                employees.Add(employee);
//            }
//        }
//    }

//    return Ok(employees);
//}


//public async Task<IActionResult> Searchbyidrepo(int id)
//{
//    var cmd = "SELECT * FROM Employee WHERE id = @id"; // Use a parameterized query
//    var employees = new List<EmployeeModel>(); // Assuming EmployeeModel is your model class

//    using (var connection = _context.CreateConnectionCompany())
//    {
//        await connection.OpenAsync();
//        using var command = new SqlCommand(cmd, connection);

//        // Add the parameter to the command
//        command.Parameters.AddWithValue("@id", id);

//        using (var reader = await command.ExecuteReaderAsync())
//        {
//            while (await reader.ReadAsync())
//            {
//                var employee = new EmployeeModel
//                {
//                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                    Name = reader.GetString(reader.GetOrdinal("Name")),
//                    Designation = reader.GetString(reader.GetOrdinal("Designation")),
//                    Department = reader.GetString(reader.GetOrdinal("Department")),
//                    // Map other properties as needed
//                };
//                employees.Add(employee);
//            }
//        }
//    }

//    return Ok(employees);
//}

//        public async Task<IActionResult> InsertEmpRepo(EmployeeModel employee)
//        {
//if (employee == null || string.IsNullOrWhiteSpace(employee.Name))
//{
//    return BadRequest("Invalid employee data.");
//}

//var cmd = "INSERT INTO Employee (Id, Name,designation,department) VALUES (@id, @name,@designation,@department)"; // Use a parameterized query

//using (var connection = _context.CreateConnectionCompany())
//{
//    await connection.OpenAsync();
//    using var command = new SqlCommand(cmd, connection);

//    // Add the parameters to the command
//    command.Parameters.AddWithValue("@id", employee.id);
//    command.Parameters.AddWithValue("@name", employee.name);
//    command.Parameters.AddWithValue("@designation", employee.designation);
//    command.Parameters.AddWithValue("@department", employee.department);

//    // Execute the command
//    int rowsAffected = await command.ExecuteNonQueryAsync();

//                // Check if the insert was successful
//                if (rowsAffected > 0)
//                {
//                    return Ok(employee.Id);
//                }
//                else
//                {
//                    return BadRequest("Failed to insert employee.");
//                }

//            }
//        }
//        public async Task<IActionResult> ModifyEmpRepo(EmployeeModel employee)
//        {
//            if (employee == null || string.IsNullOrWhiteSpace(employee.Name))
//            {
//                return BadRequest("Invalid employee data.");
//            }

//            var cmd = "UPDATE Employee SET  Name=@name,designation=@designation,department=@department WHERE Id=@id"; // Use a parameterized query

//            using (var connection = _context.CreateConnectionCompany())
//            {
//                await connection.OpenAsync();
//                using var command = new SqlCommand(cmd, connection);

//                // Add the parameters to the command
//                command.Parameters.AddWithValue("@id", employee.Id);
//                command.Parameters.AddWithValue("@name", employee.Name);
//                command.Parameters.AddWithValue("@designation", employee.Designation);
//                command.Parameters.AddWithValue("@department", employee.Department);

//                // Execute the command
//                int rowsAffected = await command.ExecuteNonQueryAsync();

//                // Check if the insert was successful
//                if (rowsAffected > 0)
//                {
//                    return Ok(employee.Id);
//                }
//                else
//                {
//                    return BadRequest("Failed to Modify employee.");
//                }

//            }
//        }
//        public async Task<IActionResult> RemoveEmpRepo(EmployeeModel employee)
//        {
//            if (employee == null || string.IsNullOrWhiteSpace(employee.Name))
//            {
//                return BadRequest("Invalid employee data.");
//            }

//            var cmd = "DELETE FROM Employee WHERE  Name=@name AND Id=@id"; // Use a parameterized query

//            using (var connection = _context.CreateConnectionCompany())
//            {
//                await connection.OpenAsync();
//                using var command = new SqlCommand(cmd, connection);

//                // Add the parameters to the command
//                command.Parameters.AddWithValue("@id", employee.Id);
//                command.Parameters.AddWithValue("@name", employee.Name);

//                // Execute the command
//                int rowsAffected = await command.ExecuteNonQueryAsync();

//                // Check if the insert was successful
//                if (rowsAffected > 0)
//                {
//                    return Ok(employee.Id);
//                }
//                else
//                {
//                    return BadRequest("Failed to Remove employee");
//                }

//            }
//        }
//    }
//}