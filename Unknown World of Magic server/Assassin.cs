using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Assassin : Player
    {
        // получить атрибуты ассасина
        public static string GetAssassinAttributes()
        {
            playerClass = "Assassin";
            playerHealthPoints = 100;
            playerActionPoints = 100;
            playerExperiencePoints = 0;
            playerSkillPoints = 0;
            playerLevel = 0;
            playerGold = 0;
            playerDamage = 10;
            playerMiss = 10;

            Characteristics.strength = 10;
            Characteristics.agility = 10;
            Characteristics.intelligence = 10;
            return String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}_{9}", playerClass, playerHealthPoints, playerActionPoints, playerExperiencePoints, playerSkillPoints, playerLevel, playerGold, Characteristics.strength, Characteristics.agility, Characteristics.intelligence);
        }
    }
}
