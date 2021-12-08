using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Assassin : IGetAttributes
    {
        // получить атрибуты ассасина
        public void GetCharacterAttributes()
        {
            Player.playerClass = "Assassin";
            Player.playerHealthPoints = 100;
            Player.playerActionPoints = 100;
            Player.playerExperiencePoints = 0;
            Player.playerSkillPoints = 0;
            Player.playerLevel = 0;
            Player.playerGold = 0;
            Player.playerDamage = 10;
            Player.playerMiss = 10;

            Characteristics.strength = 10;
            Characteristics.agility = 10;
            Characteristics.intelligence = 10;
        }
    }
}
