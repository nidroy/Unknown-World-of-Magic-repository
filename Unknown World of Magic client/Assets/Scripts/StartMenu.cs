using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public Animator gameAnim; // �������� ����
    public ScrollViewAdapter adapter; // ������� ��

    // ������ ����� ����
    public void StartNewGame()
    {
        gameAnim.SetBool("isShowCreatingPlayer", true);
    }

    // ���������� ����
    public void ContinueGame()
    {
        gameAnim.SetBool("isShowContinue", true);
        adapter.UpdateItems();
    }
}
