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
        public void IncreaseStrength()
        {
            if (Player.playerSkillPoints > 0)
            {
                strength++;
                Player.playerHealthPoints = strength * 10;
                Player.playerSkillPoints--;
            }
        }

        // увеличить ловкость
        public void IncreaseAgility()
        {
            if (Player.playerSkillPoints > 0)
            {
                agility++;
                Player.playerDamage = agility;
                Player.playerSkillPoints--;
            }
        }

        // увеличить интеллект
        public void IncreaseIntelligence()
        {
            if (Player.playerSkillPoints > 0)
            {
                intelligence++;
                Player.playerActionPoints = intelligence * 10;
                Player.playerSkillPoints--;
            }
        }
    }
}
