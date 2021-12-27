using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Dictionary
    {
        public static Dictionary<string, ICommand> dictionary = new Dictionary<string, ICommand>();
        List<ICommand> command = new List<ICommand>();

        #region конструктор

        public Dictionary
            (ICommand setInitialLocation,
            ICommand setNextLocation,
            ICommand setPreviousLocation,
            ICommand increaseStrength,
            ICommand increaseAgility,
            ICommand increaseIntelligence,
            ICommand getWarriorAttributes,
            ICommand getAssassinAttributes,
            ICommand getWizardAttributes,
            ICommand getBanditAttributes,
            ICommand getLeshiiAttributes,
            ICommand setPlayerName,
            ICommand playerAttack,
            ICommand restoringHealthPoints,
            ICommand restoringActionPoints,
            ICommand increaseExperiencePoints,
            ICommand resetExperiencePoints,
            ICommand increaseLevel,
            ICommand increaseGold,
            ICommand enemyAttack,
            ICommand getPlayers,
            ICommand getAttributes,
            ICommand saveGame,
            ICommand createPlayer)
        {
            command.Add(setInitialLocation);
            command.Add(setNextLocation);
            command.Add(setPreviousLocation);
            command.Add(increaseStrength);
            command.Add(increaseAgility);
            command.Add(increaseIntelligence);
            command.Add(getWarriorAttributes);
            command.Add(getAssassinAttributes);
            command.Add(getWizardAttributes);
            command.Add(getBanditAttributes);
            command.Add(getLeshiiAttributes);
            command.Add(setPlayerName);
            command.Add(playerAttack);
            command.Add(restoringHealthPoints);
            command.Add(restoringActionPoints);
            command.Add(increaseExperiencePoints);
            command.Add(resetExperiencePoints);
            command.Add(increaseLevel);
            command.Add(increaseGold);
            command.Add(enemyAttack);
            command.Add(getPlayers);
            command.Add(getAttributes);
            command.Add(saveGame);
            command.Add(createPlayer);
        }

        #endregion

        // заполнение словаря
        public void FillingDictionary()
        { 
            // словарь локаций
            dictionary.Add("SetInitialLocation", command[0]);
            dictionary.Add("SetNextLocation", command[1]);
            dictionary.Add("SetPreviousLocation", command[2]);
            // словарь характеристик
            dictionary.Add("IncreaseStrength", command[3]);
            dictionary.Add("IncreaseAgility", command[4]);
            dictionary.Add("IncreaseIntelligence", command[5]);
            // соварь получения атрибутов персонажа
            dictionary.Add("GetWarriorAttributes", command[6]);
            dictionary.Add("GetAssassinAttributes", command[7]);
            dictionary.Add("GetWizardAttributes", command[8]);
            dictionary.Add("GetBanditAttributes", command[9]);
            dictionary.Add("GetLeshiiAttributes", command[10]);
            // словарь игрока
            dictionary.Add("SetPlayerName", command[11]);
            dictionary.Add("PlayerAttack", command[12]);
            dictionary.Add("RestoringHealthPoints", command[13]);
            dictionary.Add("RestoringActionPoints", command[14]);
            dictionary.Add("IncreaseExperiencePoints", command[15]);
            dictionary.Add("ResetExperiencePoints", command[16]);
            dictionary.Add("IncreaseLevel", command[17]);
            dictionary.Add("IncreaseGold", command[18]);
            // словарь врага
            dictionary.Add("EnemyAttack", command[19]);
            // словарь базы данных
            dictionary.Add("GetPlayers", command[20]);
            dictionary.Add("GetAttributes", command[21]);
            dictionary.Add("SaveGame", command[22]);
            dictionary.Add("CreatePlayer", command[23]);
        }
    }
}
