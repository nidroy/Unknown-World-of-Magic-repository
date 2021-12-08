using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Warrior : IGetAttributes
    {
        // получить атрибуты война
        public void GetCharacterAttributes()
        {
            Player.playerClass = "Warrior";
            Player.playerHealthPoints = 120;
            Player.playerActionPoints = 80;
            Player.playerExperiencePoints = 0;
            Player.playerSkillPoints = 0;
            Player.playerLevel = 0;
            Player.playerGold = 0;
            Player.playerDamage = 10;
            Player.playerMiss = 20;

            Characteristics.strength = 12;
            Characteristics.agility = 10;
            Characteristics.intelligence = 8;
        }
    }
}
