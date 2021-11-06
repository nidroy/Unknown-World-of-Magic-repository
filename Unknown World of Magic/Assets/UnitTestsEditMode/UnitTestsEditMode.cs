using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitTestsEditMode
{
    [Test]
    public void TestMaximumHP()
    {
        Player player = new Player();
        Characteristics characteristics = new Characteristics();
        Equipment equipment = new Equipment();

        equipment.SetMaximumHP(20);
        equipment.SetMaximumHP(20);
        player.SetMaximumHPCharacter(200 + characteristics.SetMaximumHPStrength() + equipment.equipmentMaximumHP);

        Assert.AreEqual(player.maximumCharacterHP, 250);
    }

    [Test]
    public void TestBuy()
    {
        Trading trading = new Trading();
        Player player = new Player();

        player.SetGoldCharacter(100);
        player.SetGoldCharacter(150);
        trading.SetPriceItem(200);
        player.SetGoldCharacter(-1 * trading.itemPrice);

        Assert.AreEqual(player.characterGold, 50);
    }

    [Test]
    public void TestDamageEnemy()
    {
        Player player = new Player();
        NPC enemy = new NPC();

        enemy.SetHPCharacter(200);
        player.ChangeDamageCharacter(100);
        enemy.TakeDamage(player.characterDamage);

        Assert.AreEqual(enemy.characterHP, 200 - player.characterDamage);
    }
}
