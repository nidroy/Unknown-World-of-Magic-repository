using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public Animator gameAnim; // анимации игры
    public ScrollViewAdapter adapter; // адаптер бд

    // начать новую игру
    public void StartNewGame()
    {
        gameAnim.SetBool("isShowCreatingPlayer", true);
    }

    // продолжить игру
    public void ContinueGame()
    {
        gameAnim.SetBool("isShowContinue", true);
        adapter.UpdateItems();
    }
}
