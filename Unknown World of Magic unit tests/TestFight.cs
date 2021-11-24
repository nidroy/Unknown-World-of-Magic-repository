using NUnit.Framework;

namespace Unknown_World_of_Magic_server
{
    public class TestFight
    {
        [Test]
        public void TestSetStartFight()
        {
            Fight fight = new Fight();

            fight.SetStartFight();

            Assert.AreEqual(ManagingCommands.isFight, true);
        }

        [Test]
        public void TestSetFinishFight()
        {
            Fight fight = new Fight();

            fight.SetFinishFight();

            Assert.AreEqual(ManagingCommands.isFight, false);
        }

        [Test]
        public void TestAttackPlayer()
        {
            Fight fight = new Fight();
            NPC npc = new NPC();

            npc.SetHealthPoints(100);
            fight.AttackPlayer(10);

            Assert.AreEqual(NPC.healthPoints, 90);
        }

        [Test]
        public void TestAttackNPC()
        {
            Fight fight = new Fight();
            Player player = new Player();

            player.SetHealthPoints(100);
            fight.AttackNPC(20);

            Assert.AreEqual(Player.healthPoints, 80);
        }

    }
}
