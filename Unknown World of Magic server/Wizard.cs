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
            if (Client.command[0] == "GetWizardAttributes")
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
            }
            return playerClass + "_" + playerHealthPoints.ToString() + "_" + playerActionPoints.ToString() + "_" + playerExperiencePoints.ToString() + "_" + playerSkillPoints.ToString() + "_" + playerLevel.ToString() + "_" + playerGold.ToString() + "_" + Characteristics.strength.ToString() + "_" + Characteristics.agility.ToString() + "_" + Characteristics.intelligence.ToString();
        }
    }
}
