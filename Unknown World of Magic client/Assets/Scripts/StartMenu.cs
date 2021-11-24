using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public Animator startGameAnim; // анимация начала игры

    // начать новую игру
    public void StartNewGame()
    {
        ConnectionServer server = new ConnectionServer();
        Debug.Log(server.SendingMessage("SetStartCreatingPlayer"));
        startGameAnim.SetBool("isCreatingPlayer", true);
    }

    // продолжить игру
    public void ContinueGame()
    {
        startGameAnim.SetBool("isContinue", true);
    }

    // выйти из игры
    public void ExitGame()
    {
        Application.Quit();
    }
}
