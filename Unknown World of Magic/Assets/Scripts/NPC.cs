using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Character
{
    public Sprite[] characterClassSprite; // ���� ����� ������� ���������
    public Player player; // �����
    public Clock clock; // ����

    private void Update()
    {
        SetNPC();
        LoweringHP();
        DeathCharacter();
    }

    #region Class

    // ���������� ����� ��������� � ���� Image
    public Image SetClassCharacter(Sprite classSprite)
    {
        Image classImage = characterClassImage;
        classImage.sprite = classSprite;
        return classImage;
    }

    #endregion

    #region HP

    // ���������� HP NPC
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

    #region Damage

    // �������� ���� �� ������
    public void TakeDamagePlayer()
    {
        SetMissCharacter(30);
        if (isFight && Random.Range(0, 100) < 100 - characterMiss)
        {
            TakeDamage(player.characterDamage);
        }
        isFight = false;
        player.SetDodge(false);
    }

    #endregion

    #region SetNPC

    // ���������� NPC
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

    // ����� �������
    public void GuildHead()
    {
        SetNameCharacter("����� �������");
        SetGenderCharacter("�������");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[0]));
        SetLevelCharacter(100);
        maximumCharacterHP = 1000;
        RegenerationHP(Time.deltaTime * 100);
        SetDamageCharacter(1000, 1200);
        characterXP = 1000;
    }

    // ���������
    public void Outlaw()
    {
        SetNameCharacter("���������");
        SetGenderCharacter("�������");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[1]));
        SetLevelCharacter(2);
        maximumCharacterHP = 100;
        RegenerationHP(Time.deltaTime * 2);
        SetDamageCharacter(20, 40);
        characterXP = 20;
    }

    // �����
    public void Leshii()
    {
        SetNameCharacter("�����");
        SetGenderCharacter("�������");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[2]));
        SetLevelCharacter(10);
        maximumCharacterHP = 200;
        RegenerationHP(Time.deltaTime * 4);
        SetDamageCharacter(60, 100);
        characterXP = 100;
    }

    #endregion

    #region Death

    // ������ ���������
    public override void DeathCharacter()
    {
        if(characterHPImage.fillAmount == 0)
        {
            player.SetXPCharacter((int)characterXP);
            characterHP = maximumCharacterHP;
            characterHPImage.fillAmount = 1;
            clock.isStop = true;
        }
    }

    #endregion
}
