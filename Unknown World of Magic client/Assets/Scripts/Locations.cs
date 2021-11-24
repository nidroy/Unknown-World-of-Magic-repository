using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Locations : MonoBehaviour
{
    public int locationNumber; // номер локации
    public GameObject[] locationControlButton; // кнопки управления локацией
    public Text locationName; // название локации
    public Text locationText; // такст локации
    public Fight fight; // сражение
    public NPC npc; // NPC

    private void Update()
    {
        SetLimitMaximumLocationNumber(2);
    }

    #region SetLocation

    // установить следующую локацию
    public void SetNextLocation()
    {
        ConnectionServer server = new ConnectionServer();
        locationNumber = Convert.ToInt32(server.SendingMessage("SetNextLocation"));
        GetNameLocation();
        GetTextLocation();
        fight.SetFinishFight();
        SetAttributesNPC();
    }

    // установить предыдущую локацию
    public void SetPreviousLocation()
    {
        ConnectionServer server = new ConnectionServer();
        locationNumber = Convert.ToInt32(server.SendingMessage("SetPreviousLocation"));
        GetNameLocation();
        GetTextLocation();
        fight.SetFinishFight();
        SetAttributesNPC();
    }

    // установить ограничение по максимальному номеру локации
    private void SetLimitMaximumLocationNumber(int maximumLocationNumber)
    {
        if(locationNumber == 0)
        {
            ResetLimitLocationNumber();

            locationControlButton[0].SetActive(false);
        }
        else if(locationNumber == maximumLocationNumber - 1)
        {
            ResetLimitLocationNumber();

            locationControlButton[1].SetActive(false);
        }
        else
        {
            ResetLimitLocationNumber();
        }
    }

    // сбросить ограничение номеров локаций
    private void ResetLimitLocationNumber()
    {
        for (int i = 0; i < locationControlButton.Length; i++)
        {
            locationControlButton[i].SetActive(true);
        }
    }

    #endregion

    #region GetLocationInformation

    // получить название локации
    public void GetNameLocation()
    {
        ConnectionServer server = new ConnectionServer();
        PrintNameLocatin(server.SendingMessage("GetNameLocation"));
    }

    // получить текст локации
    public void GetTextLocation()
    {
        ConnectionServer server = new ConnectionServer();
        PrintTextLocation(server.SendingMessage("GetTextLocation"));
    }

    #endregion

    #region PrintLocationInformation

    // вывести на экран название локации
    private void PrintNameLocatin(string name)
    {
        locationName.text = name;
    }

    // вывести на экран текст локации
    private void PrintTextLocation(string text)
    {
        locationText.text = text;
    }

    #endregion

    #region NPCAttributes

    // установить атрибуты NPC
    private void SetAttributesNPC()
    {
        npc.PrintNPCName();
        if (locationNumber == 0)
        {
            npc.SetHealthPoints(100);
        }
        else if(locationNumber == 1)
        {
            npc.SetHealthPoints(250);
        }
        npc.PrintNPCLevel();
        npc.SetNPCClass();
    }

    #endregion
}
