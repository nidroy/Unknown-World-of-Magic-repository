using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Enemy
    {
        public static string enemyName { get; set; } // класс врага
        public static int enemyHealthPoints { get; set; } // очки здоровья врага
        public static int enemyExperiencePoints { get; set; } // очки опыта врага
        public static int enemyLevel { get; set; } // уровень врага
        public static int enemyGold { get; set; } // золото врага
        public static int enemyDamage { get; set; } // урон врага
        public static int enemyMiss { get; set; } // промах врага

        // атака
        public string Attack()
        {
            Random random = new Random();
            if (random.Next(0, 100) < 100 - enemyMiss)
            {
                Player.playerHealthPoints -= random.Next(enemyDamage, enemyDamage + random.Next(5, 16));
            }
            return Player.playerHealthPoints.ToString();
        }
    }
}
