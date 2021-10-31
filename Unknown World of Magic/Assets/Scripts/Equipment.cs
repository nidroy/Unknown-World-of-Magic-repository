using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public Image[] equipmentElements; // элементы снаряжения
    public Sprite[] startEquipmentElements; // начальные элементы снаряжения
    public Text goldText; // поле вывода количества золота
    public Image playerIcon; // окно вывода иконки персонажа
    public Player player; // главный герой

    private void Update()
    {
        PrintGoldCharacter();    
    }

    // установить начальные элементы снаряжени
    public void SetStartEquipmentElements(int numberElement)
    {
        equipmentElements[5].sprite = startEquipmentElements[0 + numberElement];
        equipmentElements[7].sprite = startEquipmentElements[1 + numberElement];
    }

    // установить иконку прсонажа
    public void SetPlayerIcon()
    {
        playerIcon.sprite = player.characterClassImage.sprite;
    }

    // вывести количество золота персонажа на экран
    public void PrintGoldCharacter()
    {
        goldText.text = player.characterGold.ToString();
    }
}
