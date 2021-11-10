using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    class CreatingPlayer
    {
        public int numberClassPlayer = 1; // номер класса игрока
        public string namePlayer; // имя игрока

        // установить номер класса игрока
        public void SetNumberClassPlayer(int number)
        {
            numberClassPlayer = number;
        }

        // получить название класса игрока
        public string GetNameClassPlayer()
        {
            if(numberClassPlayer == 0)
            {
                return "Assassin";
            }
            if(numberClassPlayer == 1)
            {
                return "Mage";
            }
            return "";
        }

        // установить имя игрока
        public void SetPlayerName(string name)
        {
            namePlayer = name;
        }
    }
}
