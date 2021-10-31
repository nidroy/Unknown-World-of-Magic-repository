using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Character
{
    public Sprite[] characterClassSprite; // поля ввода классов персонажа
    public Player player; // игрок
    public bool isTrades; // NPC занимается торговлей
    public bool isGivesTasks; // NPC выдает задания
    public int[] numberKilledNPC; // количество убитых NPC

    private void Update()
    {
        SetNPC();
        LoweringHP();
        SetFrameCharacter();
        DeathCharacter();
    }

    #region Class

    // установить класс персонажа в виде Image
    public Image SetClassCharacter(Sprite classSprite)
    {
        Image classImage = characterClassImage;
        classImage.sprite = classSprite;
        return classImage;
    }

    #endregion

    #region HP

    // установить HP NPC
    public void SetHPNPC()
    {
        if(location.locationNumber == 0)
        {
            SetHPCharacter(1000);
        }
        else if(location.locationNumber == 1)
        {
            SetHPCharacter(100);
        }
        else if(location.locationNumber == 2)
        {
            SetHPCharacter(200);
        }
        characterHPImage.fillAmount = 1;
    }

    #endregion

    #region XP

    // установить XP персонажа
    public override void SetXPCharacter(int XP)
    {
        characterXP = XP;
    }

    #endregion

    #region Damage

    // получить урон от игрока
    public void TakeDamagePlayer()
    {
        SetMissCharacter(30 - characteristics.miss);
        if (isFight && Random.Range(0, 100) < 100 - characterMiss)
        {
            TakeDamage(player.characterDamage);
        }
        if (isFight && skills.isDoubleAttack)
        {
            TakeDamage(player.characterDamage);
        }
        if (isFight && skills.isTripleAttack)
        {
            if (Random.Range(0, 100) < 100 - characterMiss)
            {
                TakeDamage(player.characterDamage);
            }
            if (Random.Range(0, 100) < 100 - characterMiss)
            {
                TakeDamage(player.characterDamage);
            }
        }
        isFight = false;
        player.SetDodge(false);
    }

    #endregion

    #region SetNPC

    // установить NPC
    public void SetNPC()
    {
        if (location.locationNumber == 0)
        {
            GuildHead();
        }
        else if (location.locationNumber == 1)
        {
            Outlaw();
        }
        else if (location.locationNumber == 2)
        {
            Leshii();
        }
    }

    #endregion

    #region NPC

    // глава гильдии
    public void GuildHead()
    {
        SetNameCharacter("Глава гильдии");
        SetGenderCharacter("Мужчина");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[0]));
        SetLevelCharacter(100);
        SetMaximumHPCharacter(1000);
        RegenerationHP(Time.deltaTime * 100);
        SetDamageCharacter(1000, 1200);
        SetXPCharacter(1000);
        SetGoldCharacter(10000);
    }

    // разбойник
    public void Outlaw()
    {
        SetNameCharacter("Разбойник");
        SetGenderCharacter("Женщина");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[1]));
        SetLevelCharacter(2);
        SetMaximumHPCharacter(100);
        RegenerationHP(Time.deltaTime * 2);
        SetDamageCharacter(20, 40);
        SetXPCharacter(20);
        SetGoldCharacter(10);
    }

    // леший
    public void Leshii()
    {
        SetNameCharacter("Леший");
        SetGenderCharacter("Мужчина");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[2]));
        SetLevelCharacter(10);
        SetMaximumHPCharacter(200);
        RegenerationHP(Time.deltaTime * 4);
        SetDamageCharacter(60, 100);
        SetXPCharacter(50);
        SetGoldCharacter(0);
    }

    #endregion

    #region Death

    // смерть персонажа
    public override void DeathCharacter()
    {
        if(characterHPImage.fillAmount == 0)
        {
            player.SetXPCharacter((int)characterXP);
            player.SetGoldCharacter(characterGold + skills.SetGoldSkills() + equipment.equipmentGold);
            characterHP = maximumCharacterHP;
            characterHPImage.fillAmount = 1;
            clock.StopTimer();
            characteristics.RaisePointsCharacteristic(0);
            location.SetTextLocation();
            IncreaseNumberKilledNPC(location.locationNumber);
        }
    }

    // установить количество убитых NPC на локации
    public void SetNumberKilledNPC(int number)
    {
        for (int i = 0; i < 3; i++)
        {
            numberKilledNPC[i] = number;
        }
    }

    // увеличить количество убитых NPC на локации
    private void IncreaseNumberKilledNPC(int locationNumber)
    {
        numberKilledNPC[locationNumber] ++;
    }

    #endregion

    #region Gold

    // установить количество золота персонажа
    public override void SetGoldCharacter(int gold)
    {
        characterGold = gold;
    }

    #endregion

    #region Tasks

    // установить возможность выдачи задания
    public void SetGivesTasks(bool isGiveTask)
    {
        if(location.locationNumber == 0)
        {
            isGivesTasks = isGiveTask;
        }
        else
        {
            isGivesTasks = false;
        }
    }

    #endregion

    #region Trading

    // установить возможность торговли с персонажем
    public void SetTrades(bool isTrading)
    {
        if(!isGivesTasks && location.locationNumber == 0)
        {
            isTrades = isTrading;
        }
    }

    #endregion
}
