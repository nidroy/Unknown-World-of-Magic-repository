using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public Animator startGameAnim; // �������� ������ ����

    // ������ ����� ����
    public void StartNewGame()
    {
        ConnectionServer server = new ConnectionServer();
        Debug.Log(server.SendingMessage("SetStartCreatingPlayer"));
        startGameAnim.SetBool("isCreatingPlayer", true);
    }

    // ���������� ����
    public void ContinueGame()
    {
        startGameAnim.SetBool("isContinue", true);
    }

    // ����� �� ����
    public void ExitGame()
    {
        Application.Quit();
    }
}
