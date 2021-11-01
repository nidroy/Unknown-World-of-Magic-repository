using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characteristics : MonoBehaviour
{
    public int points = 10; // ��������� ����
    public int strength = 1; // ����
    public int agility = 1; // ��������
    public int intelligence = 1; // ���������
    public int damage; // �������������� ���� �� �������������
    public int miss; // �������������� ������� �� �������������
    public int maximumHP; // �������������� ������������ HP �� �������������
    public int[] characteristicsPoints; // ���� ������������� � ��������� ����
    public Text[] characteristicsText; // ���� ������ ����� ������������� � ��������� �����
    public Text descriptionText; // ���� ������ �������� ��������������

    private void Update()
    {
        AssignPointsCharacteristics();
    }

    #region Characteristics

    // ������� ���� ������������� � ��������� ���� �� �����
    private void PrintPointsCharacteristics()
    {
        for(int i = 0; i < 4; i++)
        {
            characteristicsText[i].text = characteristicsPoints[i].ToString();
        }
    }

    // ��������� ��������������� � ��������� ����� �� ����
    public void AssignPointsCharacteristics()
    {
        points = characteristicsPoints[0];
        strength = characteristicsPoints[1];
        agility = characteristicsPoints[2];
        intelligence = characteristicsPoints[3];
        PrintPointsCharacteristics();
    }

    // ������� ���� �������������� ��� ��������� ��������������
    public void RaisePointsCharacteristic(int numberCharacteristic)
    {
        if(numberCharacteristic == 0)
        {
            characteristicsPoints[numberCharacteristic]++;
        }
        else if(points > 0)
        {
            characteristicsPoints[numberCharacteristic]++;
            characteristicsPoints[0]--;
            SetMissAgility();
        }
    }

    #endregion

    #region Damage

    // ���������� �������������� ����� � ����������� �� ������ ���������
    public int SetDamageCharacteristic(string characterClass)
    {
        if(characterClass == "Archer")
        {
            damage = agility;
        }
        else if(characterClass == "Warrior")
        {
            damage = strength;
        }
        else if(characterClass == "Magician")
        {
            damage = intelligence;
        }
        return damage;
    }

    #endregion

    #region Miss

    // ���������� ������� � ����������� �� ��������
    private void SetMissAgility()
    {
        if(agility % 5 == 0)
        {
            miss++;
        }
    }

    #endregion

    #region HP

    // ���������� ������������ HP � ����������� �� ����
    public int SetMaximumHPStrength()
    {
        maximumHP = strength * 10;
        return maximumHP;
    }

    // ���������� ������������� HP
    public float SetRegenerationHP()
    {
        float regenerationHP = 1 + (float)strength / 10;
        return regenerationHP;
    }

    #endregion

    #region Help

    // ����� �� ����� �������� ��������������
    public void PrintDescriptionCharacteristic(int numberCharacteristic)
    {
        if(numberCharacteristic == 1)
        {
            descriptionText.text = "���� ����������� ���������� �������� � �������� ��� ��������������.";
        }
        else if(numberCharacteristic == 2)
        {
            descriptionText.text = "�������� ����������� ����������� ��������� �� ���������� � ����������� ��������� �� ���� ����������.";
        }
        else if(numberCharacteristic == 3)
        {
            descriptionText.text = "��������� ����������� ������������� ������� ���������.";
        }
    }

    #endregion

    #region Equipment

    // ���������� ���� � ����������� �� ���������� ���������
    public void SetStrengthEquipment(int equipmentStrength)
    {
        characteristicsPoints[1] += equipmentStrength;
    }

    // ���������� �������� � ����������� �� ���������� ���������
    public void SetAgilityEquipment(int equipmentAgility)
    {
        characteristicsPoints[2] += equipmentAgility;
    }

    // ���������� �������� � ����������� �� ���������� ���������
    public void SetIntelligenceEquipment(int equipmentIntelligence)
    {
        characteristicsPoints[3] += equipmentIntelligence;
    }

    #endregion
}
