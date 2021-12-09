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
            if (Client.command[0] == "GetWarriorAttributes")
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
            }
            return playerClass + "_" + playerHealthPoints.ToString() + "_" + playerActionPoints.ToString() + "_" + playerExperiencePoints.ToString() + "_" + playerSkillPoints.ToString() + "_" + playerLevel.ToString() + "_" + playerGold.ToString() + "_" + Characteristics.strength.ToString() + "_" + Characteristics.agility.ToString() + "_" + Characteristics.intelligence.ToString();
        }
    }
}
