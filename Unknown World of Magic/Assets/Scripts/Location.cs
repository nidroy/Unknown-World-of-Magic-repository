using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour
{
    public int locationNumber = 0; // номер локации
    public string locationName; // название локации
    public Text locationNameText; // поле вывода названия локации
    public GameObject[] locationControlButtons; // кнопки управления локацией

    private void Update()
    {
        if(locationNumber == 0)
        {
            Fortress();
        }
        else if(locationNumber == 1)
        {
            Glade();
        }   
        else if(locationNumber == 2)
        {
            Forest();
        }
    }

    #region Movement

    // движение по локациям
    public void MovementLocation(int direction)
    {
        locationNumber += direction;
    }

    #endregion

    #region NameLocation

    // установить название локации
    public void SetNameLocation(string name)
    {
        locationName = name;
        PrintNameLocation(name);
    }

    // вывести название локации на экран
    private void PrintNameLocation(string name)
    {
        locationNameText.text = name;
    }

    #endregion

    // крепость
    public void Fortress()
    {
        SetNameLocation("Крепость");
        locationControlButtons[0].SetActive(false);
    }

    // поляна
    public void Glade()
    {
        SetNameLocation("Поляна");
        locationControlButtons[0].SetActive(true);
        locationControlButtons[1].SetActive(true);
    }

    // лес
    public void Forest()
    {
        SetNameLocation("Лес");
        locationControlButtons[1].SetActive(false);
    }
}
