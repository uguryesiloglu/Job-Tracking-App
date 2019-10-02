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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label4.Text = Form1.LoggedInUser.Username;
            label3.Text = Form1.LoggedInEmployee.Name + " " + Form1.LoggedInEmployee.Surname;

            comboBox1.Items.AddRange(Enum.GetNames(typeof(HelperTask.IssueType)));

            comboBox2.ValueMember = "TaskID";
            comboBox2.DataSource = HelperEmployeeTask.GetEmployeesTasks(Form1.LoggedInEmployee.EmployeeID);

            Guncelle();
        }
        private void ComboBox2_Format(object sender, ListControlConvertEventArgs e)
        {
            string taskName = ((EmployeeTaskModel)e.ListItem).Task.TaskName;
            e.Value = taskName;
        }
        
        void Guncelle()
        {
            try
            {
                listView1.Items.Clear();
                listView4.Items.Clear();

                foreach (var model in HelperEmployeeTask.GetEmployeesTasks(Form1.LoggedInEmployee.EmployeeID))
                {
                    ListViewItem empTask = new ListViewItem();

                    empTask.SubItems.Add(model.EmployeeTaskID.ToString());
                    empTask.SubItems.Add(model.Task.Project.ProjectName);
                    empTask.SubItems.Add(model.Task.TaskName);

                    TimeSpan ts = model.Task.EndDate.Subtract(DateTime.Now.Date);
                    empTask.SubItems.Add(ts.TotalDays.ToString());
                    empTask.SubItems.Add(model.Creator);
                    empTask.SubItems.Add(model.IssueType);

                    listView1.Items.Add(empTask);
                    
                }
                foreach (var desc in HelperTaskDescription.GetTaskDescriptions((int)comboBox2.SelectedValue))
                {
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add(desc.TaskDescriptionID.ToString());
                        item.SubItems.Add(desc.TaskDescription1);
                        listView4.Items.Add(item);
                    
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
                    var issue = comboBox1.SelectedItem.ToString();
                    HelperEmployeeTask.UpdateTask(taskID, issue);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Guncelle();
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guncelle();
        }
        private void GörevAtamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGorevAtama frm = new FormGorevAtama();
            frm.Show();
        }

        private void GörevAtamaIptalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAtamaIptal frm = new FormAtamaIptal();
            frm.Show();
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
        private void GörevAçıklamasıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAciklamaEkle frm = new FormAciklamaEkle();
            frm.Show();
        }

        
    }
}

