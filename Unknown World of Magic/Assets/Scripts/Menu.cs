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
    public GameObject buttonInteractionNPC; // ������ �������������� � NPC
    public GameObject clock; // ����
    public Sprite[] buttonInteractionNPCSprite; // ���� ����� ������ �������������� � NPC
    public Image buttonInteractionNPCImage; // ���� ������ ������ �������������� � NPC
    public Location location; // �������
    public GameObject[] buttonsAction; // ������ ��������
    public Text[] buttonsActionText; // ����� �� ������� ��������
    public Player player; // ������� �����
    public Animator[] itemsPlayerMenu; // �������� ���� ������

    private void Update()
    {
        SetTextButtonsAction();
    }

    // ���������� �������� ������ � ����
    public void SetMenuButtonName(string name)
    {
        menuButtonName.text = name;
    }

    // ���������� ������ ������ �������������� � NPC
    public void SetIconButtonInteractionNPC(int number)
    {
        buttonInteractionNPCImage.sprite = buttonInteractionNPCSprite[number];
    }

    // ���������� ��������� ������ �������������� � NPC
    public void SetVisibilityButtonInteractionNPC(bool isVisibility)
    {
        buttonInteractionNPC.SetActive(isVisibility);
    }

    // ���������� ��������� �����
    public void SetVisibilityClock(bool isVisibility)
    {
        if (location.locationNumber != 0)
        {
            clock.SetActive(isVisibility);
        }
    }

    // ���������� ��������� ������ ������� ��������
    public void SetVisibilityButtonFirstAction(bool isVisibility)
    {
        if (location.locationNumber != 0)
        {
            buttonsAction[0].SetActive(isVisibility);
        }
    }

    // ���������� ��������� ������ ������� ��������
    public void SetVisibilityButtonSecondAction(bool isVisibility)
    {
        if (location.locationNumber != 0)
        {
            buttonsAction[1].SetActive(isVisibility);
        }
    }

    // ���������� ����� �� ������� ��������
    private void SetTextButtonsAction()
    {
        if (player.isFight)
        {
            buttonsActionText[0].text = "���������";
            buttonsActionText[1].text = "����������";
        }
    }

    // ������� ������� ���� ������
    public void OpenItemMenuPlayer(int item)
    {
        itemsPlayerMenu[item].SetBool("isOpen", true);
    }

    // ������� ������� ���� ������
    public void CloseItemMenuPlayer(int item)
    {
        itemsPlayerMenu[item].SetBool("isOpen", false);
    }

    #endregion
}
