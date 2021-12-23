using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Bandit : Enemy
    {
        // получить атрибуты разбойника
        public static string GetBanditAttributes()
        {
            if (Location.locationNumber == 0)
            {
                enemyName = "Bandit";
                enemyHealthPoints = 50;
                enemyExperiencePoints = 20;
                enemyLevel = 1;
                enemyGold = 20;
                enemyDamage = 8;
                enemyMiss = 20;
            }
            return String.Format("{0}_{1}_{2}", enemyName, enemyHealthPoints, enemyLevel);
        }
    }
}
