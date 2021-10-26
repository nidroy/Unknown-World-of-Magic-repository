using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public string characterClass; // ����� ���������
    public int maximumCharacterXP = 100; // ������������ XP ���������
    public Image characterXPImage; // ����� XP ���������
    public NPC npc; // ��������� ��������
    public bool isDodgeCharacter; // �������� �� ��������� ���������
    public bool isDodgingBlow; // �������� �� ���������� �� ����� �����
    public Menu menu; // ����
    public bool isSecondLife = true; // ������ ����� ���������

    private void Update()
    {
        SetMaximumHPCharacter(100 + characteristics.SetMaximumHPStrength() + skills.SetMaximumHPSkills());
        RegenerationHP(Time.deltaTime * characteristics.SetRegenerationHP() * skills.SetRegenerationHP());
        LoweringHP();
        IncreaseLineXP();
        IncreaseLevelCharacter();
        ChangeDamageCharacter(characteristics.SetDamageCharacteristic(characterClass) + skills.SetDamageSkills());
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

    #region Class

    // ���������� ����� ���������
    public void SetClassCharacter(int numberClass)
    {
        if(numberClass == 0)
        {
            characterClass = "Archer";
        }
        else if(numberClass == 1)
        {
            characterClass = "Warrior";
        }
        else if(numberClass == 2)
        {
            characterClass = "Magician";
        }

        SetHPCharacter(maximumCharacterHP);
        characterHPImage.fillAmount = 1;
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
            SetMissCharacter(50 - characteristics.miss - skills.SetMissSkills());
        }
        if (isFight && seconds <= Random.Range(1, 8) && Random.Range(0, 100) < 100 - characterMiss)
        {
            TakeDamage(npc.characterDamage);
            isFight = false;
        }
    }

    // �������� ���� ���������
    public void ChangeDamageCharacter(int damage)
    {
        SetDamageCharacter(20 + damage, 60 + damage);
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
            if (isSecondLife && skills.isSecondLife)
            {
                SetHPCharacter(maximumCharacterHP / 2);
                characterHPImage.fillAmount = 0.5f;
                isSecondLife = false;
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    #endregion

    #region Battle

    // ����� ��������� � ���� ���
    public void EscapeBattleCharacter()
    {
        if(menu.clock.activeSelf)
        {
            clock.StopTimer();
            StartEndBattle(false);
            npc.StartEndBattle(false);
        }
    }

    #endregion

    #region Life

    // ���������� ������ ����� ���������
    public void SetSecondLifeCharacter()
    {
        isSecondLife = true;
    }

    #endregion
}
