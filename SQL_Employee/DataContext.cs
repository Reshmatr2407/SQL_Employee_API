

using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace SQL_Employee
{
    public class DataContext:DbContext
    {
        private readonly string _connectionString;

        public DataContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString
                ("SQLConnection"); // or your specific connection string name
        }
        public SqlConnection CreateConnectionCompany()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
