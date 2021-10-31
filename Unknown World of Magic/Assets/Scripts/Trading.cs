using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trading : MonoBehaviour
{
    public Animator tradingWindowAnim; // �������� ���� ��������
    public NPC npc; // ��������� ��������

    private void Update()
    {
        OpenTradingWindow();
    }

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
}
