using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_of_theUser_s_Handwriting
{
    [Serializable]
    class User
    {
        string login;//login
        public string Login{ get;}
        double[,] times = new double[1000, 1000];
        string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъымэюя.,1234567890-+:";
        int cursorPosicion = 0;
        
        /// <summary>
        /// Конструктор для пользователя
        /// </summary>
        /// <param name="login"></param>
        public User(string login)
        {
            this.login = login;
        }

        public void PutTime(string perv, string curr, double time) 
        {
            perv = perv.ToLower();
            curr = curr.ToLower();

            if (perv.Length == curr.Length - 1 && perv!="")
            {
                int i = 0;
                while (i < perv.Length && perv[i] == curr[i]) i++;//То, что изменилось
                if (i == cursorPosicion + 1) //Следующая ли буква изменилась
                { 
                    int prch = alphabet.IndexOf(curr[cursorPosicion]);
                    int cuch = alphabet.IndexOf(curr[i]);
                    if (prch != -1 && cuch != -1 && times[prch, cuch] == 0) times[prch, cuch] = time;//Запись времени переключения
                    else if (prch != -1 && cuch != -1 && Math.Abs(-times[prch,cuch]+time)>0.5* times[prch, cuch]) times[prch, cuch] = (time+ times[prch, cuch])/2;//Находим ср. ар между нажатиями, если пользователь не "думал долго"
                    cursorPosicion = i;//Позиция предыдущего курсора
                } 
            }
        }


    }
}
