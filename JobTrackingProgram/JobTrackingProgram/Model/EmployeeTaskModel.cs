using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.Model
{
    class EmployeeTaskModel
    {
        public int EmployeeTaskID { get; set; }
        public int EmployeeID { get; set; }

        public int TaskID { get; set; }
        public Nullable<int> CreatorID { get; set; }
        public string Creator { get; set; }
        public string IssueType { get; set; }

        public Employee Employee = new Employee();
        public Task Task = new Task();

    }
}
