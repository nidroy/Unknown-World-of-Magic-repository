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
            locationNumber++;
            ChooseLocation();
            GetEnemyAttributes();
            return String.Format("{0}_{1}_{2}_{3}_{4}", locationName, locationDescription, Enemy.enemyName, Enemy.enemyHealthPoints, Enemy.enemyLevel);
        }

        // установить предыдущую локацию
        public string SetPreviousLocation()
        {
            locationNumber--;
            ChooseLocation();
            GetEnemyAttributes();
            return String.Format("{0}_{1}_{2}_{3}_{4}", locationName, locationDescription, Enemy.enemyName, Enemy.enemyHealthPoints, Enemy.enemyLevel);
        }

        // установить начальную локацию
        public string SetInitialLocation()
        {
            locationNumber = 0;
            ChooseLocation();
            GetEnemyAttributes();
            return String.Format("{0}_{1}_{2}_{3}_{4}", locationName, locationDescription, Enemy.enemyName, Enemy.enemyHealthPoints, Enemy.enemyLevel);
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
