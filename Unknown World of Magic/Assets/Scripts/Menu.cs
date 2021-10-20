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

    // установить название кнопки в меню
    public void SetMenuButtonName(string name)
    {
        menuButtonName.text = name;
    }

    #endregion
}
