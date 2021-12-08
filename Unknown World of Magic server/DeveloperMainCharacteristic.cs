using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class DeveloperMainCharacteristic
    {
        #region команды

        IIncreaseMainCharacteristic increaseStrengthWarrior;
        IIncreaseMainCharacteristic increaseAgilityAssassin;
        IIncreaseMainCharacteristic increaseIntelligenceWizard;

        #endregion

        #region конструктор

        public DeveloperMainCharacteristic(
            IIncreaseMainCharacteristic increaseStrengthWarrior, 
            IIncreaseMainCharacteristic increaseAgilityAssassin, 
            IIncreaseMainCharacteristic increaseIntelligenceWizard
            )
        {
            this.increaseStrengthWarrior = increaseStrengthWarrior;
            this.increaseAgilityAssassin = increaseAgilityAssassin;
            this.increaseIntelligenceWizard = increaseIntelligenceWizard;
        }

        #endregion

        #region выполнение команд

        // выполнение команды IncreaseStrengthWarrior
        public void ExecutingIncreaseStrengthWarrior()
        {
            increaseStrengthWarrior.IncreaseMainCharacteristic();
        }

        // выполнение команды IncreaseAgilityAssassin
        public void ExecutingIncreaseAgilityAssassin()
        {
            increaseAgilityAssassin.IncreaseMainCharacteristic();
        }

        // выполнение команды IncreaseIntelligenceWizard
        public void ExecutingIncreaseIntelligenceWizard()
        {
            increaseIntelligenceWizard.IncreaseMainCharacteristic();
        }

        #endregion
    }
}
