using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Player
    {
        public static string playerName { get; set; } // имя игрока
        public static string playerClass { get; set; } // класс игрока
        public static int playerHealthPoints { get; set; } // очки здоровья игрока
        public static int playerActionPoints { get; set; } // очки действий игрока
        public static int playerExperiencePoints { get; set; } // очки опыта игрока
        public static int playerSkillPoints { get; set; } // очки навыков игрока
        public static int playerLevel { get; set; } // уровень игрока
        public static int playerGold { get; set; } // золото игрока
        public static int playerDamage { get; set; } // урон игрока
        public static int playerMiss { get; set; } // промах игрока

        // установить имя игрока
        public string SetPlayerName()
        {
            playerName = Client.command[1];
            return playerName;
        }

        // атака
        public string Attack()
        {
            if (playerActionPoints >= playerDamage)
            {
                Random random = new Random();
                if (random.Next(0, 100) < 100 - playerMiss)
                {
                    Enemy.enemyHealthPoints -= random.Next(playerDamage, playerDamage + random.Next(10, 21));
                }
                playerActionPoints -= playerDamage;
            }
            return String.Format("{0}_{1}", Enemy.enemyHealthPoints, playerActionPoints);
        }

        // восстановление очков здоровья
        public string RestoringHealthPoints()
        {
            if (playerHealthPoints < Characteristics.strength * 10)
            {
                playerHealthPoints++;
            }
            return playerHealthPoints.ToString();
        }

        // восстановление очков действий
        public string RestoringActionPoints()
        {
            if (playerActionPoints < Characteristics.intelligence * 10)
            {
                playerActionPoints++;
            }
            return playerActionPoints.ToString();
        }

        // увеличить очки опыта
        public string IncreaseExperiencePoints()
        {
            playerExperiencePoints += Enemy.enemyExperiencePoints;
            return playerExperiencePoints.ToString();
        }

        // обнулить очки опыта
        public string ResetExperiencePoints()
        {
            playerExperiencePoints = 0;
            return playerExperiencePoints.ToString();
        }

        // увеличить уровень
        public string IncreaseLevel()
        {
            playerLevel++;
            for (int i = 0; i < 3; i++)
                IncreaseSkillPoints();
            if (playerClass == "Warrior")
            {
                Characteristics characteristics = new Characteristics();
                characteristics.IncreaseStrength();
            }
            else if (playerClass == "Assassin")
            {
                Characteristics characteristics = new Characteristics();
                characteristics.IncreaseAgility();
            }
            else if (playerClass == "Wizard")
            {
                Characteristics characteristics = new Characteristics();
                characteristics.IncreaseIntelligence();
            }
            return String.Format("{0}_{1}_{2}_{3}_{4}", playerLevel, playerSkillPoints, Characteristics.strength, Characteristics.agility, Characteristics.intelligence);
        }

        // увеличить очки навыков
        public void IncreaseSkillPoints()
        {
            playerSkillPoints++;
        }

        // увеличить золото
        public string IncreaseGold()
        {
            playerGold += Enemy.enemyGold;
            return playerGold.ToString();
        }
    }
}
