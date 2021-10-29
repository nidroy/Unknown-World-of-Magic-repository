using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour
{
    public int locationNumber = 0; // номер локации
    public string locationName; // название локации
    public Text locationNameText; // поле вывода названи€ локации
    public Text locationText; // поле вывода текста на локации
    public GameObject[] locationControlButtons; // кнопки управлени€ локацией
    public Menu menu; // меню

    private void Start()
    {
        Fortress();
        SetTextLocation();
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

    #region TextLocation

    // установить текст на локации в зависимости от номера локации
    public void SetTextLocation()
    {
        if(locationNumber == 0)
        {
            SetText(" репость - самое безопасное место в округе. —юда стекаютс€ большинство торговцев и ремесленников. «десь расположена, але€ гильдий, где можно встретить главу самой могущественной гильдии.");
        }
        else if(locationNumber == 1)
        {
            SetText("«елЄна€ пол€на расположенна€ недалеко от ворот в город. Ќа пол€не расположилась банда разбойников, обкрадывающа€ торговцев, которые идут в город.");
        }
        else if(locationNumber == 2)
        {
            SetText("√устой и тЄмный лес, из кустов которого донос€тс€ звериные вопли. Ёта чаща принадлежит Ћешим. ќни след€т за пор€дком в лесу и не люб€т чужаков из города.");
        }
    }

    // установить текст на локации
    public void SetText(string text)
    {
        locationText.text = text;
    }

    #endregion
}
