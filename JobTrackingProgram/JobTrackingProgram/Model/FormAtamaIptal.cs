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

namespace JobTrackingProgram.Model
{
    public partial class FormAtamaIptal : Form
    {
        public FormAtamaIptal()
        {
            InitializeComponent();
        }

        EmployeeTask silinecek = new EmployeeTask();
        private void FormAtamaIptal_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = HelperEmployeeTask.GetEmployeeTasks();
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            silinecek = (EmployeeTask)comboBox2.SelectedItem;

        }
        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string empTaskID = ((EmployeeTask)e.ListItem).EmployeeTaskID.ToString();
            string task = ((EmployeeTask)e.ListItem).Task.TaskName;
            string firstName = ((EmployeeTask)e.ListItem).Employee.Name;
            e.Value = empTaskID+" "+firstName+" "+task;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var sorgu = HelperEmployeeTask.DeleteEmployeeTask(silinecek);
            if (sorgu == true)
            {
                this.Close();
            } 
        }
    }
}
