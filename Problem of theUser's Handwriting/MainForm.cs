using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Problem_of_theUser_s_Handwriting
{
    public partial class MainForm : Form
    {
        string UsersPath = "../../../users.dat";
        BinaryFormatter formatter = new BinaryFormatter();
        public List<User> Users = new List<User>();

        public MainForm()
        {
            InitializeComponent();
            using (FileStream fs = new FileStream(UsersPath, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0) 
                {
                    Users = (List<User>)formatter.Deserialize(fs);
                }
            }
        }

        /// <summary>
        /// Кнопка выхода из приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            (new RegisterForm(this)).ShowDialog();
        }

        /// <summary>
        /// Кнопка для входа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            (new Login(this)).ShowDialog();
        }
    }
}
