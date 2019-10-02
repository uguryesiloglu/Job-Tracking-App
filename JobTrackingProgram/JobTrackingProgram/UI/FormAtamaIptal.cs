using JobTrackingProgram.DAL;
using JobTrackingProgram.Model;
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
    public partial class FormAtamaIptal : Form
    {
        public FormAtamaIptal()
        {
            InitializeComponent();
        }

        EmployeeTaskModel silinecek = new EmployeeTaskModel();
        private void FormAtamaIptal_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "ProjectName";
            comboBox1.ValueMember = "ProjectID";
            comboBox1.DataSource = HelperProject.GetProjects();
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            silinecek = (EmployeeTaskModel)comboBox2.SelectedItem;
        }
        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string task = ((EmployeeTaskModel)e.ListItem).Task.TaskName;
            e.Value =task;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var sorgu = HelperEmployeeTask.DeleteEmployeeTask(silinecek.EmployeeTaskID);
                if (sorgu == true)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Eksik bilgi girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DisplayMember = "TaskName";
            comboBox2.DisplayMember = "TaskID";
            comboBox2.DataSource = HelperEmployeeTask.GetEmpTaskModelsByPrjID((int)comboBox1.SelectedValue);

        }
    }
}
