using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Location : MonoBehaviour
{
    public Text locationName; // название локации
    public Text locationDescription; // описание локации
    public Enemy enemy; // враг
    public GameObject buttonNextLocation; // кнопка установки следующей локации
    public GameObject buttonPreviousLocation; // кнопка установки предыдущей локации

    #region SetLocationAttributes

    // установить название локации
    public void SetLocationName(string name)
    {
        locationName.text = name;
    }

    // установить описание локации
    public void SetLocationDescription(string description)
    {
        locationDescription.text = description;
    }

    #endregion

    // установить начальную, следующую, предыдущую локацию
    public void SetInitialNextPreviousLocation(string command)
    {
        Server server = new Server(); // сервер

        string[] attribute = server.SendingMessage(command).Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

        SetLocationName(attribute[0]);
        SetLocationDescription(attribute[1]);

        enemy.SetCharacterName(attribute[2]);
        enemy.SetMaximumCharacterHealthPoints(int.Parse(attribute[3]));
        enemy.SetCharacterHealthPoints(int.Parse(attribute[3]));
        enemy.SetCharacterLevel(int.Parse(attribute[4]));
        enemy.SetEnemyIcon();

        SetLocationBoundaries("Glade", "Forest");
    }

    // установить границу локации
    public void SetLocationBoundaries(string leftBorder, string rightBorder)
    {
        buttonNextLocation.SetActive(true);
        buttonPreviousLocation.SetActive(true);
        if (locationName.text == leftBorder)
        {
            buttonPreviousLocation.SetActive(false);
        }
        if(locationName.text == rightBorder)
        {
            buttonNextLocation.SetActive(false);
        }
    }
}
