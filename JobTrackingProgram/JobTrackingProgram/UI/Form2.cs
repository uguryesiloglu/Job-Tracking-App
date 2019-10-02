using JobTrackingProgram.BLL;
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
using static JobTrackingProgram.DAL.HelperTask;

namespace JobTrackingProgram.UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        #region FORM ÇAĞRILARI
        private void ProjeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProjeEkle frm = new FormProjeEkle();
            frm.Show();
        }
        private void ProjeGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProjeGuncelle frm = new FormProjeGuncelle();
            frm.Show();
        }
        private void ProjeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProjeSil frm = new FormProjeSil();
            frm.Show();

        }
        private void ÇalışanEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCalisanEkle frm = new FormCalisanEkle();
            frm.Show();
        }
        private void ÇalışanSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCalisanSil frm = new FormCalisanSil();
            frm.Show();

        }
        private void ÇalışanGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCalisanGuncelle frm = new FormCalisanGuncelle();
            frm.Show();

        }
        private void GörevEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGorevEkle frm = new FormGorevEkle();
            frm.Show();

        }
        private void GörevSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGorevSil frm = new FormGorevSil();
            frm.Show();

        }
        private void GörevAçıklamasıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAciklamaEkle frm = new FormAciklamaEkle();
            frm.Show();

        }
        private void GörevAtamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGorevAtama frm = new FormGorevAtama();
            frm.Show();

        }
        private void GörevGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGorevGuncelle frm = new FormGorevGuncelle();
            frm.Show();

        }
        private void GörevAtamaIptalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAtamaIptal frm = new FormAtamaIptal();
            frm.Show();

        }
        private void TümGörevleriGörToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTumGorevler frm = new FormTumGorevler();
            frm.Show();

        }

        private void TümÇalışanlarıGörToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTumCalisanlar frm = new FormTumCalisanlar();
            frm.Show();
        }

        private void GörevAçıklamasıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAciklamaSil frm = new FormAciklamaSil();
            frm.Show();

        }
        #endregion

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadProcess();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Guncelle();
        }
        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string Name = ((Project)e.ListItem).ProjectName;
            e.Value = Name;
        }
        private void Guncelle()
        {
            LoadProcess();
        }
        private void LoadProcess()
        {
            label5.Text = BLL.BllEmployee.GetEmployeeCount().ToString();
            label6.Text = BLL.BllProject.GetProjectNumber().ToString();
            label4.Text = BLL.BllTask.GetTaskNumber().ToString();
            label7.Text = BLL.BllTask.GetActiveTaskNumber().ToString();

            comboBox1.DisplayMember = "ProjectName";
            comboBox1.ValueMember = "ProjectID";
            comboBox1.DataSource = HelperProject.GetProjects();

            comboBox5.ValueMember = "ProjectID";
            comboBox5.DisplayMember = "ProjectName";
            comboBox5.DataSource = HelperProject.GetProjects();



            comboBox4.DisplayMember = "ProjectName";
            comboBox4.ValueMember = "ProjectID";
            comboBox4.DataSource = HelperProject.GetProjects();

            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(Enum.GetNames(typeof(HelperTask.IssueType)));

            listView1.MultiSelect = true;

            label9.Text = DateTime.Now.ToString("HH:mm");

            listView3.Items.Clear();

            try
            {
                foreach (var prj in HelperProject.GetProjects())
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(prj.ProjectID.ToString());
                    item.SubItems.Add(prj.ProjectName);

                    listView3.Items.Add(item);
                }
            }
            catch (Exception)
            {
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listView1.CheckedItems.Count; i++)
                {
                    var taskID = Convert.ToInt32((listView1.CheckedItems[i].SubItems[1]).Text);
                    var issue = comboBox3.SelectedItem.ToString();
                    HelperEmployeeTask.UpdateTask(taskID, issue);
                }
            }
            catch (Exception)
            {

            }

        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            foreach (var model in HelperEmployeeTask.GetEmpTaskModelsByPrjID((int)comboBox1.SelectedValue))
            {

                ListViewItem empTask = new ListViewItem();

                empTask.SubItems.Add(model.EmployeeTaskID.ToString());
                empTask.SubItems.Add(model.Employee.Name + " " + model.Employee.Surname);
                empTask.SubItems.Add(model.Task.TaskName);

                TimeSpan ts = model.Task.EndDate.Date.Subtract(DateTime.Now.Date);
                empTask.SubItems.Add(ts.TotalDays.ToString());

                if (ts.TotalDays < 0)
                {
                    empTask.ForeColor = Color.Red;
                }

                empTask.SubItems.Add(model.Creator);
                empTask.SubItems.Add(model.IssueType);

                listView1.Items.Add(empTask);

            }
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView4.Items.Clear();

            foreach (var desc in HelperTaskDescription.GetTaskDescriptions((int)comboBox2.SelectedValue))
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(desc.TaskDescriptionID.ToString());
                item.SubItems.Add(desc.TaskDescription1);
                listView4.Items.Add(item);
            }
        }
        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();

            foreach (var unAsTask in HelperTask.GetUnassignedTasks((int)comboBox4.SelectedValue))
            {

                ListViewItem item = new ListViewItem();
                item.SubItems.Add(unAsTask.TaskID.ToString());
                item.SubItems.Add(unAsTask.TaskName);
                listView2.Items.Add(item);
            }
        }
        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DisplayMember = "TaskName";
            comboBox2.ValueMember = "TaskID";
            comboBox2.DataSource = HelperTask.GetTasks((int)comboBox5.SelectedValue);
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
