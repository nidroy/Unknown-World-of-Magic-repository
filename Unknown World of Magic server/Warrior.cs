using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Warrior : Player
    {
        // получить атрибуты война
        public static string GetWarriorAttributes()
        {
            playerClass = "Warrior";
            playerHealthPoints = 120;
            playerActionPoints = 80;
            playerExperiencePoints = 0;
            playerSkillPoints = 0;
            playerLevel = 0;
            playerGold = 0;
            playerDamage = 10;
            playerMiss = 20;

            Characteristics.strength = 12;
            Characteristics.agility = 10;
            Characteristics.intelligence = 8;
            return String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}_{9}", playerClass, playerHealthPoints, playerActionPoints, playerExperiencePoints, playerSkillPoints, playerLevel, playerGold, Characteristics.strength, Characteristics.agility, Characteristics.intelligence);
        }
    }
}
