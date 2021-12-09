using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Developer
    {
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

        #endregion

        #region конструктор

        public Developer
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
            ICommand enemyAttack)
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

        public void ExecuteSetInitialLocation()
        {
            setInitialLocation.Execute();
        }
        public void ExecuteSetNextLocation()
        {
            setNextLocation.Execute();
        }
        public void ExecuteSetPreviousLocation()
        {
            setPreviousLocation.Execute();
        }
        public void ExecuteIncreaseStrength()
        {
            increaseStrength.Execute();
        }
        public void ExecuteIncreaseAgility()
        {
            increaseAgility.Execute();
        }
        public void ExecuteIncreaseIntelligence()
        {
            increaseIntelligence.Execute();
        }
        public void ExecuteGetWarriorAttributes()
        {
            getWarriorAttributes.Execute();
        }
        public void ExecuteGetAssassinAttributes()
        {
            getAssassinAttributes.Execute();
        }
        public void ExecuteGetWizardAttributes()
        {
            getWizardAttributes.Execute();
        }
        public void ExecuteGetBanditAttributes()
        {
            getBanditAttributes.Execute();
        }
        public void ExecuteGetLeshiiAttributes()
        {
            getLeshiiAttributes.Execute();
        }
        public void ExecuteSetPlayerName()
        {
            setPlayerName.Execute();
        }
        public void ExecutePlayerAttack()
        {
            playerAttack.Execute();
        }
        public void ExecuteRestoringHealthPoints()
        {
            restoringHealthPoints.Execute();
        }
        public void ExecuteRestoringActionPoints()
        {
            restoringActionPoints.Execute();
        }
        public void ExecuteIncreaseExperiencePoints()
        {
            increaseExperiencePoints.Execute();
        }
        public void ExecuteResetExperiencePoints()
        {
            resetExperiencePoints.Execute();
        }
        public void ExecuteIncreaseLevel()
        {
            increaseLevel.Execute();
        }
        public void ExecuteIncreaseGold()
        {
            increaseGold.Execute();
        }
        public void ExecuteEnemyAttack()
        {
            enemyAttack.Execute();
        }

        #endregion
    }
}
