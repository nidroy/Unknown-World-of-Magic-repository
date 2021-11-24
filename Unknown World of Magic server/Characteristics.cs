using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Characteristics
    {
        public static int strength; // сила
        public static int agility; // ловкость
        public static int intelligence; // интеллект

        // установить очки силы
        public void SetStrength(int numberStrength)
        {
            strength = numberStrength;
        }

        // установить очки ловкости
        public void SetAgility(int numberAgility)
        {
            agility = numberAgility;
        }

        // установить очки интеллекта
        public void SetIntelligence(int numberIntelligence)
        {
            intelligence = numberIntelligence;
        }

        // показать характеристики
        public void ShowCharacteristics()
        {
            ManagingCommands.isCharacteristics = true;
        }

        // скрыть характеристики
        public void HideCharacteristics()
        {
            ManagingCommands.isCharacteristics = false;
        }
    }
}
