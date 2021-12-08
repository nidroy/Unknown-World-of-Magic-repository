using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    #region команды локации

    // команда SetInitialLocation
    public class CommandSetInitialLocation : ICommand
    {
        Location location; // локация

        // конструктор
        public CommandSetInitialLocation(Location location)
        {
            this.location = location;
        }

        // выполнение команды
        public void Executing()
        {
            if (Client.command == "SetInitialLocation")
            {
                location.SetInitialLocation();
                Client.response = Location.locationName + "_" + Location.locationDescription + "_" + Enemy.enemyClass + "_" + Enemy.enemyHealthPoints.ToString() + "_" + Enemy.enemyLevel.ToString();
            }
        }
    }

    // команда SetNextLocation
    public class CommandSetNextLocation : ICommand
    {
        Location location; // локация

        // конструктор
        public CommandSetNextLocation(Location location)
        {
            this.location = location;
        }

        // выполнение команды
        public void Executing()
        {
            if(Client.command == "SetNextLocation")
            {
                location.SetNextLocation();
                Client.response = Location.locationName + "_" + Location.locationDescription + "_" + Enemy.enemyClass + "_" + Enemy.enemyHealthPoints.ToString() + "_" + Enemy.enemyLevel.ToString();
            }
        }
    }

    // команда SetPreviousLocation
    public class CommandSetPreviousLocation : ICommand
    {
        Location location; // локация

        // конструктор
        public CommandSetPreviousLocation(Location location)
        {
            this.location = location;
        }

        // выполнение команды
        public void Executing()
        {
            if(Client.command == "SetPreviousLocation")
            {
                location.SetPreviousLocation();
                Client.response = Location.locationName + "_" + Location.locationDescription + "_" + Enemy.enemyClass + "_" + Enemy.enemyHealthPoints.ToString() + "_" + Enemy.enemyLevel.ToString();
            }
        }
    }

    #endregion

    #region команды характеристик

    // команда IncreaseStrength
    public class CommandIncreaseStrength : ICommand
    {
        Characteristics characteristics; // характеристики

        // конструктор
        public CommandIncreaseStrength(Characteristics characteristics)
        {
            this.characteristics = characteristics;
        }

        // выполнение команды
        public void Executing()
        {
            if(Client.command == "IncreaseStrength")
            {
                characteristics.IncreaseStrength();
                Client.response = Characteristics.strength.ToString() + "_" + Player.playerHealthPoints.ToString() + "_" + Player.playerSkillPoints.ToString();
            }
        }
    }

    // команда IncreaseAgility
    public class CommandIncreaseAgility : ICommand
    {
        Characteristics characteristics; // характеристики

        // конструктор
        public CommandIncreaseAgility(Characteristics characteristics)
        {
            this.characteristics = characteristics;
        }

        // выполнение команды
        public void Executing()
        {
            if (Client.command == "IncreaseAgility")
            {
                characteristics.IncreaseAgility();
                Client.response = Characteristics.agility.ToString() + "_" + Player.playerSkillPoints.ToString();
            }
        }
    }

    // команда IncreaseIntelligence
    public class CommandIncreaseIntelligence : ICommand
    {
        Characteristics characteristics; // характеристики

        // конструктор
        public CommandIncreaseIntelligence(Characteristics characteristics)
        {
            this.characteristics = characteristics;
        }

        // выполнение команды
        public void Executing()
        {
            if (Client.command == "IncreaseIntelligence")
            {
                characteristics.IncreaseIntelligence();
                Client.response = Characteristics.intelligence.ToString() + "_" + Player.playerActionPoints.ToString() + "_" + Player.playerSkillPoints.ToString();
            }
        }
    }

    #endregion

    #region команды получения атрибутов персонажа

    // команда GetWarriorAttributes
    public class CommandGetWarriorAttributes : ICommand
    {
        IGetAttributes warrior = new Warrior(); // воин

        // конструктор
        public CommandGetWarriorAttributes(IGetAttributes warrior)
        {
            this.warrior = warrior;
        }

        // выполнение команды
        public void Executing()
        {
            if(Client.command == "GetWarriorAttributes")
            {
                warrior.GetCharacterAttributes();
                Client.response = Player.playerClass + "_" + Player.playerHealthPoints.ToString() + "_" + Player.playerActionPoints.ToString() + "_" + Player.playerExperiencePoints.ToString() + "_" + Player.playerSkillPoints.ToString() + "_" + Player.playerLevel.ToString() + "_" + Player.playerGold.ToString() + "_" + Characteristics.strength.ToString() + "_" + Characteristics.agility.ToString() + "_" + Characteristics.intelligence.ToString();
            }
        }
    }

    // команда GetAssassinAttributes
    public class CommandGetAssassinAttributes : ICommand
    {
        IGetAttributes assassin = new Assassin(); // ассасин

        // конструктор
        public CommandGetAssassinAttributes(IGetAttributes assassin)
        {
            this.assassin = assassin;
        }

        // выполнение команды
        public void Executing()
        {
            if(Client.command == "GetAssassinAttributes")
            {
                assassin.GetCharacterAttributes();
                Client.response = Player.playerClass + "_" + Player.playerHealthPoints.ToString() + "_" + Player.playerActionPoints.ToString() + "_" + Player.playerExperiencePoints.ToString() + "_" + Player.playerSkillPoints.ToString() + "_" + Player.playerLevel.ToString() + "_" + Player.playerGold.ToString() + "_" + Characteristics.strength.ToString() + "_" + Characteristics.agility.ToString() + "_" + Characteristics.intelligence.ToString();
            }
        }
    }

    // команда GetWizardAttributes
    public class CommandGetWizardAttributes : ICommand
    {
        IGetAttributes wizard = new Wizard(); // маг

        // конструктор
        public CommandGetWizardAttributes(IGetAttributes wizard)
        {
            this.wizard = wizard;
        }

        // выполнение команды
        public void Executing()
        {
            if(Client.command == "GetWizardAttributes")
            {
                wizard.GetCharacterAttributes();
                Client.response = Player.playerClass + "_" + Player.playerHealthPoints.ToString() + "_" + Player.playerActionPoints.ToString() + "_" + Player.playerExperiencePoints.ToString() + "_" + Player.playerSkillPoints.ToString() + "_" + Player.playerLevel.ToString() + "_" + Player.playerGold.ToString() + "_" + Characteristics.strength.ToString() + "_" + Characteristics.agility.ToString() + "_" + Characteristics.intelligence.ToString();
            }
        }
    }

    // команда GetBanditAttributes
    public class CommandGetBanditAttributes : ICommand
    {
        IGetAttributes bandit = new Bandit(); // разбойник

        // конструктор
        public CommandGetBanditAttributes(IGetAttributes bandit)
        {
            this.bandit = bandit;
        }

        // выполнение команды
        public void Executing()
        {
            if (Client.command == "GetBanditAttributes")
            {
                bandit.GetCharacterAttributes();
                Client.response = Enemy.enemyClass + "_" + Enemy.enemyHealthPoints.ToString() + "_" + Enemy.enemyLevel.ToString();
            }
        }
    }

    // команда GetLeshiiAttributes
    public class CommandGetLeshiiAttributes : ICommand
    {
        IGetAttributes leshii = new Leshii(); // леший

        public CommandGetLeshiiAttributes(IGetAttributes leshii)
        {
            this.leshii = leshii;
        }

        // выполнение команды
        public void Executing()
        {
            if (Client.command == "GetLeshiiAttributes")
            {
                leshii.GetCharacterAttributes();
                Client.response = Enemy.enemyClass + "_" + Enemy.enemyHealthPoints.ToString() + "_" + Enemy.enemyLevel.ToString();
            }
        }
    }

    #endregion

    #region команды игрока

    // команда SetPlayerName
    public class CommandSetPlayerName : ICommand
    {
        // конструктор
        public CommandSetPlayerName()
        {

        }

        // выполнение команды
        public void Executing()
        { 
            string[] command = Client.command.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

            if (command[0] == "SetPlayerName")
            {
                Player.playerName += command[1];
                Client.response = Player.playerName;
            }
        }
    }

    // команда PlayerAttack
    public class CommandPlayerAttack : ICommand
    {
        Player player; // игрок

        // конструктор
        public CommandPlayerAttack(Player player)
        {
            this.player = player;
        }

        // выполнение команды
        public void Executing()
        {
            if(Client.command == "PlayerAttack")
            {
                player.Attack();
                Client.response = Enemy.enemyHealthPoints.ToString() + "_" + Player.playerActionPoints.ToString();
            }
        }
    }

    // команда RestoringHealthPoints
    public class CommandRestoringHealthPoints : ICommand
    {
        Player player; // игрок

        // конструктор
        public CommandRestoringHealthPoints(Player player)
        {
            this.player = player;
        }

        // выполнение команды
        public void Executing()
        {
            if(Client.command == "RestoringHealthPoints")
            {
                player.RestoringHealthPoints();
                Client.response = Player.playerHealthPoints.ToString();
            }
        }
    }

    // команда RestoringActionPoints
    public class CommandRestoringActionPoints : ICommand
    {
        Player player; // игрок

        // конструктор
        public CommandRestoringActionPoints(Player player)
        {
            this.player = player;
        }

        // выполнение команды
        public void Executing()
        {
            if(Client.command == "RestoringActionPoints")
            {
                player.RestoringActionPoints();
                Client.response = Player.playerActionPoints.ToString();
            }
        }
    }

    // команда IncreaseExperiencePoints
    public class CommandIncreaseExperiencePoints : ICommand
    {
        Player player; // игрок

        // конструктор
        public CommandIncreaseExperiencePoints(Player player)
        {
            this.player = player;
        }

        // выполнение команды
        public void Executing()
        {
            if (Client.command == "IncreaseExperiencePoints")
            {
                player.IncreaseExperiencePoints();
                Client.response = Player.playerExperiencePoints.ToString();
            }
        }
    }

    // команда ResetExperiencePoints
    public class CommandResetExperiencePoints : ICommand
    {
        Player player; // игрок

        // конструктор
        public CommandResetExperiencePoints(Player player)
        {
            this.player = player;
        }

        // выполнение команды
        public void Executing()
        {
            if (Client.command == "ResetExperiencePoints")
            {
                player.ResetExperiencePoints();
                Client.response = Player.playerExperiencePoints.ToString();
            }
        }
    }

    // команда IncreaseLevel
    public class CommandIncreaseLevel : ICommand
    {
        Player player; // игрок

        // конструктор
        public CommandIncreaseLevel(Player player)
        {
            this.player = player;
        }

        // выполнение команды
        public void Executing()
        {
            if (Client.command == "IncreaseLevel")
            {
                player.IncreaseLevel();
                Client.response = Player.playerLevel.ToString() + "_" + Player.playerSkillPoints.ToString() + "_" + Characteristics.strength.ToString() + "_" + Characteristics.agility.ToString() + "_" + Characteristics.intelligence.ToString();
            }
        }
    }

    // команда IncreaseGold
    public class CommandIncreaseGold : ICommand
    {
        Player player; // игрок

        // конструктор
        public CommandIncreaseGold(Player player)
        {
            this.player = player;
        }

        // выполнение команды
        public void Executing()
        {
            if (Client.command == "IncreaseGold")
            {
                player.IncreaseGold();
                Client.response = Player.playerGold.ToString();
            }
        }
    }

    #endregion

    #region команды врага

    // команда EnemyAttack
    public class CommandEnemyAttack : ICommand
    {
        Enemy enemy; // враг

        // конструктор
        public CommandEnemyAttack(Enemy enemy)
        {
            this.enemy = enemy;
        }

        // выполнение команды
        public void Executing()
        {
            if (Client.command == "EnemyAttack")
            {
                enemy.Attack();
                Client.response = Player.playerHealthPoints.ToString();
            }
        }
    }

    #endregion

    #region команды увеличения основной характеристики

    // команда IncreaseStrengthWarrior
    public class CommandIncreaseStrengthWarrior: IIncreaseMainCharacteristic
    {
        Characteristics characteristics; // характеристики

        // конструктор
        public CommandIncreaseStrengthWarrior(Characteristics characteristics)
        {
            this.characteristics = characteristics;
        }

        // выполнение увеличения основной характеристики
        public void IncreaseMainCharacteristic()
        {
            if(Player.playerClass == "Warrior")
            {
                characteristics.IncreaseStrength();
            }
        }
    }

    // команда IncreaseAgilityAssassin
    public class CommandIncreaseAgilityAssassin : IIncreaseMainCharacteristic
    {
        Characteristics characteristics; // характеристики

        // конструктор
        public CommandIncreaseAgilityAssassin(Characteristics characteristics)
        {
            this.characteristics = characteristics;
        }

        // выполнение увеличения основной характеристики
        public void IncreaseMainCharacteristic()
        {
            if (Player.playerClass == "Assassin")
            {
                characteristics.IncreaseAgility();
            }
        }
    }

    // команда IncreaseIntelligenceWizard
    public class CommandIncreaseIntelligenceWizard : IIncreaseMainCharacteristic
    {
        Characteristics characteristics; // характеристики

        // конструктор
        public CommandIncreaseIntelligenceWizard(Characteristics characteristics)
        {
            this.characteristics = characteristics;
        }

        // выполнение увеличения основной характеристики
        public void IncreaseMainCharacteristic()
        {
            if (Player.playerClass == "Wizard")
            {
                characteristics.IncreaseIntelligence();
            }
        }
    }

    #endregion
}
