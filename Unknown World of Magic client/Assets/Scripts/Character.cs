using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public Text characterName; // ��� ���������
    public Text characterLevel; // ������� ���������
    public Image characterIcon; // ������ ���������
    public Image characterHealthPoints; // ���� �������� ���������
    public int maximumCharacterHealthPoints; // ������������ ���� �������� ���������
    public bool isFight; // �������� ���������

    #region SetCharacterAttributes

    // ���������� ��� ���������
    public void SetCharacterName(string name)
    {
        characterName.text = name;
    }

    // ���������� ������� ���������
    public void SetCharacterLevel(int level)
    {
        characterLevel.text = level.ToString();
    }

    // ���������� ����������� ���������
    public void SetCharacterIcon(Sprite icon)
    {
        characterIcon.sprite = icon;
    }

    // ���������� ���� �������� ���������
    public void SetCharacterHealthPoints(int healthPoints)
    {
        characterHealthPoints.fillAmount = (float)healthPoints / (float)maximumCharacterHealthPoints;
    }

    // ���������� ������������ ���� �������� ���������
    public void SetMaximumCharacterHealthPoints(int maximumHealthPoints)
    {
        maximumCharacterHealthPoints = maximumHealthPoints;
    }

    // ���������� ����������� ���������
    public void SetAbilityFight(bool isCharacterFight)
    {
        isFight = isCharacterFight;
    }

    #endregion

    // ����� ���������
    public abstract void Attack();

    // ������ ���������
    public abstract void Death();
}
