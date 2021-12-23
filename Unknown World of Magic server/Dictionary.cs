using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Dictionary
    {
        public static Dictionary<string, ICommand> dictionary = new Dictionary<string, ICommand>();

        #region команды

        ICommand setInitialLocation;
        ICommand setNextLocation;
        ICommand setPreviousLocation;
        ICommand increaseStrength;
        ICommand increaseAgility;
        ICommand increaseIntelligence;
        ICommand getWarriorAttributes;
        ICommand getAssassinAttributes;
        ICommand getWizardAttributes;
        ICommand getBanditAttributes;
        ICommand getLeshiiAttributes;
        ICommand setPlayerName;
        ICommand playerAttack;
        ICommand restoringHealthPoints;
        ICommand restoringActionPoints;
        ICommand increaseExperiencePoints;
        ICommand resetExperiencePoints;
        ICommand increaseLevel;
        ICommand increaseGold;
        ICommand enemyAttack;
        ICommand getPlayers;
        ICommand getAttributes;
        ICommand saveGame;
        ICommand createPlayer;

        #endregion

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
            this.setInitialLocation = setInitialLocation;
            this.setNextLocation = setNextLocation;
            this.setPreviousLocation = setPreviousLocation;
            this.increaseStrength = increaseStrength;
            this.increaseAgility = increaseAgility;
            this.increaseIntelligence = increaseIntelligence;
            this.getWarriorAttributes = getWarriorAttributes;
            this.getAssassinAttributes = getAssassinAttributes;
            this.getWizardAttributes = getWizardAttributes;
            this.getBanditAttributes = getBanditAttributes;
            this.getLeshiiAttributes = getLeshiiAttributes;
            this.setPlayerName = setPlayerName;
            this.playerAttack = playerAttack;
            this.restoringHealthPoints = restoringHealthPoints;
            this.restoringActionPoints = restoringActionPoints;
            this.increaseExperiencePoints = increaseExperiencePoints;
            this.resetExperiencePoints = resetExperiencePoints;
            this.increaseLevel = increaseLevel;
            this.increaseGold = increaseGold;
            this.enemyAttack = enemyAttack;
            this.getPlayers = getPlayers;
            this.getAttributes = getAttributes;
            this.saveGame = saveGame;
            this.createPlayer = createPlayer;
        }

        #endregion

        // заполнение словаря
        public void FillingDictionary()
        { 
            // словарь локаций
            dictionary.Add("SetInitialLocation", setInitialLocation);
            dictionary.Add("SetNextLocation", setNextLocation);
            dictionary.Add("SetPreviousLocation", setPreviousLocation);
            // словарь характеристик
            dictionary.Add("IncreaseStrength", increaseStrength);
            dictionary.Add("IncreaseAgility", increaseAgility);
            dictionary.Add("IncreaseIntelligence", increaseIntelligence);
            // соварь получения атрибутов персонажа
            dictionary.Add("GetWarriorAttributes", getWarriorAttributes);
            dictionary.Add("GetAssassinAttributes", getAssassinAttributes);
            dictionary.Add("GetWizardAttributes", getWizardAttributes);
            dictionary.Add("GetBanditAttributes", getBanditAttributes);
            dictionary.Add("GetLeshiiAttributes", getLeshiiAttributes);
            // словарь игрока
            dictionary.Add("SetPlayerName", setPlayerName);
            dictionary.Add("PlayerAttack", playerAttack);
            dictionary.Add("RestoringHealthPoints", restoringHealthPoints);
            dictionary.Add("RestoringActionPoints", restoringActionPoints);
            dictionary.Add("IncreaseExperiencePoints", increaseExperiencePoints);
            dictionary.Add("ResetExperiencePoints", resetExperiencePoints);
            dictionary.Add("IncreaseLevel", increaseLevel);
            dictionary.Add("IncreaseGold", increaseGold);
            // словарь врага
            dictionary.Add("EnemyAttack", enemyAttack);
            // словарь базы данных
            dictionary.Add("GetPlayers", getPlayers);
            dictionary.Add("GetAttributes", getAttributes);
            dictionary.Add("SaveGame", saveGame);
            dictionary.Add("CreatePlayer", createPlayer);
        }
    }
}
