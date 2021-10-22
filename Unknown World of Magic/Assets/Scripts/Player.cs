using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public int maximumCharacterXP = 100; // ������������ XP ���������
    public Image characterXPImage; // ����� XP ���������
    public NPC npc; // ��������� ��������
    public Clock clock; // ����
    public bool isDodgeCharacter; // �������� �� ��������� ���������
    public bool isDodgingBlow; // �������� �� ���������� �� ����� �����

    private void Update()
    {
        RegenerationHP(Time.deltaTime);
        LoweringHP();
        IncreaseLineXP();
        IncreaseLevelCharacter();
        SetDamageCharacter(20, 60);
        TakeDamageEnemy(clock.seconds);
        DeathCharacter();
        SetFrameCharacter();
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

    // ���������� XP ���������
    public void SetXPCharacter(int XP)
    {
        characterXP += XP;
    }    

    // ��������� ����� XP
    public void IncreaseLineXP()
    {
        if(characterXPImage.fillAmount < characterXP/maximumCharacterXP)
        {
            characterXPImage.fillAmount += Time.deltaTime;
        }
    }

    #endregion

    #region Level

    // �������� ������� ���������
    public void IncreaseLevelCharacter()
    {
        if(characterXPImage.fillAmount == 1)
        {
            SetXPCharacter((int)characterXP - maximumCharacterXP);
            maximumCharacterXP *= 2;
            characterXPImage.fillAmount = 0;
            SetLevelCharacter(characterLevel + 1);
        }
    }

    #endregion

    #region Damage

    // �������� ���� �� �����
    public void TakeDamageEnemy(float seconds)
    {
        SetMissCharacter(10);
        if(isDodgingBlow)
        {
            SetMissCharacter(50);
        }
        if (isFight && seconds <= Random.Range(1, 8) && Random.Range(0, 100) < 100 - characterMiss)
        {
            TakeDamage(npc.characterDamage);
            isFight = false;
        }
    }

    #endregion

    #region Dodge

    // ���������� �� ����� �����
    public void DodgeBlow()
    {
        if(isDodgeCharacter)
        {
            SetDodgeBlow(true);
            SetDodge(false);
            npc.StartEndBattle(false);
        }
    }

    // ���������� ����������� ��������� ������������� 
    public void SetDodge(bool isDodge)
    {
        isDodgeCharacter = isDodge;
    }

    // ���������� ����������� ���������� �� �����
    public void SetDodgeBlow(bool isDodge)
    {
        isDodgingBlow = isDodge;
    }

    #endregion

    #region Death

    // ������ ���������
    public override void DeathCharacter()
    {
        if (characterHPImage.fillAmount == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    #endregion
}
