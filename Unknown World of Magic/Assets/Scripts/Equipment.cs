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
    public int equipmentDamage = 0; // дополнительный урон от снаряжения
    public int equipmentMaximumHP = 0; // дополнительное максимальное HP от снаряжения
    public float equipmentRegenerationHP = 1; // дополнительное востановление HP от снаряжения
    public int equipmentGold = 0; // дополнительное золото от снаряжения
    public Characteristics characteristics; // характеристики

    private void Update()
    {
        PrintGoldCharacter();    
    }

    // установить начальные элементы снаряжени
    public void SetStartEquipmentElements(int numberElement)
    {
        equipmentElements[6].sprite = startEquipmentElements[0 + numberElement];
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

    // установить элемент снаряжения
    public void SetEquipmentElements(int numberElement, Sprite newEquipmentElement)
    {
        equipmentElements[numberElement].sprite = newEquipmentElement;
    }

    // установить дополнительный урон
    public void SetDamage(int damage)
    {
        equipmentDamage += damage;
    }

    // установить дополнительное максимальное HP
    public void SetMaximumHP(int protection)
    {
        equipmentMaximumHP += protection;
    }

    // установить дополнительное востановление HP
    public void SetRegenerationHP(int regenerationHP)
    {
        equipmentRegenerationHP = 1 + (float)regenerationHP / 10;
    }

    // установить дополнительное золото
    public void SetGold(int gold)
    {
        equipmentGold += gold;
    }

    // установить дополнительный интеллект
    public void SetIntelligence(int magicalKnowledge)
    {
        characteristics.SetIntelligenceEquipment(magicalKnowledge);
    }
}
