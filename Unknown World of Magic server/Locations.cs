using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Locations
    {
        public static int locationNumber = 0;

        // установить следующую локацию
        public void SetNextLocation()
        {
            locationNumber++;
        }

        // установить предыдущую локацию
        public void SetPreviousLocation()
        {
            locationNumber--;
        }

        // получить название локации
        public string GetNameLocation()
        {
            if(locationNumber == 0)
            {
                return "Glade";
            }
            else if(locationNumber == 1)
            {
                return "Forest";
            }

            return "";
        }

        // получить текст локации
        public string GetTextLocation()
        {
            if(locationNumber == 0)
            {
                return "Зелёная поляна расположена недалеко от ворот в город. На поляне расположилась банда разбойников, обкрадывающая торговцев, которые идут в город.";
            }
            else if(locationNumber == 1)
            {
                return "Густой и тёмный лес, из кустов которого доносятся звериные вопли. Эта чаща принадлежит Лешим. Они следят за порядком в лесу и не любят чужаков из города.";
            }

            return "";
        }

    }
}
