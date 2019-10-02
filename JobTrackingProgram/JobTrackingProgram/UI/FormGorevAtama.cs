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
    public partial class FormGorevAtama : Form
    {
        public FormGorevAtama()
        {
            InitializeComponent();
        }

        private void FormGorevAtama_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = HelperEmployee.GetEmployees();
            comboBox1.ValueMember = "EmployeeID";

            comboBox3.DisplayMember = "ProjectName";
            comboBox3.ValueMember = "ProjectID";
            comboBox3.DataSource = HelperProject.GetProjects();

        }
        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string firstName = ((Employee)e.ListItem).Name;
            string surName = ((Employee)e.ListItem).Surname;
            e.Value = firstName + " " + surName;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var guncTask = HelperTask.GetTask((int)comboBox2.SelectedValue);
                guncTask.IsActive = 1;
                var sorgu1 = HelperTask.UpdateTask(guncTask);

                EmployeeTask et = new EmployeeTask();

                et.EmployeeID = (int)comboBox1.SelectedValue;
                et.TaskID = (int)comboBox2.SelectedValue;
                et.CreatorID = Form1.LoggedInEmployee.EmployeeID;
                et.Creator = Form1.LoggedInEmployee.Name + " " + Form1.LoggedInEmployee.Surname;
                et.IssueType = "NotStarted";

                var sorgu = HelperEmployeeTask.AddEmployeeTask(et);
                if (sorgu == true && sorgu1==true)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik bilgi girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DisplayMember = "TaskName";
            comboBox2.ValueMember = "TaskID";
            comboBox2.DataSource = HelperTask.GetUnassignedTasks((int)comboBox3.SelectedValue);
        }
    }
}
