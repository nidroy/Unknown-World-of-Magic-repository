using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour
{
    public int locationNumber = 0; // номер локации
    public string locationName; // название локации
    public Text locationNameText; // поле вывода названи€ локации
    public GameObject[] locationControlButtons; // кнопки управлени€ локацией
    public Menu menu; // меню

    private void Start()
    {
        Fortress();
    }

    #region Movement

    // движение по локаци€м
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

    #region ChangingLocations

    // сменить локацию
    public void ChangeLocation()
    {
        if (locationNumber == 0)
        {
            Fortress();
        }
        else if (locationNumber == 1)
        {
            Glade();
        }
        else if (locationNumber == 2)
        {
            Forest();
        }
    }

    #endregion

    #region Locations

    // крепость
    private void Fortress()
    {
        SetNameLocation(" репость");
        locationControlButtons[0].SetActive(false);
        menu.SetIconButtonInteractionNPC(0);
    }

    // пол€на
    private void Glade()
    {
        SetNameLocation("ѕол€на");
        locationControlButtons[0].SetActive(true);
        locationControlButtons[1].SetActive(true);
        menu.SetIconButtonInteractionNPC(1);
    }

    // лес
    private void Forest()
    {
        SetNameLocation("Ћес");
        locationControlButtons[1].SetActive(false);
    }

    #endregion
}
