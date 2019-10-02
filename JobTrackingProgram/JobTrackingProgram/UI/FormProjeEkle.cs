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
    public partial class FormProjeEkle : Form
    {
        public FormProjeEkle()
        {
            InitializeComponent();
        }
        
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Project newProject = new Project()
                {
                    ProjectName = textBox1.Text,
                    Priority = comboBox1.SelectedItem.ToString(),
                    Budget = Convert.ToInt32(textBox3.Text),
                    StartDate = dateTimePicker1.Value,
                    EndDate = dateTimePicker2.Value,
                    ProjectDescription = richTextBox1.Text,
                };

                var islemDurumu = HelperProject.AddProject(newProject);

                if (islemDurumu == true)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik bilgi girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
