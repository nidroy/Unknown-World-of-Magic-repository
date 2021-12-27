using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    // команда SetInitialLocation
    public class CommandSetInitialLocation : ICommand
    {
        Location location;

        public CommandSetInitialLocation(Location location)
        {
            this.location = location;
        }

        public string Execute()
        {
            return location.SetInitialLocation();
        }
    }

    // команда SetNextLocation
    public class CommandSetNextLocation : ICommand
    {
        Location location;

        public CommandSetNextLocation(Location location)
        {
            this.location = location;
        }

        public string Execute()
        {
            return location.SetNextLocation();
        }
    }

    // команда SetPreviousLocation
    public class CommandSetPreviousLocation : ICommand
    {
        Location location;

        public CommandSetPreviousLocation(Location location)
        {
            this.location = location;
        }

        public string Execute()
        {
            return location.SetPreviousLocation();
        }
    }

    // команда IncreaseStrength
    public class CommandIncreaseStrength : ICommand
    {
        Characteristics characteristics;

        public CommandIncreaseStrength(Characteristics characteristics)
        {
            this.characteristics = characteristics;
        }

        public string Execute()
        {
            return characteristics.IncreaseStrength();
        }
    }

    // команда IncreaseAgility
    public class CommandIncreaseAgility : ICommand
    {
        Characteristics characteristics;

        public CommandIncreaseAgility(Characteristics characteristics)
        {
            this.characteristics = characteristics;
        }

        public string Execute()
        {
            return characteristics.IncreaseAgility();
        }
    }

    // команда IncreaseIntelligence
    public class CommandIncreaseIntelligence : ICommand
    {
        Characteristics characteristics;

        public CommandIncreaseIntelligence(Characteristics characteristics)
        {
            this.characteristics = characteristics;
        }

        public string Execute()
        {
            return characteristics.IncreaseIntelligence();
        }
    }

    // команда GetWarriorAttributes
    public class CommandGetWarriorAttributes : ICommand
    {
        public string Execute()
        {
            return Warrior.GetWarriorAttributes();
        }
    }

    // команда GetAssassinAttributes
    public class CommandGetAssassinAttributes : ICommand
    {
        public string Execute()
        {
            return Assassin.GetAssassinAttributes();
        }
    }

    // команда GetWizardAttributes
    public class CommandGetWizardAttributes : ICommand
    {
        public string Execute()
        {
            return Wizard.GetWizardAttributes();
        }
    }

    // команда GetBanditAttributes
    public class CommandGetBanditAttributes : ICommand
    {
        public string Execute()
        {
            return Bandit.GetBanditAttributes();
        }
    }

    // команда GetLeshiiAttributes
    public class CommandGetLeshiiAttributes : ICommand
    {
        public string Execute()
        {
            return Leshii.GetLeshiiAttributes();
        }
    }

    // команда SetPlayerName
    public class CommandSetPlayerName : ICommand
    {
        Player player;

        public CommandSetPlayerName(Player player)
        {
            this.player = player;
        }

        public string Execute()
        {
            return player.SetPlayerName(Client.command[1]);
        }
    }

    // команда PlayerAttack
    public class CommandPlayerAttack : ICommand
    {
        Player player;

        public CommandPlayerAttack(Player player)
        {
            this.player = player;
        }

        public string Execute()
        {
            return player.Attack();
        }
    }

    // команда RestoringHealthPoints
    public class CommandRestoringHealthPoints : ICommand
    {
        Player player;

        public CommandRestoringHealthPoints(Player player)
        {
            this.player = player;
        }

        public string Execute()
        {
            return player.RestoringHealthPoints();
        }
    }

    // команда RestoringActionPoints
    public class CommandRestoringActionPoints : ICommand
    {
        Player player;

        public CommandRestoringActionPoints(Player player)
        {
            this.player = player;
        }

        public string Execute()
        {
            return player.RestoringActionPoints();
        }
    }

    // команда IncreaseExperiencePoints
    public class CommandIncreaseExperiencePoints : ICommand
    {
        Player player;

        public CommandIncreaseExperiencePoints(Player player)
        {
            this.player = player;
        }

        public string Execute()
        {
            return player.IncreaseExperiencePoints();
        }
    }

    // команда ResetExperiencePoints
    public class CommandResetExperiencePoints : ICommand
    {
        Player player;

        public CommandResetExperiencePoints(Player player)
        {
            this.player = player;
        }

        public string Execute()
        {
            return player.ResetExperiencePoints();
        }
    }

    // команда IncreaseLevel
    public class CommandIncreaseLevel : ICommand
    {
        Player player;

        public CommandIncreaseLevel(Player player)
        {
            this.player = player;
        }

        public string Execute()
        {
            return player.IncreaseLevel();
        }
    }

    // команда IncreaseGold
    public class CommandIncreaseGold : ICommand
    {
        Player player;

        public CommandIncreaseGold(Player player)
        {
            this.player = player;
        }

        public string Execute()
        {
            return player.IncreaseGold();
        }
    }

    // команда EnemyAttack
    public class CommandEnemyAttack : ICommand
    {
        Enemy enemy;

        public CommandEnemyAttack(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public string Execute()
        {
            return enemy.Attack();
        }
    }

    // команда GetPlayers
    public class CommandGetPlayers : ICommand
    {
        Database database;

        public CommandGetPlayers(Database database)
        {
            this.database = database;
        }

        public string Execute()
        {
            string result = "";
            if (database.GetPlayers().Count == 0)
            {
                result = "NULL+";
            }
            else
            {
                for (int i = 0; i < database.GetPlayers().Count; i++)
                {
                    result += database.GetPlayers()[i] + "+";
                }
            }
            return result.Remove(result.Length - 1);
        }
    }

    // команда GetAttributes
    public class CommandGetAttributes : ICommand
    {
        Database database;

        public CommandGetAttributes(Database database)
        {
            this.database = database;
        }

        public string Execute()
        {
            return database.GetAttributes(Client.command[1]);
        }
    }

    // команда SaveGame
    public class CommandSaveGame : ICommand
    {
        Database database;

        public CommandSaveGame(Database database)
        {
            this.database = database;
        }

        public string Execute()
        {
            database.SaveGame(Player.playerName);
            return "THE GAME IS SAVED";
        }
    }

    // команда CreatePlayer
    public class CommandCreatePlayer : ICommand
    {
        Database database;

        public CommandCreatePlayer(Database database)
        {
            this.database = database;
        }

        public string Execute()
        {
            return database.CreatePlayer();
        }
    }
}
