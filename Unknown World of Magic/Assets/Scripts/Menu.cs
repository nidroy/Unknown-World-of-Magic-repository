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

    // ����� �� ����
    public void ExitGame()
    {
        Application.Quit();
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
    public NPC npc; // ��������� ��������
    public Tasks tasks; // �������
    public Animator[] itemsPlayerMenu; // �������� ���� ������

    #region ButtonName

    // ���������� �������� ������ � ����
    public void SetMenuButtonName(string name)
    {
        menuButtonName.text = name;
    }

    #endregion

    #region ButtonInteraction

    // ���������� ������ ������ �������������� � NPC
    public void SetIconButtonInteractionNPC(int number)
    {
        buttonInteractionNPCImage.sprite = buttonInteractionNPCSprite[number];
    }

    // ���������� ��������� ������ �������������� � NPC
    public void SetVisibilityButtonInteractionNPC(bool isVisibility)
    {
        if (!player.isFight)
        {
            buttonInteractionNPC.SetActive(isVisibility);
        }
    }

    #endregion

    #region Clock

    // ���������� ��������� �����
    public void SetVisibilityClock(bool isVisibility)
    {
        if(location.locationNumber == 0)
        {
            isVisibility = false;
        }

        clock.SetActive(isVisibility);
    }

    #endregion

    #region ButtonActions

    // ���������� ��������� ������ ������� ��������
    public void SetVisibilityButtonFirstAction(bool isVisibility)
    {
        buttonsAction[0].SetActive(isVisibility);
    }

    // ���������� ��������� ������ ������� ��������
    public void SetVisibilityButtonSecondAction(bool isVisibility)
    {
        buttonsAction[1].SetActive(isVisibility);
    }

    // ���������� ����� �� ������� ��������
    public void SetTextButtonsAction()
    {
        if (player.isFight)
        {
            location.SetText("������� �����, ������� �����, ����� ��������� ����������, ���� ��� ��� ���-�� ��������.");
            buttonsActionText[0].text = "���������";
            buttonsActionText[1].text = "����������";
        }
        else if(npc.isGivesTasks)
        {
            buttonsActionText[0].text = "�������";
            buttonsActionText[1].text = "����������";

            if (tasks.numberTask == 0)
            {
                PrintTextTask(0, "������ �������� � �������? ������. �� ��� ������, ������ ������� ������. ���� 10 �����������, ������� ������������ �� ������ �������� �� ������.");
            }
            else if(tasks.numberTask == 1)
            {
                PrintTextTask(1, "�� ���� ������� ����, ��� ������ ���������. ����� �����, ��� ����� ����� ����� ��������, � ��, ��� ���� �������, ������ ��������� �� ���. ��� � ��� � ���� 5 �����.");
            }
            else if(tasks.numberTask == 2)
            {
                PrintTextTask(2, "�� ������ ������� ����. ������� �� ����� ������, ���� 10 �����������? ������� ���� ����� �����, ������ ��� ������ ����� � �������� �� ������. �� ������ ���������� � ��� � ����� 20 �����������.");
            }
        }
        else
        {
            location.SetText("����������� ���� ������. ��� � ���� ���� ����������?");
            buttonsActionText[0].text = "�������";
            buttonsActionText[1].text = "��������";
        }
    }

    #endregion

    #region ItemMenuPlayer

    // ������� ������� ���� ������
    public void OpenItemMenuPlayer(int item)
    {
        itemsPlayerMenu[item].SetBool("isOpen", true);
    }

    // ������� ������� ���� ������
    public void CloseItemMenuPlayer(int item)
    {
        itemsPlayerMenu[item].SetBool("isOpen", false);
        SetMenuButtonName("");
    }

    #endregion

    #region Tasks

    // ������� ����� ������� �� �����
    private void PrintTextTask(int numberTask, string textTask)
    {
        if(tasks.isCompletingTask[2])
        {
            location.SetText("�������! �� �������� ��� �������.");
            SetVisibilityButtonFirstAction(false);
            buttonsActionText[1].text = "����";
        }
        else if (tasks.isStartCompletingTask[numberTask])
        {
            location.SetText("�� ���� �������. ��� � ������� ���.");
            SetVisibilityButtonFirstAction(false);
            buttonsActionText[1].text = "��� ���";
        }
        else
        {
            location.SetText(textTask);
        }
    }

    #endregion

    #endregion
}
