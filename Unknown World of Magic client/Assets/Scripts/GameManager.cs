using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // ����� �� ����
    public void ExitGame()
    {
        Application.Quit();
    }

    // ��������� ����
    public void SaveGame()
    {
        Server server = new Server();
        Debug.Log(server.SendingMessage("SaveGame"));
    }
}
