using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    // команда SetInitialLocation
    public class CommandSetInitialLocation : ICommand
    {
        Location location;
        Dictionary dictionary;

        public CommandSetInitialLocation(Location location, Dictionary dictionary)
        {
            this.location = location;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("SetInitialLocation", location.SetInitialLocation());
        }
    }

    // команда SetNextLocation
    public class CommandSetNextLocation : ICommand
    {
        Location location;
        Dictionary dictionary;

        public CommandSetNextLocation(Location location, Dictionary dictionary)
        {
            this.location = location;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("SetNextLocation", location.SetNextLocation());
        }
    }

    // команда SetPreviousLocation
    public class CommandSetPreviousLocation : ICommand
    {
        Location location;
        Dictionary dictionary;

        public CommandSetPreviousLocation(Location location, Dictionary dictionary)
        {
            this.location = location;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("SetPreviousLocation", location.SetPreviousLocation());
        }
    }

    // команда IncreaseStrength
    public class CommandIncreaseStrength : ICommand
    {
        Characteristics characteristics;
        Dictionary dictionary;

        public CommandIncreaseStrength(Characteristics characteristics, Dictionary dictionary)
        {
            this.characteristics = characteristics;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("IncreaseStrength", characteristics.IncreaseStrength());
        }
    }

    // команда IncreaseAgility
    public class CommandIncreaseAgility : ICommand
    {
        Characteristics characteristics;
        Dictionary dictionary;

        public CommandIncreaseAgility(Characteristics characteristics, Dictionary dictionary)
        {
            this.characteristics = characteristics;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("IncreaseAgility", characteristics.IncreaseAgility());
        }
    }

    // команда IncreaseIntelligence
    public class CommandIncreaseIntelligence : ICommand
    {
        Characteristics characteristics;
        Dictionary dictionary;

        public CommandIncreaseIntelligence(Characteristics characteristics, Dictionary dictionary)
        {
            this.characteristics = characteristics;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("IncreaseIntelligence", characteristics.IncreaseIntelligence());
        }
    }

    // команда GetWarriorAttributes
    public class CommandGetWarriorAttributes : ICommand
    {
        Dictionary dictionary;

        public CommandGetWarriorAttributes(Dictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("GetWarriorAttributes", Warrior.GetWarriorAttributes());
        }
    }

    // команда GetAssassinAttributes
    public class CommandGetAssassinAttributes : ICommand
    {
        Dictionary dictionary;

        public CommandGetAssassinAttributes(Dictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("GetAssassinAttributes", Assassin.GetAssassinAttributes());
        }
    }

    // команда GetWizardAttributes
    public class CommandGetWizardAttributes : ICommand
    {
        Dictionary dictionary;

        public CommandGetWizardAttributes(Dictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("GetWizardAttributes", Wizard.GetWizardAttributes());
        }
    }

    // команда GetBanditAttributes
    public class CommandGetBanditAttributes : ICommand
    {
        Dictionary dictionary;

        public CommandGetBanditAttributes(Dictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("GetBanditAttributes", Bandit.GetBanditAttributes());
        }
    }

    // команда GetLeshiiAttributes
    public class CommandGetLeshiiAttributes : ICommand
    {
        Dictionary dictionary;

        public CommandGetLeshiiAttributes(Dictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("GetLeshiiAttributes", Leshii.GetLeshiiAttributes());
        }
    }

    // команда SetPlayerName
    public class CommandSetPlayerName : ICommand
    {
        Player player;
        Dictionary dictionary;

        public CommandSetPlayerName(Player player, Dictionary dictionary)
        {
            this.player = player;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("SetPlayerName", player.SetPlayerName());
        }
    }

    // команда PlayerAttack
    public class CommandPlayerAttack : ICommand
    {
        Player player;
        Dictionary dictionary;

        public CommandPlayerAttack(Player player, Dictionary dictionary)
        {
            this.player = player;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("PlayerAttack", player.Attack());
        }
    }

    // команда RestoringHealthPoints
    public class CommandRestoringHealthPoints : ICommand
    {
        Player player;
        Dictionary dictionary;

        public CommandRestoringHealthPoints(Player player, Dictionary dictionary)
        {
            this.player = player;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("RestoringHealthPoints", player.RestoringHealthPoints());
        }
    }

    // команда RestoringActionPoints
    public class CommandRestoringActionPoints : ICommand
    {
        Player player;
        Dictionary dictionary;

        public CommandRestoringActionPoints(Player player, Dictionary dictionary)
        {
            this.player = player;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("RestoringActionPoints", player.RestoringActionPoints());
        }
    }

    // команда IncreaseExperiencePoints
    public class CommandIncreaseExperiencePoints : ICommand
    {
        Player player;
        Dictionary dictionary;

        public CommandIncreaseExperiencePoints(Player player, Dictionary dictionary)
        {
            this.player = player;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("IncreaseExperiencePoints", player.IncreaseExperiencePoints());
        }
    }

    // команда ResetExperiencePoints
    public class CommandResetExperiencePoints : ICommand
    {
        Player player;
        Dictionary dictionary;

        public CommandResetExperiencePoints(Player player, Dictionary dictionary)
        {
            this.player = player;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("ResetExperiencePoints", player.ResetExperiencePoints());
        }
    }

    // команда IncreaseLevel
    public class CommandIncreaseLevel : ICommand
    {
        Player player;
        Dictionary dictionary;

        public CommandIncreaseLevel(Player player, Dictionary dictionary)
        {
            this.player = player;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("IncreaseLevel", player.IncreaseLevel());
        }
    }

    // команда IncreaseGold
    public class CommandIncreaseGold : ICommand
    {
        Player player;
        Dictionary dictionary;

        public CommandIncreaseGold(Player player, Dictionary dictionary)
        {
            this.player = player;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("IncreaseGold", player.IncreaseGold());
        }
    }

    // команда EnemyAttack
    public class CommandEnemyAttack : ICommand
    {
        Enemy enemy;
        Dictionary dictionary;

        public CommandEnemyAttack(Enemy enemy, Dictionary dictionary)
        {
            this.enemy = enemy;
            this.dictionary = dictionary;
        }

        public void Execute()
        {
            dictionary.OverwritingDictionaryElement("EnemyAttack", enemy.Attack());
        }
    }
}
