using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Wizard : IGetAttributes
    {
        // получить атрибуты мага
        public void GetCharacterAttributes()
        {
            Player.playerClass = "Wizard";
            Player.playerHealthPoints = 80;
            Player.playerActionPoints = 120;
            Player.playerExperiencePoints = 0;
            Player.playerSkillPoints = 0;
            Player.playerLevel = 0;
            Player.playerGold = 0;
            Player.playerDamage = 15;
            Player.playerMiss = 5;

            Characteristics.strength = 8;
            Characteristics.agility = 15;
            Characteristics.intelligence = 12;
        }
    }
}
