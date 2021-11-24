using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Locations : MonoBehaviour
{
    public int locationNumber; // ����� �������
    public GameObject[] locationControlButton; // ������ ���������� ��������
    public Text locationName; // �������� �������
    public Text locationText; // ����� �������
    public Fight fight; // ��������
    public NPC npc; // NPC

    private void Update()
    {
        SetLimitMaximumLocationNumber(2);
    }

    #region SetLocation

    // ���������� ��������� �������
    public void SetNextLocation()
    {
        ConnectionServer server = new ConnectionServer();
        locationNumber = Convert.ToInt32(server.SendingMessage("SetNextLocation"));
        GetNameLocation();
        GetTextLocation();
        fight.SetFinishFight();
        SetAttributesNPC();
    }

    // ���������� ���������� �������
    public void SetPreviousLocation()
    {
        ConnectionServer server = new ConnectionServer();
        locationNumber = Convert.ToInt32(server.SendingMessage("SetPreviousLocation"));
        GetNameLocation();
        GetTextLocation();
        fight.SetFinishFight();
        SetAttributesNPC();
    }

    // ���������� ����������� �� ������������� ������ �������
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

    // �������� ����������� ������� �������
    private void ResetLimitLocationNumber()
    {
        for (int i = 0; i < locationControlButton.Length; i++)
        {
            locationControlButton[i].SetActive(true);
        }
    }

    #endregion

    #region GetLocationInformation

    // �������� �������� �������
    public void GetNameLocation()
    {
        ConnectionServer server = new ConnectionServer();
        PrintNameLocatin(server.SendingMessage("GetNameLocation"));
    }

    // �������� ����� �������
    public void GetTextLocation()
    {
        ConnectionServer server = new ConnectionServer();
        PrintTextLocation(server.SendingMessage("GetTextLocation"));
    }

    #endregion

    #region PrintLocationInformation

    // ������� �� ����� �������� �������
    private void PrintNameLocatin(string name)
    {
        locationName.text = name;
    }

    // ������� �� ����� ����� �������
    private void PrintTextLocation(string text)
    {
        locationText.text = text;
    }

    #endregion

    #region NPCAttributes

    // ���������� �������� NPC
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
