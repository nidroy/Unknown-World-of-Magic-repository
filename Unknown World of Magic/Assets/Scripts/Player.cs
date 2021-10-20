using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public int maximumCharacterXP = 100; // ������������ XP ���������
    public float characterXP = 0; // XP ���������
    public Image characterXPImage; // ����� XP ���������
    public NPC npc; // ��������� ��������

    private void Update()
    {
        RegenerationHP(Time.deltaTime);
        LoweringHP();
        IncreaseLineXP();
        IncreaseXP();
        SetDamageCharacter(5, 10);
    }

    #region Name

    // �������� ��� ���������
    public void GetNameCharacter(Text nameText)
    {
        if (nameText.text == "")
        {
            SetNameCharacter("Player name");
        }
        else
        {
            SetNameCharacter(nameText.text);
        }
    }

    #endregion

    #region XP

    // �������� XP
    public void GetXP(int XP)
    {
        characterXP = XP;
    }    

    // ��������� ����� XP
    public void IncreaseLineXP()
    {
        if(characterXPImage.fillAmount < characterXP/maximumCharacterXP)
        {
            characterXPImage.fillAmount += Time.deltaTime;
        }
    }

    // �������� XP ���������
    public void IncreaseXP()
    {
        if(characterXPImage.fillAmount == 1)
        {
            maximumCharacterXP *= 2;
            characterXPImage.fillAmount = 0;
            SetLevelCharacter(characterLevel + 1);
        }
    }

    #endregion

    #region Damage

    // �������� ���� �� �����
    public void TakeDamageEnemy()
    {
        TakeDamage(npc.characterDamage);
    }

    #endregion
}
