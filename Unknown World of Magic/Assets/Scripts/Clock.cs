using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Menu menu; // ����
    public Image clockImage; // ���� ������ ����� �������
    public Text clockText; // ���� ������ �������
    public float seconds = 11; // �������
    public Player player; // ������� �����
    public NPC enemy; // ����
    public bool isStop; // ��������� �������

    private void Update()
    {
        Timer();
    }

    // ������
    public void Timer()
    {
        seconds -= Time.deltaTime;
        PrintTimer();
        ResetTimer();
        StopTimer();
    }

    // ����� ������� �� �����
    private void PrintTimer()
    {
        clockImage.fillAmount = seconds / 11;
        clockText.text = ((int)seconds).ToString();
    }
    
    // ����� �������
    private void ResetTimer()
    {
        if(seconds <= 0)
        {
            seconds = 11;
            player.StartEndBattle(true);
            player.SetDodge(true);
            player.SetDodgeBlow(false);
            enemy.StartEndBattle(true);
        }
    }

    // ���������� ������
    private void StopTimer()
    {
        if(isStop)
        {
            isStop = false;
            menu.SetVisibilityButtonFirstAction(false);
            menu.SetVisibilityButtonSecondAction(false);
            menu.SetVisibilityButtonInteractionNPC(true);
            menu.SetVisibilityClock(false);
        }
    }
}
