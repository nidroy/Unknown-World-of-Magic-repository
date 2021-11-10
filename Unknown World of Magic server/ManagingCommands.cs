using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class ManagingCommands
    {
        public static bool isCreatingPlayer = true; // этап создания игрока

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
                CommandSetClassPlayer();
            }
            else if(ManagingResponses.serverResponse == "SetNumberClassPlayer")
            {
                ResponseSetNumberClassPlayer(command);
            }
            else if(command == "SetPlayerName")
            {
                CommandSetPlayerName();
            }
            else if(ManagingResponses.serverResponse == "SetPlayerName")
            {
                ResponseSetPlayerName(command);
            }
        }

        #region Commands & Responses

        // команда SetClassPlayer
        private void CommandSetClassPlayer()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberClassPlayer");
        }

        // ответ SetNumberClassPlayer
        private void ResponseSetNumberClassPlayer(string command)
        {
            CreatingPlayer creatingPlayer = new CreatingPlayer();
            creatingPlayer.SetNumberClassPlayer(Convert.ToInt32(command));
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("выбран класс игрока " + command);
        }

        // команда SetPlayerName
        private void CommandSetPlayerName()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetPlayerName");
        }

        // ответ SetPlayerName
        private void ResponseSetPlayerName(string command)
        {
            CreatingPlayer creatingPlayer = new CreatingPlayer();
            creatingPlayer.SetPlayerName(command);
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("Установлено имя игрока " + command);
            Console.WriteLine("установлено имя игрока " + CreatingPlayer.namePlayer);
            Console.WriteLine("установлен класс игрока " + creatingPlayer.GetNameClassPlayer());
            isCreatingPlayer = false;
        }

        #endregion
    }
}
