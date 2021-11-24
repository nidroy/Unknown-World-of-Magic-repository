using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class CreatingPlayer
    {

        // установить начало создания игрока
        public void SetStartCreatingPlayer()
        {
            ManagingCommands.isCreatingPlayer = true;
        }

        // установить конец создания игрока
        public void SetFinishCreatingPlayer()
        {
            ManagingCommands.isCreatingPlayer = false;
        }

        // установить номер класса игрока
        public void SetNumberClassPlayer(int number)
        {
            Player.numberClassPlayer = number;
        }

        // получить название класса игрока
        public string GetNameClassPlayer()
        {
            List<string> nameClassPlayer = new List<string>();
            nameClassPlayer.Add("Assassin");
            nameClassPlayer.Add("Mage");
            
            return nameClassPlayer[Player.numberClassPlayer];
        }

        // установить имя игрока
        public void SetPlayerName(string name)
        {
            Player.namePlayer = name;
        }

    }
}
