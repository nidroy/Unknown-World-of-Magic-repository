using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Bandit : IGetAttributes
    {
        // получить атрибуты разбойника
        public void GetCharacterAttributes()
        {
            if (Location.locationNumber == 0)
            {
                Enemy.enemyClass = "Bandit";
                Enemy.enemyHealthPoints = 50;
                Enemy.enemyExperiencePoints = 20;
                Enemy.enemyLevel = 1;
                Enemy.enemyGold = 20;
                Enemy.enemyDamage = 8;
                Enemy.enemyMiss = 20;
            }
        }
    }
}
