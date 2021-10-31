using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trading : MonoBehaviour
{
    public Animator tradingWindowAnim; // анимация окна торговли
    public NPC npc; // неигровой персонаж

    private void Update()
    {
        OpenTradingWindow();
    }

    // открыть окно торговли
    public void OpenTradingWindow()
    {
        if(npc.isTrades)
        {
            tradingWindowAnim.SetBool("isOpen", true);
        }
    }

    // закрыть окно торговли
    public void CloseTradingWindow()
    {
        if(npc.isTrades)
        {
            npc.SetTrades(false);
            tradingWindowAnim.SetBool("isOpen", false);
        }
    }
}
