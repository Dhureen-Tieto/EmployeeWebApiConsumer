using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebApiConsumer
{
    class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public int PhoneNumber { get; set; }
        public int Age { get; set; }
        public string ActiveStatus { get; set; }
    }
}
