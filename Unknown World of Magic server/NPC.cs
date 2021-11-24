using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class NPC
    {
        public static string nameNPC; // название NPC
        public static int healthPoints; // очки здоровья
        public static int NPCLevel; // уровень NPC
        public static int experiencePoints; // очки опыта
        public static int NPCGold; // золото NPC
        public static int NPCDamage; // урон NPC

        #region SetNPCAttributes

        // установить имя NPC
        public void SetNPCName(int numberNPC)
        {
            nameNPC = GetNPCName(numberNPC);
        }
        
        // установить очки здоровья
        public void SetHealthPoints(int HP)
        {
            healthPoints = HP;
        }

        // установить уровень NPC
        public void SetNPCLevel(int numberNPC)
        {
            NPCLevel = GetNPCLevel(numberNPC);
        }

        // установить очки опыта
        public void SetExperiencePoints(int numberNPC)
        {
            experiencePoints = GetExperiencePoints(numberNPC);
        }

        // установить золото NPC
        public void SetNPCGold(int numberNPC)
        {
            NPCGold = GetNPCGold(numberNPC);
        }

        // установить урон NPC
        public void SetNPCDamage(int numberNPC)
        {
            NPCDamage = GetNPCDamage(numberNPC);
        }

        #endregion

        #region  GetNPCAttributes

        // получить имя NPC
        private string GetNPCName(int numberNPC)
        {
            if(numberNPC == 0)
            {
                return "Bandit";
            }
            else if(numberNPC == 1)
            {
                return "Leshii";
            }
            return "";
        }

        // получить уровень NPC
        private int GetNPCLevel(int numberNPC)
        {
            if(numberNPC == 0)
            {
                return 1;
            }
            else if(numberNPC == 1)
            {
                return 10;
            }
            return 0;
        }

        // получить очки опыта
        private int GetExperiencePoints(int numberNPC)
        {
            if(numberNPC == 0)
            {
                return 20;
            }
            else if(numberNPC == 1)
            {
                return 100;
            }
            return 0;
        }

        // получить золото NPC
        private int GetNPCGold(int numberNPC)
        {
            if(numberNPC == 0)
            {
                return 50;
            }
            else if(numberNPC == 1)
            {
                return 250;
            }
            return 0;
        }

        // получить урон NPC
        private int GetNPCDamage(int numberNPC)
        {
            Random random = new Random();

            if(numberNPC == 0)
            {
                return random.Next(0, 11);
            }
            else if(numberNPC == 1)
            {
                return random.Next(40, 51);
            }
            return 0;
        }

        #endregion

    }
}
