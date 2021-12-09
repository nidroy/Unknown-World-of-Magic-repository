using NUnit.Framework;
using System;

namespace Unknown_World_of_Magic_server
{
    public class TestCommands
    { 

        [Test]
        public void TestSetLocation()
        {
            Dictionary dictionary = new Dictionary();
            dictionary.FillingDictionary();

            Assert.AreEqual(dictionary.dictionary["GetBanditAttributes"], "Bandit_50_1");
            dictionary.OverwritingDictionary("GetBanditAttributes");
            Assert.AreEqual(Enemy.enemyHealthPoints, 50);
        }
    }
}
