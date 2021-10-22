using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public string characterName; // ��� ���������
    public Text characterNameText; // ���� ������ ����� ���������
    public string characterGender; // ��� ���������
    public Image characterClassImage; // ���� ������ ������ ���������
    public int maximumCharacterHP = 100; // ������������ HP ���������
    public float characterHP = 100; // HP ���������
    public Image characterHPImage; // ����� HP ���������
    public int characterLevel = 1; // ������� ���������
    public Text characterLevelText; // ���� ������ ������ ���������
    public int characterDamage; // ���� ���������
    public bool isFight = false; // ��������
    public Location location; // �������
    public float characterXP; // XP ���������
    public int characterMiss; // ������� ��������� 
    public Sprite[] inputCharacterFrame; // ���� ����� ����� ������ ���������
    public Image outputCharacterFrame; // ���� ������ ����� ������ ���������

    #region Name

    // ���������� ��� ���������
    public void SetNameCharacter(string name)
    {
        characterName = name;
        PrintNameCharacter(name);
    }

    // ������� ��� ��������� �� �����
    private void PrintNameCharacter(string name)
    {
        characterNameText.text = name;
    }

    #endregion

    #region Gender

    // ���������� ��� ���������
    public void SetGenderCharacter(string gender)
    {
        characterGender = gender;
    }

    #endregion

    #region Class

    // ������� ����� ��������� �� �����
    public void PrintClassCharacter(Image classImage)
    {
        characterClassImage.sprite = classImage.sprite;
    }

    #endregion

    #region HP

    // ����������� HP
    public void RegenerationHP(float regeneration)
    {
        if(characterHP < maximumCharacterHP && characterHPImage.fillAmount <= characterHP / maximumCharacterHP)
        {
            characterHP += regeneration;
            characterHPImage.fillAmount += regeneration / maximumCharacterHP;
        }
    }

    // ��������� HP
    public void LoweringHP()
    {
        if(characterHPImage.fillAmount > characterHP / maximumCharacterHP)
        {
            characterHPImage.fillAmount -= Time.deltaTime;
        }
    }

    // ���������� HP ���������
    public void SetHPCharacter(int HP)
    {
        characterHP = HP;
    }

    #endregion

    #region Level

    // ���������� ������� ���������
    public void SetLevelCharacter(int level)
    {
        characterLevel = level;
        PrintLevelCharacter(level);
    }

    // ������� ������� ��������� �� �����
    private void PrintLevelCharacter(int level)
    {
        characterLevelText.text = level.ToString();
    }

    #endregion

    #region Damage

    // ���������� ���� ���������
    public void SetDamageCharacter(int minDamage, int maxDamage)
    {
        characterDamage = Random.Range(minDamage, maxDamage);
    }

    // �������� ����
    public void TakeDamage(int Damage)
    {
        characterHP -= Damage;
    }

    #endregion

    #region Miss

    // ���������� ������� ���������
    public void SetMissCharacter(int miss)
    {
        characterMiss = miss;
    }

    #endregion

    #region Battle

    // ������ ��� ��������� ��������
    public void StartEndBattle(bool isStartEnd)
    {
        if (location.locationNumber != 0)
        {
            isFight = isStartEnd;
        }
    }

    #endregion

    #region Death

    // ������ ���������
    public abstract void DeathCharacter();

    #endregion

    #region Frame

    // ���������� ����� ��������� � ����������� �� ������
    public void SetFrameCharacter()
    {
        if(characterLevel < 40)
        {
            outputCharacterFrame.sprite = inputCharacterFrame[0];
        }
        else if(characterLevel < 80)
        {
            outputCharacterFrame.sprite = inputCharacterFrame[1];
        }
        else
        {
            outputCharacterFrame.sprite = inputCharacterFrame[2];
        }
    }

    #endregion
}
