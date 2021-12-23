using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class Forest : Location
    {
        // выбрать локацию лес
        public void ChooseForestLocation()
        {
            if (locationNumber == 1)
            {
                locationName = "Forest";
                locationDescription = "A dense and dark forest, from the bushes of which animal screams can be heard. This cup belongs to the Goblins. They keep order in the forest and do not like strangers from the city.";
            }
        }
    }
}
