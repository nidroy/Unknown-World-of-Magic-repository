using NUnit.Framework;

namespace Unknown_World_of_Magic_server
{
    public class TestNPC
    {
        [Test]
        public void TestSetNPCName()
        {
            NPC npc = new NPC();

            npc.SetNPCName(Locations.locationNumber);

            Assert.AreEqual(NPC.nameNPC, "Bandit");
        }

        [Test]
        public void TestSetHealthPoints()
        {
            NPC npc = new NPC();

            npc.SetHealthPoints(100);

            Assert.AreEqual(NPC.healthPoints, 100);
        }

        [Test]
        public void TestSetNPCLevel()
        {
            NPC npc = new NPC();

            npc.SetNPCLevel(Locations.locationNumber);

            Assert.AreEqual(NPC.NPCLevel, 1);
        }

        [Test]
        public void TestSetExperiencePoints()
        {
            NPC npc = new NPC();

            npc.SetExperiencePoints(Locations.locationNumber);

            Assert.AreEqual(NPC.experiencePoints, 20);
        }

        [Test]
        public void TestSetNPCGold()
        {
            NPC npc = new NPC();

            npc.SetNPCGold(Locations.locationNumber);

            Assert.AreEqual(NPC.NPCGold, 50);
        }
    }
}
