using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class EmployeeModel
    {
        public int id { get; set; } // Assuming Id is of type int
        public string name { get; set; } // Assuming Name is of type string
        public string designation { get; set; }
        public string department { get; set; }
    }
}
