using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characteristics : MonoBehaviour
{
    public int points; // доступные очки
    public int strength; // сила
    public int agility; // ловкость
    public int intelligence; // интеллект
    public int damage; // урон
    public int miss; // промахи
    public int maximumHP; // максимальное HP
    public int[] characteristicsPoints; // очки характеристик и доступные очки
    public Text[] characteristicsText; // поля вывода очков характеристик и доступных очков

    private void Update()
    {
        AssignPointsCharacteristics();
    }

    #region Characteristics

    // вывести очки характеристик и доступные очки на экран
    private void PrintPointsCharacteristics()
    {
        for(int i = 0; i < 4; i++)
        {
            characteristicsText[i].text = characteristicsPoints[i].ToString();
        }
    }

    // присвоить характеристикам и доступным очкам их очки
    public void AssignPointsCharacteristics()
    {
        points = characteristicsPoints[0];
        strength = characteristicsPoints[1];
        agility = characteristicsPoints[2];
        intelligence = characteristicsPoints[3];
        PrintPointsCharacteristics();
    }

    // поднять очки характеристики или доступные характеристики
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

    // установить характеристику урона в зависимости от класса персонажа
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

    // установить промахи в зависимости от ловкости
    private void SetMissAgility()
    {
        if(agility % 5 == 0)
        {
            miss++;
        }
    }

    #endregion

    #region HP

    // установить максимальное HP в зависимости от силы
    public int SetMaximumHPStrength()
    {
        maximumHP = strength * 10;
        return maximumHP;
    }

    #endregion
}
