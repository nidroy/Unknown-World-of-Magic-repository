using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class ManagingCommands
    {
        public static bool isCreatingPlayer = true; // этап создания игрока
        public static bool isGame = true; // этап игры
        public static bool isFight = false; // этап сражения
        public static bool isCharacteristics = false; // показ характеристик

        // проверка команд
        public void CheckingCommand(string command)
        {
            if (isCreatingPlayer)
            {
                PlayerCreationCommands(command);
            }
            if(isGame)
            {
                GameCommands(command);
            }
            if(isFight)
            {
                FightCommands(command);
            }
            if(isCharacteristics)
            {
                CharacteristicsCommands(command);
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
            else if (command == "SetFinishCreatingPlayer")
            {
                CommandSetFinishCreatingPlayer();
            }
        }

        // команды этапа игры
        public void GameCommands(string command)
        {
            if(command == "SetNextLocation")
            {
                CommandSetNextLocation();
            }
            else if(command == "SetPreviousLocation")
            {
                CommandSetPreviousLocation();
            }
            else if(command == "SetStartFight")
            {
                CommandSetStartFight();
            }
            else if(command == "SetHealthPoints")
            {
                CommandSetHealthPoints();
            }
            else if(ManagingResponses.serverResponse == "SetNumberHealthPoints")
            {
                ResponseSetNumberHealthPoints(command);
            }
            else if(command == "SetActionPoints")
            {
                CommandSetActionPoints();
            }
            else if(ManagingResponses.serverResponse == "SetNumberActionPoints")
            {
                ResponseSetNumberActionPoints(command);
            }
            else if(command == "SetStartCreatingPlayer")
            {
                CommandSetStartCreatingPlayer();
            }
            else if(command == "SetSkillPoints")
            {
                CommandSetSkillPoints();
            }
            else if(ManagingResponses.serverResponse == "SetNumberSkillPoints")
            {
                ResponseSetNumberSkillPoints(command);
            }
            else if(command == "SetExperiencePoints")
            {
                CommandSetExperiencePoints();
            }
            else if (ManagingResponses.serverResponse == "SetNumberExperiencePoints")
            {
                ResponseSetNumberExperiencePoints(command);
            }
            else if (command == "SetPlayerLevel")
            {
                CommandSetPlayerLevel();
            }
            else if(ManagingResponses.serverResponse == "SetLevel")
            {
                ResponseSetLevel(command);
            }
            else if(command == "SetPlayerGold")
            {
                CommandSetPlayerGold();
            }
            else if(ManagingResponses.serverResponse == "SetNumberGold")
            {
                ResponseSetNumberGold(command);
            }
            else if(command == "GetNameLocation")
            {
                CommandGetNameLocation();
            }
            else if(command == "GetTextLocation")
            {
                CommandGetTextLocation();
            }
            else if(command == "SetNPCName")
            {
                CommandSetNPCName();
            }
            else if(command == "SetNPCHealthPoints")
            {
                CommandSetNPCHealthPoints();
            }
            else if(ManagingResponses.serverResponse == "SetNumberNPCHealthPoints")
            {
                ResponseSetNumberNPCHealthPoints(command);
            }
            else if(command == "SetNPCLevel")
            {
                CommandSetNPCLevel();
            }
            else if(command == "SetNPCExperiencePoints")
            {
                CommandSetNPCExperiencePoints();
            }
            else if(command == "SetNPCGold")
            {
                CommandSetNPCGold();
            }
            else if(command == "ShowCharacteristics")
            {
                CommandShowCharacteristics();
            }
        }

        // команды этапа сражения
        public void FightCommands(string command)
        {
            if(command == "SetFinishFight")
            {
                CommandSetFinishFight();
            }
            else if(command == "SetPlayerDamage")
            {
                CommandSetPlayerDamage();
            }
            else if(ManagingResponses.serverResponse == "SetNumberPlayerDamage")
            {
                ResponseSetNumberPlayerDamage(command);
            }
            else if(command == "SetNPCDamage")
            {
                CommandSetNPCDamage();
            }
            else if (command == "AttackPlayer")
            {
                CommandAttackPlayer();
            }
            else if (ManagingResponses.serverResponse == "SetDamagePlayerAttack")
            {
                ResponseSetDamagePlayerAttack(command);
            }
            else if (command == "AttackNPC")
            {
                CommandAttackNPC();
            }
            else if (ManagingResponses.serverResponse == "SetDamageNPCAttack")
            {
                ResponseSetDamageNPCAttack(command);
            }
        }

        // команды характеристик
        public void CharacteristicsCommands(string command)
        {
            if(command == "HideCharacteristics")
            {
                CommandHideCharacteristics();
            }
            else if(command == "SetStrength")
            {
                CommandSetStrength();
            }
            else if(ManagingResponses.serverResponse == "SetNumberStrength")
            {
                ResponseSetNumberStrength(command);
            }
            else if(command == "SetAgility")
            {
                CommandSetAgility();
            }
            else if(ManagingResponses.serverResponse == "SetNumberAgility")
            {
                ResponseSetNumberAgility(command);
            }
            else if(command == "SetIntelligence")
            {
                CommandSetIntelligence();
            }
            else if(ManagingResponses.serverResponse == "SetNumberIntelligence")
            {
                ResponseSetNumberIntelligence(command);
            }
        }

        #region Commands & Responses

        #region PlayerCreationCommands

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
        }

        // команда SetFinishCreatingPlayer
        private void CommandSetFinishCreatingPlayer()
        {
            CreatingPlayer creatingPlayer = new CreatingPlayer();
            creatingPlayer.SetFinishCreatingPlayer();
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("создание персонажа закончено");
            Console.WriteLine("создание персонажа закончено");
        }

        #endregion

        #region GameCommands

        // команда SetNextLocation
        private void CommandSetNextLocation()
        {
            Locations locations = new Locations();
            locations.SetNextLocation();
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse(Locations.locationNumber.ToString());
            Console.WriteLine("установлен номер локации " + Locations.locationNumber.ToString());
        }

        // команда SetPreviousLocation
        private void CommandSetPreviousLocation()
        {
            Locations locations = new Locations();
            locations.SetPreviousLocation();
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse(Locations.locationNumber.ToString());
            Console.WriteLine("устаовлен номер локации " + Locations.locationNumber.ToString());
        }

        // команда SetStartFight
        private void CommandSetStartFight()
        {
            Fight fight = new Fight();
            fight.SetStartFight();
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("сражение начато");
            Console.WriteLine("сражение начато");
        }

        // команда SetHealthPoints
        private void CommandSetHealthPoints()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberHealthPoints");
        }

        // ответ SetNumberHealthPoints
        private void ResponseSetNumberHealthPoints(string command)
        {
            Player player = new Player();
            player.SetHealthPoints(Convert.ToInt32(command));
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("Установлено количество очков здоровья " + command);
        }

        // команда SetActionPoints
        private void CommandSetActionPoints()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberActionPoints");
        }

        // ответ SetNumberActionPoints
        private void ResponseSetNumberActionPoints(string command)
        {
            Player player = new Player();
            player.SetActionPoints(Convert.ToInt32(command));
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("Установлено количество очков действий " + command);
        }

        // команда SetStartCreatingPlayer
        private void CommandSetStartCreatingPlayer()
        {
            CreatingPlayer creatingPlayer = new CreatingPlayer();
            creatingPlayer.SetStartCreatingPlayer();
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("создание персонажа начато");
            Console.WriteLine("создание персонажа начато");
        }

        // команда SetSkillPoints
        private void CommandSetSkillPoints()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberSkillPoints");
        }

        // ответ SetNumberSkillPoints
        private void ResponseSetNumberSkillPoints(string command)
        {
            Player player = new Player();
            player.SetSkillPoints(Convert.ToInt32(command));
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("Установлено количество очков навыков " + command);
        }

        // команда SetExperiencePoints
        private void CommandSetExperiencePoints()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberExperiencePoints");
        }

        // ответ SetNumberExperiencePoints
        private void ResponseSetNumberExperiencePoints(string command)
        {
            Player player = new Player();
            player.SetExperiencePoints(Convert.ToInt32(command));
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("Установлено количество очков опыта " + command);
        }

        // команда SetPlayerLevel
        private void CommandSetPlayerLevel()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetLevel");
        }

        // ответ SetLevel
        private void ResponseSetLevel(string command)
        {
            Player player = new Player();
            player.SetPlayerLevel(Convert.ToInt32(command));
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("Установлен уровень игрока " + command);
        }

        // команда SetPlayerGold
        private void CommandSetPlayerGold()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberGold");
        }

        // ответ SetNumberGold
        private void ResponseSetNumberGold(string command)
        {
            Player player = new Player();
            player.SetPlayerGold(Convert.ToInt32(command));
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("Установлено количество золота игрока " + command);
        }

        // команда GetNameLocation
        private void CommandGetNameLocation()
        {
            ManagingResponses responses = new ManagingResponses();
            Locations locations = new Locations();
            responses.SetServerResponse(locations.GetNameLocation());
            Console.WriteLine("установлено название локации " + locations.GetNameLocation());
        }

        // команда GetTextLocation
        private void CommandGetTextLocation()
        {
            ManagingResponses responses = new ManagingResponses();
            Locations locations = new Locations();
            responses.SetServerResponse(locations.GetTextLocation());
            Console.WriteLine("установлен текст локации " + "'" + locations.GetTextLocation() + "'");
        }

        // команда SetNPCName
        private void CommandSetNPCName()
        {
            ManagingResponses responses = new ManagingResponses();
            NPC npc = new NPC();
            npc.SetNPCName(Locations.locationNumber);
            responses.SetServerResponse(NPC.nameNPC);
        }

        // команда SetNPCHealthPoints
        private void CommandSetNPCHealthPoints()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberNPCHealthPoints");
        }

        // ответ SetNumberNPCHealthPoints
        private void ResponseSetNumberNPCHealthPoints(string command)
        {
            ManagingResponses responses = new ManagingResponses();
            NPC npc = new NPC();
            npc.SetHealthPoints(Convert.ToInt32(command));
            responses.SetServerResponse("Установлено количество очков здоровья NPC " + command);
        }

        // команда SetNPCLevel
        private void CommandSetNPCLevel()
        {
            ManagingResponses responses = new ManagingResponses();
            NPC npc = new NPC();
            npc.SetNPCLevel(Locations.locationNumber);
            responses.SetServerResponse(NPC.NPCLevel.ToString());
        }

        // команда SetNPCExperiencePoints
        private void CommandSetNPCExperiencePoints()
        {
            ManagingResponses responses = new ManagingResponses();
            NPC npc = new NPC();
            npc.SetExperiencePoints(Locations.locationNumber);
            responses.SetServerResponse(NPC.experiencePoints.ToString());
        }

        // команда SetNPCGold
        private void CommandSetNPCGold()
        {
            ManagingResponses responses = new ManagingResponses();
            NPC npc = new NPC();
            npc.SetNPCGold(Locations.locationNumber);
            responses.SetServerResponse(NPC.NPCGold.ToString());
        }

        // команда ShowCharacteristics
        private void CommandShowCharacteristics()
        {
            Characteristics characteristics = new Characteristics();
            ManagingResponses responses = new ManagingResponses();
            characteristics.ShowCharacteristics();
            responses.SetServerResponse("открыть характеристики");
        }

        #endregion

        #region FightCommands

        // команда SetFinishFight
        private void CommandSetFinishFight()
        {
            Fight fight = new Fight();
            fight.SetFinishFight();
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("сражение закончено");
            Console.WriteLine("сражение закончено");
        }

        // команда SetPlayerDamage
        private void CommandSetPlayerDamage()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberPlayerDamage");
        }

        // ответ SetNumberPlayerDamage
        private void ResponseSetNumberPlayerDamage(string command)
        {
            Player player = new Player();
            player.SetPlayerDamage(Convert.ToInt32(command));
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse(Player.playerDamage.ToString());
        }

        // команда SetNPCDamage
        private void CommandSetNPCDamage()
        {
            NPC npc = new NPC();
            npc.SetNPCDamage(Locations.locationNumber);
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse(NPC.NPCDamage.ToString());
        }

        // команда AttackPlayer
        private void CommandAttackPlayer()
        {       
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetDamagePlayerAttack");
        }

        // ответ SetDamagePlayerAttack
        private void ResponseSetDamagePlayerAttack(string command)
        {
            Fight fight = new Fight();
            fight.AttackPlayer(Convert.ToInt32(command));
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse(NPC.healthPoints.ToString());
            Console.WriteLine("нанесено " + command + " урона");
        }

        // команда AttackNPC
        private void CommandAttackNPC()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetDamageNPCAttack");
        }

        // ответ SetDamageNPCAttack
        private void ResponseSetDamageNPCAttack(string command)
        {
            Fight fight = new Fight();
            fight.AttackNPC(Convert.ToInt32(command));
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse(Player.healthPoints.ToString());
            Console.WriteLine("получено " + command + " урона");
        }

        #endregion

        #region CharacteristicsCommands

        // команда HideCharacteristics
        private void CommandHideCharacteristics()
        {
            Characteristics characteristics = new Characteristics();
            ManagingResponses responses = new ManagingResponses();
            characteristics.HideCharacteristics();
            responses.SetServerResponse("скрыть характеристики");
        }

        // команда SetStrength
        private void CommandSetStrength()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberStrength");
        }

        // ответ SetNumberStrength
        private void ResponseSetNumberStrength(string command)
        {
            ManagingResponses responses = new ManagingResponses();
            Characteristics characteristics = new Characteristics();
            characteristics.SetStrength(Convert.ToInt32(command));
            responses.SetServerResponse("установлена сила игрока " + command);
        }

        // команда SetAgility
        private void CommandSetAgility()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberAgility");
        }

        // ответ SetNumberAgility
        private void ResponseSetNumberAgility(string command)
        {
            ManagingResponses responses = new ManagingResponses();
            Characteristics characteristics = new Characteristics();
            characteristics.SetAgility(Convert.ToInt32(command));
            responses.SetServerResponse("установлена ловкость игрока " + command);
        }

        // команда SetIntelligence
        private void CommandSetIntelligence()
        {
            ManagingResponses responses = new ManagingResponses();
            responses.SetServerResponse("SetNumberIntelligence");
        }

        // ответ SetNumberIntelligence
        private void ResponseSetNumberIntelligence(string command)
        {
            ManagingResponses responses = new ManagingResponses();
            Characteristics characteristics = new Characteristics();
            characteristics.SetIntelligence(Convert.ToInt32(command));
            responses.SetServerResponse("установлен интеллект игрока " + command);
        }

        #endregion

        #endregion
    }
}
