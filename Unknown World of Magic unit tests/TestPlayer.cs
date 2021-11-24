using NUnit.Framework;

namespace Unknown_World_of_Magic_server
{
    public class TestPlayer
    {
        [Test]
        public void TestSetHealthPoints()
        {
            Player player = new Player();

            player.SetHealthPoints(100);

            Assert.AreEqual(Player.healthPoints, 100);
        }

        [Test]
        public void TestSetActionPoints()
        {
            Player player = new Player();

            player.SetActionPoints(100);

            Assert.AreEqual(Player.actionPoints, 100);
        }

        [Test]
        public void TestSetSkillPoints()
        {
            Player player = new Player();

            player.SetSkillPoints(10);

            Assert.AreEqual(Player.skillPoints, 10);
        }

        [Test]
        public void TestSetExperiencePoints()
        {
            Player player = new Player();

            player.SetExperiencePoints(1);

            Assert.AreEqual(Player.experiencePoints, 1);
        }

        [Test]
        public void TestSetPlayerLevel()
        {
            Player player = new Player();

            player.SetPlayerLevel(1);

            Assert.AreEqual(Player.playerLevel, 1);
        }

        [Test]
        public void TestSetPlayerGold()
        {
            Player player = new Player();

            player.SetPlayerGold(20);

            Assert.AreEqual(Player.playerGold, 20);
        }
    }
}
