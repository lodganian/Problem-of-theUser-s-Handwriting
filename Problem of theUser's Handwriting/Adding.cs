using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_of_theUser_s_Handwriting
{
    public partial class Adding : Form
    {
        List<Project> projects = new List<Project>(); 
        Desktop form;
        public Adding(Desktop form)
        {
            this.form = form;
            projects = form.user.projects;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (var tmp in projects)
                if (textBox1.Text == tmp.Name) 
                {
                    flag = true;
                    break;
                }
            if (flag) MessageBox.Show("Проект с таким именем уже есть!");
            else if (textBox1.Text == "") MessageBox.Show("Введите имя проекта");
            else 
            { 
                form.user.projects.Add(new Project(textBox1.Text));
                form.OpenNewProject();
                this.Close();
                
            }
        }
    }
}
