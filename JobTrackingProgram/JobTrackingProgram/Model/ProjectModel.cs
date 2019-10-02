using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.Model
{
    class ProjectModel
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Priority { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<int> Budget { get; set; }
        public string ProjectDescription { get; set; }
    }
}
