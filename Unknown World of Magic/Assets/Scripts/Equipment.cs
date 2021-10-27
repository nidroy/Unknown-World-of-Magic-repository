using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public Image[] equipmentElements; // �������� ����������
    public Sprite[] startEquipmentElements; // ��������� �������� ����������
    public Text goldText; // ���� ������ ���������� ������
    public Player player; // ������� �����

    private void Update()
    {
        PrintGoldCharacter();    
    }

    // ���������� ��������� �������� ���������
    public void SetStartEquipmentElements(int numberElement)
    {
        equipmentElements[5].sprite = startEquipmentElements[0 + numberElement];
        equipmentElements[8].sprite = startEquipmentElements[1 + numberElement];
    }

    // ������� ���������� ������ ��������� �� �����
    public void PrintGoldCharacter()
    {
        goldText.text = player.characterGold.ToString();
    }
}
