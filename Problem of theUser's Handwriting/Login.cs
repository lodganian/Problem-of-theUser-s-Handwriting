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

namespace Problem_of_theUser_s_Handwriting
{
    public partial class Login : Form
    {
        double deltaUserTime = 0;
        double deltaCurrentTime = 0;
        bool checkText = false;//Проверка записи текста в поле
        string prevText = " ";//Запись текста
        DateTime timeNow = DateTime.Now;//Таймер
        static Random rnd = new Random();
        string FileTextPath = "../../../texts.txt";//Путь файла
        MainForm form;
        public Login(MainForm form)
        {
            this.form = form;
            InitializeComponent();
            foreach (User user in form.Users) 
            {
                comboBox1.Items.Add(user.Login);
            }
            if (File.Exists(FileTextPath))
            {
                string[] tmp = File.ReadAllLines(FileTextPath, Encoding.UTF8);
                richTextBox1.Text = tmp[rnd.Next(0, tmp.Length)];
            }
            else
            {
                richTextBox1.Text = "Файл не найден";
            }
            richTextBox2.Enabled = false;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Close();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            double tmp;
            comboBox1.Enabled = false;
            TimeSpan eps = time - timeNow;
            int i = 0;
            try { 

                while (i< prevText.Length && prevText[i]==richTextBox2.Text[i]) i++;
                tmp = form.Users[comboBox1.SelectedIndex].GetTime(prevText.ToLower()[i-1], richTextBox2.Text.ToLower()[i]);
            
                if (tmp > 0) 
                {
                    deltaUserTime+=tmp;
                    deltaCurrentTime+=eps.TotalMilliseconds;
                }
                prevText = richTextBox2.Text;
                button1.Text = deltaUserTime.ToString();
                button2.Text = deltaCurrentTime.ToString();
                if (richTextBox2.Text.ToLower() == richTextBox1.Text.ToLower())
                {
                    checkText = true;
                    richTextBox2.Enabled = false;
                    button1.Text = deltaUserTime.ToString();
                    button2.Text = deltaCurrentTime.ToString();
                    label1.Text = (richTextBox2.Text.ToLower() == richTextBox1.Text.ToLower()).ToString();


                }
            }
            catch (Exception) 
            {
                prevText = richTextBox2.Text;
                if (richTextBox2.Text.ToLower() == richTextBox1.Text.ToLower())
                {
                    checkText = true;
                    richTextBox2.Enabled = false;
                    button1.Text = deltaUserTime.ToString();
                    button2.Text = deltaCurrentTime.ToString();
                    label1.Text = (richTextBox2.Text.ToLower() == richTextBox1.Text.ToLower()).ToString();


                }
            }
            timeNow=DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkText) 
            {
                if (Math.Abs(deltaCurrentTime - deltaUserTime)>= 0.05*deltaUserTime) MessageBox.Show("Сорре, но это не ты");
                else MessageBox.Show("Ура!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Enabled = true;
        }
    }
}
