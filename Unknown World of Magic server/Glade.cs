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
                locationDescription = "The green glade is located near the gate to the city. A gang of robbers is located in the clearing, robbing merchants who are going to the city.";
            }
        }
    }
}
