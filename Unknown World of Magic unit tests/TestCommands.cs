using NUnit.Framework;
using System;

namespace Unknown_World_of_Magic_server
{
    public class TestCommands
    { 
        [Test]
        public void TestCreatePlayer()
        {
            Player player = new Player();

            player.SetPlayerName("Gamer");
            Assassin.GetAssassinAttributes();

            Assert.AreEqual(Player.playerName, "Gamer");
            Assert.AreEqual(Player.playerClass, "Assassin");
            Assert.AreEqual(Player.playerHealthPoints, 100);
            Assert.AreEqual(Player.playerActionPoints, 100);
            Assert.AreEqual(Player.playerDamage, 10);
            Assert.AreEqual(Characteristics.strength, 10);
            Assert.AreEqual(Characteristics.agility, 10);
            Assert.AreEqual(Characteristics.intelligence, 10);
        }

        [Test]
        public void TestIncreaseLevel()
        {
            Player player = new Player();
            Characteristics characteristics = new Characteristics();

            for(int i = 0; i < 3; i++)
                player.IncreaseLevel();
            characteristics.IncreaseStrength();
            characteristics.IncreaseIntelligence();
            characteristics.IncreaseIntelligence();

            Assert.AreEqual(Player.playerSkillPoints, 3);
            Assert.AreEqual(Player.playerHealthPoints, 110);
            Assert.AreEqual(Player.playerActionPoints, 120);
            Assert.AreEqual(Player.playerDamage, 13);
            Assert.AreEqual(Characteristics.strength, 11);
            Assert.AreEqual(Characteristics.agility, 13);
            Assert.AreEqual(Characteristics.intelligence, 12);
        }       

        [Test]
        public void TestCreateEnemy()
        {
            Bandit.GetBanditAttributes();

            Assert.AreEqual(Enemy.enemyName, "Bandit");
            Assert.AreEqual(Enemy.enemyHealthPoints, 50);
            Assert.AreEqual(Enemy.enemyDamage, 8);
        }

        [Test]
        public void TestFight()
        {
            Player player = new Player();
            Enemy enemy = new Enemy();

            Assassin.GetAssassinAttributes();
            Bandit.GetBanditAttributes();
            player.Attack();
            enemy.Attack();

            Assert.AreEqual(Player.playerHealthPoints, 108 - Enemy.enemyDamage);
            Assert.AreEqual(Player.playerActionPoints, 100 - Player.playerDamage);
        }

        [Test]
        public void TestTransitionLocation()
        {
            Location location = new Location();

            location.SetInitialLocation();

            Assert.AreEqual(Location.locationNumber, 0);

            location.SetNextLocation();

            Assert.AreEqual(Location.locationName, "Forest");

            location.SetPreviousLocation();

            Assert.AreEqual(Location.locationName, "Glade");
        }
    }
}
