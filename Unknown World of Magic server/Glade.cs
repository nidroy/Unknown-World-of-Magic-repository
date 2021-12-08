using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Glade : Location
    {
        // выбрать локацию поляна
        public void ChooseGladeLocation()
        {
            if(locationNumber == 0)
            {
                locationName = "Glade";
                locationDescription = "Зелёная поляна расположена недалеко от ворот в город. На поляне расположилась банда разбойников, обкрадывающая торговцев, которые идут в город.";
            }
        }
    }
}
