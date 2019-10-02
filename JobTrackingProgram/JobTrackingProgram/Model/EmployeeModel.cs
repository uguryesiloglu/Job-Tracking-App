using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.Model
{
    public class EmployeeModel
    {
        public  int EmployeeID { get; set; }
        public  int UserID { get; set; }
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public  string Role { get; set; }

        public  User User = new User();
    }
}
