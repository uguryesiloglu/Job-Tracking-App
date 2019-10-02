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
    public partial class FormAciklamaEkle : Form
    {
        public FormAciklamaEkle()
        {
            InitializeComponent();
        }

        private void FormAciklamaEkle_Load(object sender, EventArgs e)
        {
            comboBox2.ValueMember = "ProjectID";
            comboBox2.DisplayMember = "ProjectName";
            comboBox2.DataSource = HelperProject.GetProjects();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                TaskDescription td = new TaskDescription();

                td.TaskDescription1 = richTextBox1.Text;
                td.TaskID = (int)comboBox1.SelectedValue;

                var sorgu = HelperTaskDescription.AddTaskDescription(td);

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

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "TaskName";
            comboBox1.ValueMember = "TaskID";
            comboBox1.DataSource = HelperTask.GetTasks((int)comboBox2.SelectedValue);
        }
    }
}
