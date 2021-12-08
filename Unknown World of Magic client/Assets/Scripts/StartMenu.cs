using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public Animator gameAnim; // �������� ����

    // ������ ����� ����
    public void StartNewGame()
    {
        gameAnim.SetBool("isShowCreatingPlayer", true);
    }

    // ���������� ����
    public void ContinueGame()
    {

    }

    // ����� �� ����
    public void ExitGame()
    {
        Application.Quit();
    }
}
