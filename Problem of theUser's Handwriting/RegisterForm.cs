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
    public partial class RegisterForm : Form
    {
        DateTime timeNow = DateTime.Now;//Таймер
        MainForm form;//форма, для возвращения
        bool check = false;//Хз зачем
        string prevText = "";//Запись текста
        User us = new User("login");
        public RegisterForm(MainForm form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            TimeSpan eps = timeNow-time;
            us.PutTime(prevText, richTextBox1.Text, eps.TotalMilliseconds);
            prevText = richTextBox1.Text;
        }
    }
}
