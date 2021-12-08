using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Leshii : IGetAttributes
    {
        // получить атрибуты лешего
        public void GetCharacterAttributes()
        {
            if (Location.locationNumber == 1)
            {
                Enemy.enemyClass = "Leshii";
                Enemy.enemyHealthPoints = 200;
                Enemy.enemyExperiencePoints = 50;
                Enemy.enemyLevel = 10;
                Enemy.enemyGold = 100;
                Enemy.enemyDamage = 12;
                Enemy.enemyMiss = 10;
            }
        }
    }
}
