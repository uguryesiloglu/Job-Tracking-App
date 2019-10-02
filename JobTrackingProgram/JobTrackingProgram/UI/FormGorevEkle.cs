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
    public partial class FormGorevEkle : Form
    {
        public FormGorevEkle()
        {
            InitializeComponent();
        }

        
        private void FormGorevEkle_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = HelperProject.GetProjects();
            comboBox2.ValueMember = "ProjectID";
            comboBox2.DisplayMember = "ProjectName";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Task newTask = new Task();

                newTask.ProjectID = Convert.ToInt32(comboBox2.SelectedValue);
                newTask.TaskName = textBox1.Text;
                newTask.Priority = comboBox1.SelectedItem.ToString();
                newTask.StartDate = dateTimePicker1.Value;
                newTask.EndDate = dateTimePicker2.Value;
                newTask.IsActive = 0;

                var sorgu = HelperTask.AddTask(newTask);

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

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }
    }
}
