using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour
{
    public int locationNumber = 0; // ����� �������
    public string locationName; // �������� �������
    public Text locationNameText; // ���� ������ �������� �������
    public Text locationText; // ���� ������ ������ �� �������
    public GameObject[] locationControlButtons; // ������ ���������� ��������
    public Menu menu; // ����

    private void Start()
    {
        Fortress();
        SetTextLocation();
    }

    #region Movement

    // �������� �� ��������
    public void MovementLocation(int direction)
    {
        locationNumber += direction;
    }

    #endregion

    #region NameLocation

    // ���������� �������� �������
    public void SetNameLocation(string name)
    {
        locationName = name;
        PrintNameLocation(name);
    }

    // ������� �������� ������� �� �����
    private void PrintNameLocation(string name)
    {
        locationNameText.text = name;
    }

    #endregion

    #region ChangingLocations

    // ������� �������
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

    // ��������
    private void Fortress()
    {
        SetNameLocation("��������");
        locationControlButtons[0].SetActive(false);
        menu.SetIconButtonInteractionNPC(0);
    }

    // ������
    private void Glade()
    {
        SetNameLocation("������");
        locationControlButtons[0].SetActive(true);
        locationControlButtons[1].SetActive(true);
        menu.SetIconButtonInteractionNPC(1);
    }

    // ���
    private void Forest()
    {
        SetNameLocation("���");
        locationControlButtons[1].SetActive(false);
    }

    #endregion

    #region TextLocation

    // ���������� ����� �� ������� � ����������� �� ������ �������
    public void SetTextLocation()
    {
        if(locationNumber == 0)
        {
            SetText("�������� - ����� ���������� ����� � ������. ���� ��������� ����������� ��������� � �������������. ����� �����������, ���� �������, ��� ����� ��������� ����� ����� �������������� �������.");
        }
        else if(locationNumber == 1)
        {
            SetText("������ ������ ������������� �������� �� ����� � �����. �� ������ ������������� ����� �����������, ������������� ���������, ������� ���� � �����.");
        }
        else if(locationNumber == 2)
        {
            SetText("������ � ����� ���, �� ������ �������� ��������� �������� �����. ��� ���� ����������� �����. ��� ������ �� �������� � ���� � �� ����� ������� �� ������.");
        }
    }

    // ���������� ����� �� �������
    public void SetText(string text)
    {
        locationText.text = text;
    }

    #endregion
}
