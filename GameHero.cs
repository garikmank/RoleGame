using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStarting
{
    class GameHero : IComparable<GameHero>
    {
        public int ID{get; private set;}//ID персонажа
        protected static int idnumb = 0;//единое для всех поле для изменения ID
        public string name{get; private set;}//имя персонажа
        public Condition condition{get; set;}//состояние героя
        public bool posibilitySay{get;set;} //возможность разговаривать
        public bool posibilityMoving { get; set; } //возможность двигаться
        public Race race { get; private set; }//раса
        public bool sex{get; private set;}//пол: true - мужчина, false - женщина
        protected DateTime birthday{get; private set;}//день рождения (так лучше, вроде, чем хранить и постоянно изменять возраст)
        public uint currentHealth { get; set; }//текущее состояние здоровья
        public uint maxHealth { get; set; }//максимально значение здоровья
        public int experience { get; set; }//опыт
       
        public GameHero(string strName, Race rac, bool setSex)//конструктор, инициализирующий неизменные поля
        {
            ID = idnumb++;
            name = strName;
            race = rac;
            sex = setSex;
            posibilityMoving = true;
            posibilitySay = true;
            experience = 0;
        }
        public int CompareTo(GameHero gmh)//реализация IComparable
        {
            if (this.experience > gmh.experience)
                return 1;
            if (this.experience == gmh.experience)
                return 0;
            return -1;
        }
        public void updateHero()//метод, который меняет состояние в зависимости от здоровья
        {
            double prop = (double)(currentHealth / maxHealth);
            if (prop < 0.1 && this.condition == Condition.normally)
                condition = Condition.weakened;
            if (prop >= 0.1 && this.condition == Condition.weakened)
                this.condition = Condition.normally;
            if (prop == 0)
                this.condition = Condition.dead;
        }
        public int calculateAge()//вычисление возраста
        {
            DateTime nowDate = DateTime.Today;
            int age = nowDate.Year - birthday.Year;
            if (birthday > nowDate.AddYears(-age)) age--;
            return age;
        }
        public override string  ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + this.name + "\n");
            sb.Append("Age: " + calculateAge() + "\n");
            sb.Append("Race: " + race.ToString() + "\n");
            sb.Append("Sex: " + (sex ? "men" : "women") + " \n");
            sb.Append("Condition: " + condition.ToString() + "\n");
            sb.Append("Experience: " + experience + "\n");
            sb.Append("Health: " + currentHealth + "\n");
            sb.Append("Can say: " + posibilitySay + "; can move: " + posibilityMoving + "\n");
            return sb.ToString();
        }
    }
}
