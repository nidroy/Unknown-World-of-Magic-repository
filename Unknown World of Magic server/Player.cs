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

        // атака
        public void Attack()
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
        }

        // восстановление очков здоровья
        public void RestoringHealthPoints()
        {
            if (playerHealthPoints < Characteristics.strength * 10)
            {
                playerHealthPoints++;
            }
        }

        // восстановление очков действий
        public void RestoringActionPoints()
        {
            if (playerActionPoints < Characteristics.intelligence * 10)
            {
                playerActionPoints++;
            }
        }

        // увеличить очки опыта
        public void IncreaseExperiencePoints()
        {
            playerExperiencePoints += Enemy.enemyExperiencePoints;
        }

        // обнулить очки опыта
        public void ResetExperiencePoints()
        {
            playerExperiencePoints = 0;
        }

        // увеличить уровень
        public void IncreaseLevel()
        {
            Characteristics characteristics = new Characteristics(); // характеристики
            DeveloperMainCharacteristic developer = new DeveloperMainCharacteristic(
                new CommandIncreaseStrengthWarrior(characteristics),
                new CommandIncreaseAgilityAssassin(characteristics),
                new CommandIncreaseIntelligenceWizard(characteristics)
                ); // разработчик

            playerLevel++;
            for (int i = 0; i < 3; i++)
                IncreaseSkillPoints();

            #region выполнение команд

            developer.ExecutingIncreaseStrengthWarrior();
            developer.ExecutingIncreaseAgilityAssassin();
            developer.ExecutingIncreaseIntelligenceWizard();

            #endregion
        }

        // увеличить очки навыков
        public void IncreaseSkillPoints()
        {
            playerSkillPoints++;
        }

        // увеличить золото
        public void IncreaseGold()
        {
            playerGold += Enemy.enemyGold;
        }

    }
}
