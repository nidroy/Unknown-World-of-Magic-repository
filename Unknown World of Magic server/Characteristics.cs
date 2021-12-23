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
            if (Player.playerSkillPoints > 0)
            {
                strength++;
                Player.playerHealthPoints = strength * 10;
                Player.playerSkillPoints--;
            }
            return String.Format("{0}_{1}_{2}", strength, Player.playerHealthPoints, Player.playerSkillPoints);
        }

        // увеличить ловкость
        public string IncreaseAgility()
        {
            if (Player.playerSkillPoints > 0)
            {
                agility++;
                Player.playerDamage = agility;
                Player.playerSkillPoints--;
            }
            return String.Format("{0}_{1}", agility, Player.playerSkillPoints);
        }

        // увеличить интеллект
        public string IncreaseIntelligence()
        {
            if (Player.playerSkillPoints > 0)
            {
                intelligence++;
                Player.playerActionPoints = intelligence * 10;
                Player.playerSkillPoints--;
            }
            return String.Format("{0}_{1}_{2}", intelligence, Player.playerActionPoints, Player.playerSkillPoints);
        }
    }
}
