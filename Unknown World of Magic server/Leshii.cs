using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Leshii : Enemy
    {
        // получить атрибуты лешего
        public static string GetLeshiiAttributes()
        {
            if (Location.locationNumber == 1)
            {
                enemyName = "Leshii";
                enemyHealthPoints = 200;
                enemyExperiencePoints = 50;
                enemyLevel = 10;
                enemyGold = 100;
                enemyDamage = 12;
                enemyMiss = 10;
            }
            return String.Format("{0}_{1}_{2}", enemyName, enemyHealthPoints, enemyLevel);
        }
    }
}
