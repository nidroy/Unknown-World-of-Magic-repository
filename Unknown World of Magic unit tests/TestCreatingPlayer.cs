using NUnit.Framework;

namespace Unknown_World_of_Magic_server
{
    public class TestCreatingPlayer
    {
        [Test]
        public void TestSetNumberClassPlayer()
        {
            CreatingPlayer creatingPlayer = new CreatingPlayer();
            creatingPlayer.SetNumberClassPlayer(1);

            Assert.AreEqual(CreatingPlayer.numberClassPlayer, 1);
        }

        [Test]
        public void TestGetNameAssassinClassPlayer()
        {
            CreatingPlayer creatingPlayer = new CreatingPlayer();
            string nameClassPlayer;

            creatingPlayer.SetNumberClassPlayer(0);
            nameClassPlayer = creatingPlayer.GetNameClassPlayer();

            Assert.AreEqual(nameClassPlayer, "Assassin");
        }

        [Test]
        public void TestGetNameMageClassPlayer()
        {
            CreatingPlayer creatingPlayer = new CreatingPlayer();
            string nameClassPlayer;

            creatingPlayer.SetNumberClassPlayer(1);
            nameClassPlayer = creatingPlayer.GetNameClassPlayer();

            Assert.AreEqual(nameClassPlayer, "Mage");
        }

        [Test]
        public void TestSetPlayerName()
        {
            CreatingPlayer creatingPlayer = new CreatingPlayer();
            creatingPlayer.SetPlayerName("Player name");

            Assert.AreEqual(CreatingPlayer.namePlayer, "Player name");
        }
    }
}