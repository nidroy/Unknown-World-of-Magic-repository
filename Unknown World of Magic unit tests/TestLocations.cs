using NUnit.Framework;

namespace Unknown_World_of_Magic_server
{
    public class TestLocations
    {
        [Test]
        public void TestSetNextLocation()
        {
            Locations locations = new Locations();

            locations.SetNextLocation();

            Assert.AreEqual(Locations.locationNumber, 1);
        }

        [Test]
        public void TestSetPreviousLocation()
        {
            Locations locations = new Locations();

            locations.SetPreviousLocation();

            Assert.AreEqual(Locations.locationNumber, -1);
        }

        [Test]
        public void TestGetNameLocation()
        {
            Locations locations = new Locations();

            locations.SetNextLocation();

            Assert.AreEqual(locations.GetNameLocation(), "Forest");
        }

        [Test]
        public void TestGetTextLocation()
        {
            Locations locations = new Locations();

            locations.SetNextLocation();

            Assert.AreEqual(locations.GetTextLocation(), "Густой и тёмный лес, из кустов которого доносятся звериные вопли. Эта чаща принадлежит Лешим. Они следят за порядком в лесу и не любят чужаков из города.");
        }

    }
}
