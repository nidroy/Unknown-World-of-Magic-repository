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
            if (Client.command[0] == "GetAssassinAttributes")
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
            }
            return playerClass + "_" + playerHealthPoints.ToString() + "_" + playerActionPoints.ToString() + "_" + playerExperiencePoints.ToString() + "_" + playerSkillPoints.ToString() + "_" + playerLevel.ToString() + "_" + playerGold.ToString() + "_" + Characteristics.strength.ToString() + "_" + Characteristics.agility.ToString() + "_" + Characteristics.intelligence.ToString();
        }
    }
}
