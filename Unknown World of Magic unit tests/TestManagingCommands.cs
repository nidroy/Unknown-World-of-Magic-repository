using NUnit.Framework;

namespace Unknown_World_of_Magic_server
{
    public class TestManagingCommands
    {
        [Test]
        public void Test1PlayerCreationCommandSetClassPlayer()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.PlayerCreationCommands("SetClassPlayer");
            commands.PlayerCreationCommands("0");

            Assert.AreEqual(Player.numberClassPlayer, 0);
        }

        [Test]
        public void Test2PlayerCreationCommandSetClassPlayer()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.PlayerCreationCommands("SetClassPlayer");
            commands.PlayerCreationCommands("1");

            Assert.AreEqual(Player.numberClassPlayer, 1);
        }

        [Test]
        public void TestPlayerCreationCommandSetPlayerName()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.PlayerCreationCommands("SetPlayerName");
            commands.PlayerCreationCommands("Иван Иванов");

            Assert.AreEqual(Player.namePlayer, "Иван Иванов");
        }

        [Test]
        public void TestGameCommandSetNextLocation()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetNextLocation");

            Assert.AreEqual(ManagingResponses.serverResponse, "1");
        }

        [Test]
        public void TestGameCommandSetPreviousLocation()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetPreviousLocation");

            Assert.AreEqual(ManagingResponses.serverResponse, "-1");
        }

        [Test]
        public void TestGameCommandSetStartFight()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetStartFight");

            Assert.AreEqual(ManagingResponses.serverResponse, "сражение начато");
        }

        [Test]
        public void TestGameCommandSetHealthPoints()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetHealthPoints");
            commands.GameCommands("100");

            Assert.AreEqual(Player.healthPoints, 100);
        }

        [Test]
        public void TestGameCommandSetActionPoints()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetActionPoints");
            commands.GameCommands("100");

            Assert.AreEqual(Player.actionPoints, 100);
        }

        [Test]
        public void TestGameCommandSetStartCreatingPlayer()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetStartCreatingPlayer");

            Assert.AreEqual(ManagingCommands.isCreatingPlayer, true);
        }

        [Test]
        public void TestPlayerCreationCommandSetFinishCreatingPlayer()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.CheckingCommand("SetFinishCreatingPlayer");

            Assert.AreEqual(ManagingCommands.isCreatingPlayer, false);
        }

        [Test]
        public void TestGameCommandSetSkillPoints()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetSkillPoints");
            commands.GameCommands("10");

            Assert.AreEqual(Player.skillPoints, 10);
        }

        [Test]
        public void TestGameCommandSetExperiencePoints()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetExperiencePoints");
            commands.GameCommands("1");

            Assert.AreEqual(Player.experiencePoints, 1);
        }

        [Test]
        public void TestGameCommandSetPlayerLevel()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetPlayerLevel");
            commands.GameCommands("1");

            Assert.AreEqual(Player.playerLevel, 1);
        }

        [Test]
        public void TestGameCommandSetPlayerGold()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetPlayerGold");
            commands.GameCommands("20");

            Assert.AreEqual(Player.playerGold, 20);
        }

        [Test]
        public void TestGameCommandGetNameLocation()
        {
            ManagingCommands commands = new ManagingCommands();
            Locations locations = new Locations();

            commands.GameCommands("GetNameLocation");

            Assert.AreEqual(locations.GetNameLocation(), "Glade");
        }

        [Test]
        public void TestGameCommandGetTextLocation()
        {
            ManagingCommands commands = new ManagingCommands();
            Locations locations = new Locations();

            commands.GameCommands("GetTextLocation");

            Assert.AreEqual(locations.GetTextLocation(), "Зелёная поляна расположена недалеко от ворот в город. На поляне расположилась банда разбойников, обкрадывающая торговцев, которые идут в город.");
        }

        [Test]
        public void TestFightCommandSetFinishFight()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.FightCommands("SetFinishFight");

            Assert.AreEqual(ManagingCommands.isFight, false);
        }

        [Test]
        public void TestGameCommandSetNPCName()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetNPCName");

            Assert.AreEqual(NPC.nameNPC, "Bandit");
        }

        [Test]
        public void TestGameCommandSetNPCHealthPoints()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetNPCHealthPoints");
            commands.GameCommands("150");

            Assert.AreEqual(NPC.healthPoints, 150);
        }

        [Test]
        public void TestGameCommandSetNPCLevel()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetNPCLevel");

            Assert.AreEqual(NPC.NPCLevel, 1);
        }

        [Test]
        public void TestGameCommandSetNPCExperiencePoints()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetNPCExperiencePoints");

            Assert.AreEqual(NPC.experiencePoints, 20);
        }

        [Test]
        public void TestGameCommandSetNPCGold()
        {
            ManagingCommands commands = new ManagingCommands();

            commands.GameCommands("SetNPCGold");

            Assert.AreEqual(NPC.NPCGold, 50);
        }

        [Test]
        public void TestFightCommandAttackPlayer()
        {
            ManagingCommands commands = new ManagingCommands();
            NPC npc = new NPC();

            npc.SetHealthPoints(100);
            commands.FightCommands("AttackPlayer");
            commands.FightCommands("10");

            Assert.AreEqual(NPC.healthPoints, 90);
        }

        [Test]
        public void TestFightCommandAttackNPC()
        {
            ManagingCommands commands = new ManagingCommands();
            Player player = new Player();

            player.SetHealthPoints(100);
            commands.FightCommands("AttackNPC");
            commands.FightCommands("20");

            Assert.AreEqual(Player.healthPoints, 80);
        }
    }
}
