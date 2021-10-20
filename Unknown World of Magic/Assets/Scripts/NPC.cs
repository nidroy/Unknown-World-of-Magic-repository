using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Character
{
    public Sprite[] characterClassSprite; // ���� ����� ������� ���������
    public Location location; // �������
    public Player player;

    private void Update()
    {
        if(location.locationNumber == 0)
        {
            GuildHead();
        }
        else if(location.locationNumber == 1)
        {
            Outlaw();
        }
        else if(location.locationNumber == 2)
        {
            Leshii();
        }

        LoweringHP();
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
        TakeDamage(player.characterDamage);
    }

    #endregion

    // ����� �������
    public void GuildHead()
    {
        SetNameCharacter("����� �������");
        SetGenderCharacter("�������");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[0]));
        SetLevelCharacter(100);
        maximumCharacterHP = 1000;
        RegenerationHP(Time.deltaTime * 100);
        SetDamageCharacter(800, 1000);
    }

    // ���������
    public void Outlaw()
    {
        SetNameCharacter("���������");
        SetGenderCharacter("�������");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[1]));
        SetLevelCharacter(5);
        maximumCharacterHP = 100;
        RegenerationHP(Time.deltaTime * 2);
        SetDamageCharacter(5, 10);
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
        SetDamageCharacter(10, 20);
    }
}
