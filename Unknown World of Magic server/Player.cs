using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Player
    {
        public static string namePlayer; // имя игрока
        public static int numberClassPlayer; // номер класса игрока
        public static int healthPoints; // очки здоровья
        public static int actionPoints; // очки действий
        public static int skillPoints; // очки навыков
        public static int experiencePoints; // очки опыта
        public static int playerLevel; // уровень игрока
        public static int playerGold; // золото игрока
        public static int playerDamage; // урон игрока

        // установить очки здоровья
        public void SetHealthPoints(int HP)
        {
            healthPoints = HP;
        }

        // установить очки действий
        public void SetActionPoints(int AP)
        {
            actionPoints = AP;
        }

        // установить очки навыков
        public void SetSkillPoints(int SP)
        {
            skillPoints = SP;
        }

        // установить очки опыта
        public void SetExperiencePoints(int XP)
        {
            experiencePoints = XP;
        }

        // установить уровень игрока
        public void SetPlayerLevel(int level)
        {
            playerLevel = level;
        }

        // установить золото игрока
        public void SetPlayerGold(int gold)
        {
            playerGold = gold;
        }

        // установить урон игрока
        public void SetPlayerDamage(int damage)
        {
            Random random = new Random();
            playerDamage = random.Next(damage, 11 + damage);
        }
    }
}
