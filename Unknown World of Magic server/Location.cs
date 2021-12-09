using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Location
    {
        public static int locationNumber { get; set; } // номер локации
        public static string locationName { get; set; } // название локации
        public static string locationDescription { get; set; } // описание локации

        // установить следующую локацию
        public string SetNextLocation()
        {
            if (Client.command[0] == "SetNextLocation")
            {
                locationNumber++;
                ChooseLocation();
                GetEnemyAttributes();
            }
            return locationName + "_" + locationDescription + "_" + Enemy.enemyClass + "_" + Enemy.enemyHealthPoints.ToString() + "_" + Enemy.enemyLevel.ToString();
        }

        // установить предыдущую локацию
        public string SetPreviousLocation()
        {
            if (Client.command[0] == "SetPreviousLocation")
            {
                locationNumber--;
                ChooseLocation();
                GetEnemyAttributes();
            }
            return locationName + "_" + locationDescription + "_" + Enemy.enemyClass + "_" + Enemy.enemyHealthPoints.ToString() + "_" + Enemy.enemyLevel.ToString();
        }

        // установить начальную локацию
        public string SetInitialLocation()
        {
            if (Client.command[0] == "SetInitialLocation")
            {
                locationNumber = 0;
                ChooseLocation();
                GetEnemyAttributes();
            }
            return locationName + "_" + locationDescription + "_" + Enemy.enemyClass + "_" + Enemy.enemyHealthPoints.ToString() + "_" + Enemy.enemyLevel.ToString();
        }

        // выбрать локацию
        private void ChooseLocation()
        {
            Glade glade = new Glade();
            Forest forest = new Forest();

            glade.ChooseGladeLocation();
            forest.ChooseForestLocation();
        }
        
        // получить атрибуты врага
        private void GetEnemyAttributes()
        {
            Bandit.GetBanditAttributes();
            Leshii.GetLeshiiAttributes();
        }
    }
}
