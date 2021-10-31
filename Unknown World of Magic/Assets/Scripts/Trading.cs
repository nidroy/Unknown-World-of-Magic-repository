using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trading : MonoBehaviour
{
    public Animator tradingWindowAnim; // �������� ���� ��������
    public NPC npc; // ��������� ��������
    public Sprite[] itemsSoldSprite; // ��� �������� �� �������
    public Image[] itemsSoldImage; // ���� ������ ��������� �� �������

    private void Update()
    {
        OpenTradingWindow();
    }

    #region OpenClose
    
    // ������� ���� ��������
    public void OpenTradingWindow()
    {
        if(npc.isTrades)
        {
            tradingWindowAnim.SetBool("isOpen", true);
        }
    }

    // ������� ���� ��������
    public void CloseTradingWindow()
    {
        if(npc.isTrades)
        {
            npc.SetTrades(false);
            tradingWindowAnim.SetBool("isOpen", false);
        }
    }

    #endregion

    // ���������� �������� �� ������� � ����������� �� ������ ���������
    public void SetItemsSold(int numberInitialItem)
    {
        for(int i = 0; i < 8; i++)
        {
            itemsSoldImage[i].sprite = itemsSoldSprite[i + numberInitialItem];
        }
    }
}
