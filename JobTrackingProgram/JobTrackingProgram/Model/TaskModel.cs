using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.Model
{
    class TaskModel
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string Priority { get; set; }
        public int IsActive { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }

        public Project Project = new Project();

        public List<TaskDescription> taskDescList = new List<TaskDescription>();


    }
}
