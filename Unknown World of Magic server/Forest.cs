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
                locationDescription = "Густой и тёмный лес, из кустов которого доносятся звериные вопли. Эта чаща принадлежит Лешим. Они следят за порядком в лесу и не любят чужаков из города.";
                Client.command[0] = "GetLeshiiAttributes";
            }
        }
    }
}
