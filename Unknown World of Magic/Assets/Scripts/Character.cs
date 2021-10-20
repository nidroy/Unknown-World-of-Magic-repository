using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
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
}
