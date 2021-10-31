using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trading : MonoBehaviour
{
    public Animator tradingWindowAnim; // анимация окна торговли
    public NPC npc; // неигровой персонаж
    public Sprite[] itemsSoldSprite; // все предметы на продажу
    public Image[] itemsSoldImage; // поле вывода предметов на продажу

    private void Update()
    {
        OpenTradingWindow();
    }

    #region OpenClose
    
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

    #endregion

    // установить предметы на продажу в зависимости от класса персонажа
    public void SetItemsSold(int numberInitialItem)
    {
        for(int i = 0; i < 8; i++)
        {
            itemsSoldImage[i].sprite = itemsSoldSprite[i + numberInitialItem];
        }
    }
}
