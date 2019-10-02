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
    public partial class FormGorevGuncelle : Form
    {
        public FormGorevGuncelle()
        {
            InitializeComponent();
        }

        Task guncTask = new Task();
        private void FormGorevGuncelle_Load(object sender, EventArgs e)
        {
            comboBox4.ValueMember = "ProjectID";
            comboBox4.DisplayMember = "ProjectName";
            comboBox4.DataSource = HelperProject.GetProjects();
                        
            comboBox2.DisplayMember = "ProjectName";
            comboBox2.ValueMember = "ProjectID";
            comboBox2.DataSource = HelperProject.GetProjects();
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                guncTask.ProjectID = Convert.ToInt32(comboBox2.SelectedValue);
                guncTask.TaskName = textBox1.Text;
                guncTask.Priority = comboBox1.SelectedItem.ToString();
                guncTask.StartDate = dateTimePicker1.Value;
                guncTask.EndDate = dateTimePicker2.Value;

                var sorgu = HelperTask.UpdateTask(guncTask);

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
        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            guncTask = (Task)comboBox3.SelectedItem;
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox3.DisplayMember = "TaskName";
            comboBox3.DataSource = HelperTask.GetTasks((int)comboBox4.SelectedValue);
        }
    }
}
