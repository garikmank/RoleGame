using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStarting
{
    class MagicHero : GameHero
    {
        
        public uint currentMana { get; set; }//текущее значение маны
        public uint maxMana { get; set; }//максимальное значение маны
        
        public MagicHero(string strName, Race rac, bool setSex, uint maxMan) : base(strName, rac, setSex)//конструктор
        {
            maxMana = maxMan;
        }
        public void saySpell(Spell sp, GameHero gmh = null, int power = 1)//метод, принимающий и выполняющий заклинание
        {
            if (gmh == null)
                gmh = this;
            if (sp == Spell.addHealth)
            {
                
                int x = (int)Math.Min(maxHealth - currentHealth,2*currentMana);
                currentMana -= (uint)(2 * x);
                gmh.currentHealth += (uint)x;
                return;
            }
            if ( (uint)sp > currentMana)
                return;
            //что-то происходит (заклинание вступает в силу) (пока не знаю, что писать)
            //ну и отнимаем манну:
            currentMana -= (uint)(power * (uint)sp);
        }
    }
}
