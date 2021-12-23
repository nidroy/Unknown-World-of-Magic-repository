using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Wizard : Player
    {
        // получить атрибуты мага
        public static string GetWizardAttributes()
        {
            playerClass = "Wizard";
            playerHealthPoints = 80;
            playerActionPoints = 120;
            playerExperiencePoints = 0;
            playerSkillPoints = 0;
            playerLevel = 0;
            playerGold = 0;
            playerDamage = 15;
            playerMiss = 5;

            Characteristics.strength = 8;
            Characteristics.agility = 15;
            Characteristics.intelligence = 12;
            return String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}_{9}", playerClass, playerHealthPoints, playerActionPoints, playerExperiencePoints, playerSkillPoints, playerLevel, playerGold, Characteristics.strength, Characteristics.agility, Characteristics.intelligence);
        }
    }
}
