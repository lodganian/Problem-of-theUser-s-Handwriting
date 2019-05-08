using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_of_theUser_s_Handwriting
{
    [Serializable]
    public class Project
    {

        public string Name { get {return name; } } 
        string name;
        string[] userText;

        /// <summary>
        /// Создание нового класса
        /// </summary>
        /// <param name="Name"></param>
        public Project(string Name)
        {
            if (Name == "") throw new ArgumentException();
            this.name = Name;
        }

        /// <summary>
        /// Метод, очищающий проект
        /// </summary>
        public void Clear() 
        { 
            userText = new string[3];
        }

        /// <summary>
        ///Метод для сохранения проекта
        /// </summary>
        /// <param name="Text"></param>
        public void Save(string[] Text)
        {
            userText = Text;
        }

        /// <summary>
        /// Метод для копирования одного текстового проекта в другой новый
        /// </summary>
        /// <param name="name">Название нового проекта</param>
        /// <param name="Text">Текст проекта</param>
        /// <returns>новый проект</returns>
        public Project Copy(string name)
        {
            Project tmp = new Project(name);
            tmp.Save(this.userText);
            return tmp;
        }

        public void Copy(Project project)
        {
            project.userText = this.userText;
        }
    }
}
