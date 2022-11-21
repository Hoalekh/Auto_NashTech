using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DAO
{
    public class EmployeeDAO
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }
        public EmployeeDAO(string firstname, string lastname, string email, string age
            , string salary, string depatment)
        {
            FristName= firstname;
            LastName= lastname;
            Email= email;  
            Age= age;
            Salary= salary;
            Department = depatment;
        }
    }
}
