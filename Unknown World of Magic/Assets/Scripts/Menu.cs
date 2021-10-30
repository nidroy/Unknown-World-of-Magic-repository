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

    // выйти из игры
    public void ExitGame()
    {
        Application.Quit();
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
    public NPC npc; // неигровой персонаж
    public Tasks tasks; // задания
    public Animator[] itemsPlayerMenu; // элементы меню игрока

    #region ButtonName

    // установить название кнопки в меню
    public void SetMenuButtonName(string name)
    {
        menuButtonName.text = name;
    }

    #endregion

    #region ButtonInteraction

    // установить иконку кнопки взаимодействия с NPC
    public void SetIconButtonInteractionNPC(int number)
    {
        buttonInteractionNPCImage.sprite = buttonInteractionNPCSprite[number];
    }

    // установить видимость кнопки взаимодействия с NPC
    public void SetVisibilityButtonInteractionNPC(bool isVisibility)
    {
        if (!player.isFight)
        {
            buttonInteractionNPC.SetActive(isVisibility);
        }
    }

    #endregion

    #region Clock

    // установить видимость часов
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

    // установить видимость кнопки первого действия
    public void SetVisibilityButtonFirstAction(bool isVisibility)
    {
        buttonsAction[0].SetActive(isVisibility);
    }

    // установить видимость кнопки второго действия
    public void SetVisibilityButtonSecondAction(bool isVisibility)
    {
        buttonsAction[1].SetActive(isVisibility);
    }

    // установить текст на кнопках действий
    public void SetTextButtonsAction()
    {
        if (player.isFight)
        {
            location.SetText("Главный герой, недолго думая, решил атаковать противника, пока тот был чем-то отвлечён.");
            buttonsActionText[0].text = "Атаковать";
            buttonsActionText[1].text = "Уклониться";
        }
        else if(npc.isGivesTasks)
        {
            buttonsActionText[0].text = "Принять";
            buttonsActionText[1].text = "Откозаться";

            if (tasks.numberTask == 0)
            {
                PrintTextTask(0, "Хочешь вступить в гильдию? Хорошо. Но для начала, помоги местным купцам. Убей 10 разбойников, которые обосновались на поляне недалеко от города.");
            }
            else if(tasks.numberTask == 1)
            {
                PrintTextTask(1, "Ты смог убедить меня, что умеешь сражаться. Ходят слухи, что лешие убили семью лесоруба, и ты, как член гильдии, должен отомстить за них. Иди в лес и убей 5 леших.");
            }
            else if(tasks.numberTask == 2)
            {
                PrintTextTask(2, "Ты хорошо проявил себя. Помнишь ты помог купцам, убив 10 разбойников? Главарь этой банды выжил, собрал ещё больше людей и вернулся на поляну. Ты должен наведаться к ним и убить 20 разбойников.");
            }
        }
        else
        {
            location.SetText("Приветствую тебя путник. Что я могу тебе предложить?");
            buttonsActionText[0].text = "Задание";
            buttonsActionText[1].text = "Торговля";
        }
    }

    #endregion

    #region ItemMenuPlayer

    // открыть элемент меню игрока
    public void OpenItemMenuPlayer(int item)
    {
        itemsPlayerMenu[item].SetBool("isOpen", true);
    }

    // закрыть элемент меню игрока
    public void CloseItemMenuPlayer(int item)
    {
        itemsPlayerMenu[item].SetBool("isOpen", false);
        SetMenuButtonName("");
    }

    #endregion

    #region Tasks

    // вывести текст задания на экран
    private void PrintTextTask(int numberTask, string textTask)
    {
        if(tasks.isCompletingTask[2])
        {
            location.SetText("Молодец! Ты выполнил все задания.");
            SetVisibilityButtonFirstAction(false);
            buttonsActionText[1].text = "Уйти";
        }
        else if (tasks.isStartCompletingTask[numberTask])
        {
            location.SetText("Ты взял задание. Иди и выполни его.");
            SetVisibilityButtonFirstAction(false);
            buttonsActionText[1].text = "Уже иду";
        }
        else
        {
            location.SetText(textTask);
        }
    }

    #endregion

    #endregion
}
