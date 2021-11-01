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

}
