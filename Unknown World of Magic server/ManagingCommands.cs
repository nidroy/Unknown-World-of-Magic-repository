using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class ManagingCommands
    {
        private bool isCreatingPlayer = true; // этап создания игрока

        // проверка команд
        public void CheckingCommand(string command)
        {
            if (isCreatingPlayer)
            {
                PlayerCreationCommands(command);
            }
        }

        // команды этапа создания игрока
        public void PlayerCreationCommands(string command)
        {
            if(command == "SetClassPlayer")
            {
                ManagingResponses responses = new ManagingResponses();
                responses.SetServerResponse("SetNumberClassPlayer");
            }
            else if(ManagingResponses.serverResponse == "SetNumberClassPlayer")
            {
                CreatingPlayer creatingPlayer = new CreatingPlayer();
                creatingPlayer.SetNumberClassPlayer(Convert.ToInt32(command));
                ManagingResponses responses = new ManagingResponses();
                responses.SetServerResponse("выбран класс игрока " + command);
            }
            else if(command == "SetPlayerName")
            {
                ManagingResponses responses = new ManagingResponses();
                responses.SetServerResponse("SetPlayerName");
            }
            else if(ManagingResponses.serverResponse == "SetPlayerName")
            {
                CreatingPlayer creatingPlayer = new CreatingPlayer();
                creatingPlayer.SetPlayerName(command);
                ManagingResponses responses = new ManagingResponses();
                responses.SetServerResponse("Установлено имя игрока " + command);
                Console.WriteLine("установлено имя игрока " + CreatingPlayer.namePlayer);
                Console.WriteLine("установлен класс игрока " + creatingPlayer.GetNameClassPlayer());
            }
        }
    }
}
