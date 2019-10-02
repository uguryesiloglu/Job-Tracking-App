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
    public partial class FormAciklamaSil : Form
    {
        public FormAciklamaSil()
        {
            InitializeComponent();
        }

        private void FormAciklamaSil_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "ProjectID";
            comboBox1.DisplayMember = "ProjectName";
            comboBox1.DataSource = HelperProject.GetProjects();
        }
        
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.ValueMember = "TaskID";
            comboBox2.DisplayMember = "TaskName";
            comboBox2.DataSource = HelperTask.GetTasks((int)comboBox1.SelectedValue);
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DisplayMember = "TaskDescription1";
            comboBox3.DataSource = HelperTaskDescription.GetTaskDescriptions((int)comboBox2.SelectedValue);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var sorgu = HelperTaskDescription.DeleteTaskDescription((TaskDescription)comboBox3.SelectedItem);
            if (sorgu==true)
            {
                this.Close();
            }
        }
    }
}
