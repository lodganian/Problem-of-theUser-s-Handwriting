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
    public partial class Open : Form
    {
        Desktop form;
        public Open(Desktop form)
        {
            this.form = form;
            InitializeComponent();
            foreach (var item in form.user.projects)
                comboBox1.Items.Add(item.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            form.takeProject(comboBox1.SelectedIndex);
            this.Close();
        }
    }
}
