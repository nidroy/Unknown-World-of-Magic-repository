using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public Image[] equipmentElements; // �������� ����������
    public Sprite[] startEquipmentElements; // ��������� �������� ����������
    public Text goldText; // ���� ������ ���������� ������
    public Image playerIcon; // ���� ������ ������ ���������
    public Player player; // ������� �����
    public int equipmentDamage = 0; // �������������� ���� �� ����������
    public int equipmentMaximumHP = 0; // �������������� ������������ HP �� ����������
    public float equipmentRegenerationHP = 1; // �������������� ������������� HP �� ����������
    public int equipmentGold = 0; // �������������� ������ �� ����������
    public Characteristics characteristics; // ��������������

    private void Update()
    {
        PrintGoldCharacter();    
    }

    // ���������� ��������� �������� ���������
    public void SetStartEquipmentElements(int numberElement)
    {
        equipmentElements[6].sprite = startEquipmentElements[0 + numberElement];
        equipmentElements[7].sprite = startEquipmentElements[1 + numberElement];
    }

    // ���������� ������ ��������
    public void SetPlayerIcon()
    {
        playerIcon.sprite = player.characterClassImage.sprite;
    }

    // ������� ���������� ������ ��������� �� �����
    public void PrintGoldCharacter()
    {
        goldText.text = player.characterGold.ToString();
    }

    // ���������� ������� ����������
    public void SetEquipmentElements(int numberElement, Sprite newEquipmentElement)
    {
        equipmentElements[numberElement].sprite = newEquipmentElement;
    }

    // ���������� �������������� ����
    public void SetDamage(int damage)
    {
        equipmentDamage += damage;
    }

    // ���������� �������������� ������������ HP
    public void SetMaximumHP(int protection)
    {
        equipmentMaximumHP += protection;
    }

    // ���������� �������������� ������������� HP
    public void SetRegenerationHP(int regenerationHP)
    {
        equipmentRegenerationHP = 1 + (float)regenerationHP / 10;
    }

    // ���������� �������������� ������
    public void SetGold(int gold)
    {
        equipmentGold += gold;
    }

    // ���������� �������������� ���������
    public void SetIntelligence(int magicalKnowledge)
    {
        characteristics.SetIntelligenceEquipment(magicalKnowledge);
    }
}
