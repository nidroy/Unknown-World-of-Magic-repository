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

    private void Update()
    {
        PrintGoldCharacter();    
    }

    // ���������� ��������� �������� ���������
    public void SetStartEquipmentElements(int numberElement)
    {
        equipmentElements[5].sprite = startEquipmentElements[0 + numberElement];
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
}
