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
    public partial class RegisterForm : Form
    {
        static Random rnd = new Random();//генератор рандома
        string UsersPath = "../../../users.dat";//Путь пользователей
        BinaryFormatter formatter = new BinaryFormatter();
        string FileTextPath = "../../../texts.txt";//Путь файла
        DateTime timeNow = DateTime.Now;//Таймер
        MainForm form;//форма, для возвращения
        bool checkText = false;//Проверка записи текста в поле
        string prevText = "";//Запись текста
        User us = new User("login");//Новый пользователь

        public RegisterForm(MainForm form)
        {
            this.form = form;
            InitializeComponent();
            if (File.Exists(FileTextPath))
            {
                string[] tmp = File.ReadAllLines(FileTextPath, Encoding.UTF8);
                richTextBox2.Text = tmp[rnd.Next(0, tmp.Length)];
            }
            else
            {
                richTextBox2.Text = "Файл не найден";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            TimeSpan eps = time - timeNow;
            us.PutTime(prevText, richTextBox1.Text, eps.TotalMilliseconds);
            prevText = richTextBox1.Text;
            if (richTextBox2.Text.ToLower() == richTextBox1.Text.ToLower())
            {
                checkText = true;
                richTextBox1.Enabled = false;
            }
            timeNow=DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkText) { 
                try { 
                    foreach(User user in form.Users) 
                    { 
                        if (user.Login == textBox1.Text) throw new ArgumentException();
                    }
                    if (textBox1.Text == "") throw new ArgumentNullException();
                    us.Login = textBox1.Text;
                    form.Users.Add(us);
                    form.Users.Sort();
                    using (FileStream fs = new FileStream(UsersPath, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, form.Users);
                    }
                    this.Close();
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Введите логин!");
                }
                catch ( ArgumentException)
                {
                    MessageBox.Show("Выбересте другой логин,\n такой уже занят!");
                }
                catch (Exception)
                { 
                   MessageBox.Show("Всё полетело по пизде");
                }
            }
            else 
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
