using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Developer
    {
        #region команды

        #region локации

        ICommand setInitialLocation;
        ICommand setNextLocation;
        ICommand setPreviousLocation;

        #endregion

        #region характеристик

        ICommand increaseStrength;
        ICommand increaseAgility;
        ICommand increaseIntelligence;

        #endregion

        #region получения атрибутов персонажа

        ICommand getWarriorAttributes;
        ICommand getAssassinAttributes;
        ICommand getWizardAttributes;
        ICommand getBanditAttributes;
        ICommand getLeshiiAttributes;

        #endregion

        #region игрока

        ICommand setPlayerName;
        ICommand playerAttack;
        ICommand restoringHealthPoints;
        ICommand restoringActionPoints;
        ICommand increaseExperiencePoints;
        ICommand resetExperiencePoints;
        ICommand increaseLevel;
        ICommand increaseGold;

        #endregion

        #region врага

        ICommand enemyAttack;

        #endregion

        #endregion

        #region конструктор

        public Developer(
            ICommand setInitialLocation,
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
            ICommand enemyAttack
            )
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
        }

        #endregion

        #region выполнение команд

        #region локации

        // выполнение команды SetInitialLocation
        public void ExecutingSetInitialLocation()
        {
            setInitialLocation.Executing();
        }

        // выполнение команды SetNextLocation
        public void ExecutingSetNextLocation()
        {
            setNextLocation.Executing();
        }

        // выполнение команды SetPreviousLocation
        public void ExecutingSetPreviousLocation()
        {
            setPreviousLocation.Executing();
        }

        #endregion

        #region характеристик

        // выполнение команды IncreaseStrength
        public void ExecutingIncreaseStrength()
        {
            increaseStrength.Executing();
        }

        // выполнение команды IncreaseAgility
        public void ExecutingIncreaseAgility()
        {
            increaseAgility.Executing();
        }

        // выполнение команды IncreaseIntelligence
        public void ExecutingIncreaseIntelligence()
        {
            increaseIntelligence.Executing();
        }

        #endregion

        #region получения атрибутов персонажа

        // выполнение команды GetWarriorAttributes
        public void ExecutingGetWarriorAttributes()
        {
            getWarriorAttributes.Executing();
        }

        // выполнение команды GetAssassinAttributes
        public void ExecutingGetAssassinAttributes()
        {
            getAssassinAttributes.Executing();
        }

        // выполнение команды GetWizardAttributes
        public void ExecutingGetWizardAttributes()
        {
            getWizardAttributes.Executing();
        }

        // выполнение команды GetBanditAttributes
        public void ExecutingGetBanditAttributes()
        {
            getBanditAttributes.Executing();
        }

        // выполнение команды GetLeshiiAttributes
        public void ExecutingGetLeshiiAttributes()
        {
            getLeshiiAttributes.Executing();
        }

        #endregion

        #region игрока

        // выполнение команды SetPlayerName
        public void ExecutingSetPlayerName()
        {
            setPlayerName.Executing();
        }

        // выполнение команды PlayerAttack
        public void ExecutingPlayerAttack()
        {
            playerAttack.Executing();
        }

        // выполнение команды RestoringHealthPoints
        public void ExecutingRestoringHealthPoints()
        {
            restoringHealthPoints.Executing();
        }

        // выполнение команды RestoringActionPoints
        public void ExecutingRestoringActionPoints()
        {
            restoringActionPoints.Executing();
        }

        // выполнение команды IncreaseExperiencePoints
        public void ExecutingIncreaseExperiencePoints()
        {
            increaseExperiencePoints.Executing();
        }

        // выполнение команды ResetExperiencePoints
        public void ExecutingResetExperiencePoints()
        {
            resetExperiencePoints.Executing();
        }

        // выполнение команды IncreaseLevel
        public void ExecutingIncreaseLevel()
        {
            increaseLevel.Executing();
        }

        // выполнение команды IncreaseGold
        public void ExecutingIncreaseGold()
        {
            increaseGold.Executing();
        }

        #endregion

        #region врага

        // выполнение команды EnemyAttack
        public void ExecutingEnemyAttack()
        {
            enemyAttack.Executing();
        }

        #endregion

        #endregion
    }
}
