using NUnit.Framework;

namespace Unknown_World_of_Magic_server
{
    public class TestManagingCommands
    {
        [Test]
        public void Test1PlayerCreationCommandSetClassPlayer()
        {
            ManagingCommands managingCommands = new ManagingCommands();

            managingCommands.PlayerCreationCommands("SetClassPlayer");
            managingCommands.PlayerCreationCommands("0");

            Assert.AreEqual(CreatingPlayer.numberClassPlayer, 0);
        }

        [Test]
        public void Test2PlayerCreationCommandSetClassPlayer()
        {
            ManagingCommands managingCommands = new ManagingCommands();

            managingCommands.PlayerCreationCommands("SetClassPlayer");
            managingCommands.PlayerCreationCommands("1");

            Assert.AreEqual(CreatingPlayer.numberClassPlayer, 1);
        }

        [Test]
        public void TestPlayerCreationCommandSetPlayerName()
        {
            ManagingCommands managingCommands = new ManagingCommands();

            managingCommands.PlayerCreationCommands("SetPlayerName");
            managingCommands.PlayerCreationCommands("Иван Иванов");

            Assert.AreEqual(CreatingPlayer.namePlayer, "Иван Иванов");
        }
    }
}
