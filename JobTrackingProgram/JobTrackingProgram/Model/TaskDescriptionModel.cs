using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.Model
{
    class TaskDescriptionModel
    {
        public int TaskDescriptionID { get; set; }
        public string TaskDescription1 { get; set; }
        public int TaskID { get; set; }
        public Task Task = new Task();
    }
}
