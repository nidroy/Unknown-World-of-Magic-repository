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
        public void SetNextLocation()
        { 
            locationNumber++;
            ChooseLocation();
            GetEnemyAttributes();
        }

        // установить предыдущую локацию
        public void SetPreviousLocation()
        {
            locationNumber--;
            ChooseLocation();
            GetEnemyAttributes();
        }

        // установить начальную локацию
        public void SetInitialLocation()
        {
            locationNumber = 0;
            ChooseLocation();
            GetEnemyAttributes();
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
            IGetAttributes Bandit = new Bandit();
            IGetAttributes Leshii = new Leshii();

            Bandit.GetCharacterAttributes();
            Leshii.GetCharacterAttributes();
        }
    }
}
