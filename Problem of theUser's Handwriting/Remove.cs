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
    public partial class Remove : Form
    {
        Desktop form;
        public Remove(Desktop form)
        {
            this.form = form;
            InitializeComponent();
            foreach (var item in form.user.projects)
                comboBox1.Items.Add(item.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) MessageBox.Show("Выберите проект");
            else 
            { 
                if (form.checkform == comboBox1.SelectedIndex) form.Clear();
                form.user.projects.Remove(form.user.projects[comboBox1.SelectedIndex]);
                this.Close();
            }
        }
    }
}
