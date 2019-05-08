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
    public partial class Desktop : Form
    {
        MainForm form;
        public User user;

        public Desktop(MainForm form, User user)
        {
            this.user = user;
            this.form = form;
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Size = MaximumSize;
            this.richTextBox1.Enabled = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.Close();
            this.Close();
        }
    }
}
