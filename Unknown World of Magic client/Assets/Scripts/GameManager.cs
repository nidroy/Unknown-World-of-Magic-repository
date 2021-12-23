using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // выйти из игры
    public void ExitGame()
    {
        Application.Quit();
    }

    // сохранить игру
    public void SaveGame()
    {
        Server server = new Server();
        Debug.Log(server.SendingMessage("SaveGame"));
    }
}
