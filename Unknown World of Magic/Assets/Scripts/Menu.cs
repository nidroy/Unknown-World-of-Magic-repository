using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    #region GameMenu

    public Sprite[] inputClassSelectionSprite; // поля ввода классов персонажа
    public Image[] outputClassSelectionImage; // поля вывода классов персонажа

    // закрыть меню выбора пола/класса персонажа
    public void СloseMenuSelection(GameObject menuSelection)
    {
        menuSelection.SetActive(false);
    }

    // обновить меню выбора класса персонажа в зависимости от пола
    public void UpdateMenuClassSelection(int numberInitialClassSelection)
    {
        for(int i = 0; i < 3; i++)
        {
            outputClassSelectionImage[i].sprite = inputClassSelectionSprite[i + numberInitialClassSelection];
        }
    }

    #endregion

    #region PlayerMenu

    public Text menuButtonName; // название кнопок в меню
    public GameObject buttonInteractionNPC; // кнопка взаимодействия с NPC
    public GameObject clock; // часы
    public Sprite[] buttonInteractionNPCSprite; // поле ввода кнопки взаимодействия с NPC
    public Image buttonInteractionNPCImage; // поле вывода кнопки взаимодействия с NPC
    public Location location; // локация
    public GameObject[] buttonsAction; // кнопки действий
    public Text[] buttonsActionText; // текст на кнопках действий
    public Player player; // главный герой
    public Animator[] itemsPlayerMenu; // элементы меню игрока

    private void Update()
    {
        SetTextButtonsAction();
    }

    // установить название кнопки в меню
    public void SetMenuButtonName(string name)
    {
        menuButtonName.text = name;
    }

    // установить иконку кнопки взаимодействия с NPC
    public void SetIconButtonInteractionNPC(int number)
    {
        buttonInteractionNPCImage.sprite = buttonInteractionNPCSprite[number];
    }

    // установить видимость кнопки взаимодействия с NPC
    public void SetVisibilityButtonInteractionNPC(bool isVisibility)
    {
        buttonInteractionNPC.SetActive(isVisibility);
    }

    // установить видимость часов
    public void SetVisibilityClock(bool isVisibility)
    {
        if (location.locationNumber != 0)
        {
            clock.SetActive(isVisibility);
        }
    }

    // установить видимость кнопки первого действия
    public void SetVisibilityButtonFirstAction(bool isVisibility)
    {
        if (location.locationNumber != 0)
        {
            buttonsAction[0].SetActive(isVisibility);
        }
    }

    // установить видимость кнопки второго действия
    public void SetVisibilityButtonSecondAction(bool isVisibility)
    {
        if (location.locationNumber != 0)
        {
            buttonsAction[1].SetActive(isVisibility);
        }
    }

    // установить текст на кнопках действий
    private void SetTextButtonsAction()
    {
        if (player.isFight)
        {
            buttonsActionText[0].text = "Атаковать";
            buttonsActionText[1].text = "Уклониться";
        }
    }

    // открыть элемент меню игрока
    public void OpenItemMenuPlayer(int item)
    {
        itemsPlayerMenu[item].SetBool("isOpen", true);
    }

    // закрыть элемент меню игрока
    public void CloseItemMenuPlayer(int item)
    {
        itemsPlayerMenu[item].SetBool("isOpen", false);
    }

    #endregion
}
