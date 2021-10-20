using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    #region GameMenu

    public Sprite[] inputClassSelectionSprite; // ���� ����� ������� ���������
    public Image[] outputClassSelectionImage; // ���� ������ ������� ���������

    // ������� ���� ������ ����/������ ���������
    public void �loseMenuSelection(GameObject menuSelection)
    {
        menuSelection.SetActive(false);
    }

    // �������� ���� ������ ������ ��������� � ����������� �� ����
    public void UpdateMenuClassSelection(int numberInitialClassSelection)
    {
        for(int i = 0; i < 3; i++)
        {
            outputClassSelectionImage[i].sprite = inputClassSelectionSprite[i + numberInitialClassSelection];
        }
    }

    #endregion

    #region PlayerMenu

    public Text menuButtonName; // �������� ������ � ����

    // ���������� �������� ������ � ����
    public void SetMenuButtonName(string name)
    {
        menuButtonName.text = name;
    }

    #endregion
}
