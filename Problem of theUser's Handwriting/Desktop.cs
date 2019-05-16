using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Problem_of_theUser_s_Handwriting
{
    public partial class Desktop : Form
    {
        DateTime timeNow = DateTime.Now;//Таймер
        string prevText = "";//Запись текста
        DateTime end = DateTime.Now;//Подсчет ср. скорости
        DateTime start = DateTime.Now;//Подсчет ср. скорости
        public int checkform = -1;//номер проекта
        BinaryFormatter formatter = new BinaryFormatter();
        string UsersPath = "../../../users.dat";//Путь пользователей
        MainForm form;
        public User user;

        public Desktop(MainForm form, User user)
        {
            this.user = user;
            this.form = form;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.richTextBox1.Enabled = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkform>=0) user.projects[checkform].Save(richTextBox1.Text.Split('\n'));
            using (FileStream fs = new FileStream(UsersPath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, form.Users);
            }
            form.Close();
            this.Close();
        }

        private void новыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adding tmp = new Adding(this);
            tmp.ShowDialog();

        }


        private void сохранитьКакTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");;
        }

        public void takeProject(int num) 
        {
            if (checkform >= 0) 
            {
                user.projects[checkform].Save(richTextBox1.Text.Split('\n'));
            }
            else 
            {
                richTextBox1.Enabled = true;
            }
            checkform = num;
            richTextBox1.Text = user.projects[num].ToString();


        }

        private void изВашихПроектовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open open = new Open(this);
            open.ShowDialog();
        }


        public void OpenNewProject() 
        { 
            richTextBox1.Enabled = true;
            checkform = user.projects.Count() - 1;
            richTextBox1.Text = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            if (richTextBox1.Text.Length == 1) start = DateTime.Now;
            TimeSpan eps = time - timeNow;
            user.PutTime(prevText, richTextBox1.Text, eps.TotalMilliseconds);
            prevText = richTextBox1.Text;
            timeNow = DateTime.Now;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove tmp = new Remove(this);
            tmp.ShowDialog();
        }

        public void Clear() 
        { 
            richTextBox1.Enabled = false;
            richTextBox1.Text = "";
            checkform = -1;
        }
    }
}
