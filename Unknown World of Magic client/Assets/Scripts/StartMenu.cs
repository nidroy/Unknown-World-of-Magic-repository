using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public Animator gameAnim; // анимации игры

    // начать новую игру
    public void StartNewGame()
    {
        gameAnim.SetBool("isShowCreatingPlayer", true);
    }

    // продолжить игру
    public void ContinueGame()
    {

    }

    // выйти из игры
    public void ExitGame()
    {
        Application.Quit();
    }
}
