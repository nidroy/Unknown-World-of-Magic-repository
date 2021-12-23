using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Location : MonoBehaviour
{
    public Text locationName; // �������� �������
    public Text locationDescription; // �������� �������
    public Enemy enemy; // ����
    public GameObject buttonNextLocation; // ������ ��������� ��������� �������
    public GameObject buttonPreviousLocation; // ������ ��������� ���������� �������

    #region SetLocationAttributes

    // ���������� �������� �������
    public void SetLocationName(string name)
    {
        locationName.text = name;
    }

    // ���������� �������� �������
    public void SetLocationDescription(string description)
    {
        locationDescription.text = description;
    }

    #endregion

    // ���������� ���������, ���������, ���������� �������
    public void SetInitialNextPreviousLocation(string command)
    {
        Server server = new Server(); // ������

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

    // ���������� ������� �������
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
