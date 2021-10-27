using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public Image[] equipmentElements; // элементы снаряжения
    public Sprite[] startEquipmentElements; // начальные элементы снаряжения

    // установить начальные элементы снаряжени
    public void SetStartEquipmentElements(int numberElement)
    {
        equipmentElements[5].sprite = startEquipmentElements[0 + numberElement];
        equipmentElements[8].sprite = startEquipmentElements[1 + numberElement];
    }
}
