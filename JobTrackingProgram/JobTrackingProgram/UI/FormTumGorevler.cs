using JobTrackingProgram.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTrackingProgram.UI
{
    public partial class FormTumGorevler : Form
    {
        public FormTumGorevler()
        {
            InitializeComponent();
        }

        private void FormTumGorevler_Load(object sender, EventArgs e)
        {
            foreach (var task in HelperTask.GetTaskModels())
            {
                ListViewItem listItem= new ListViewItem();

                listItem.SubItems.Add(task.TaskID.ToString());
                listItem.SubItems.Add(task.TaskName);
                listItem.SubItems.Add(task.Project.ProjectName);
                listItem.SubItems.Add(task.Priority);
                listItem.SubItems.Add(task.StartDate.Value.ToShortDateString());
                listItem.SubItems.Add(task.EndDate.Value.Date.ToShortDateString());
                listView2.Items.Add(listItem);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
