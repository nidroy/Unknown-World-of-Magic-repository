using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Characteristics
    {
        public static int strength { get; set; } // сила
        public static int agility { get; set; } // ловкость
        public static int intelligence { get; set; } // интеллект

        // увеличить силу
        public string IncreaseStrength()
        {
            if (Player.playerSkillPoints > 0 && Client.command[0] == "IncreaseStrength")
            {
                strength++;
                Player.playerHealthPoints = strength * 10;
                Player.playerSkillPoints--;
            }
            return strength.ToString() + "_" + Player.playerHealthPoints.ToString() + "_" + Player.playerSkillPoints.ToString();
        }

        // увеличить ловкость
        public string IncreaseAgility()
        {
            if (Player.playerSkillPoints > 0 && Client.command[0] == "IncreaseAgility")
            {
                agility++;
                Player.playerDamage = agility;
                Player.playerSkillPoints--;
            }
            return agility.ToString() + "_" + Player.playerSkillPoints.ToString();
        }

        // увеличить интеллект
        public string IncreaseIntelligence()
        {
            if (Player.playerSkillPoints > 0 && Client.command[0] == "IncreaseIntelligence")
            {
                intelligence++;
                Player.playerActionPoints = intelligence * 10;
                Player.playerSkillPoints--;
            }
            return intelligence.ToString() + "_" + Player.playerActionPoints.ToString() + "_" + Player.playerSkillPoints.ToString();
        }
    }
}
