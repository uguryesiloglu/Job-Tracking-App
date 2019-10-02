using JobTrackingProgram.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackingProgram.BLL
{
    static class BllTask
    {
        static public int GetTaskNumber()
        {
            return DAL.HelperTask.GetTaskCount();
        }
        static public int GetActiveTaskNumber()
        {
            return DAL.HelperTask.GetActTaskCount();
        }
        
    }
}
