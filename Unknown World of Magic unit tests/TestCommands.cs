using NUnit.Framework;

namespace Unknown_World_of_Magic_server
{
    public class TestCommands
    { 

        [Test]
        public void TestSetLocation()
        {
            Client client = new Client();

            Client.command = "SetInitialLocation";
            client.ExecutingCommand();

            Assert.AreEqual(Location.locationName, "Glade");
            Assert.AreEqual(Enemy.enemyClass, "Bandit");
        }

        [Test]
        public void TestSetCharacteristics()
        {
            Client client = new Client();

            Client.command = "IncreaseStrength";
            Player.playerSkillPoints = 2;
            client.ExecutingCommand();

            Assert.AreEqual(Characteristics.strength, 1);
            Assert.AreEqual(Player.playerSkillPoints, 1);
        }
    }
}
