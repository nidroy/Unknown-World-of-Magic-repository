using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Menu menu; // меню
    public Image clockImage; // поле вывода линии времени
    public Text clockText; // поле вывода времени
    public float seconds = 11; // секунды
    public Player player; // главный герой
    public NPC enemy; // враг
    public bool isStop; // остановка таймера

    private void Update()
    {
        Timer();
    }

    // таймер
    public void Timer()
    {
        seconds -= Time.deltaTime;
        PrintTimer();
        ResetTimer();
        StopTimer();
    }

    // вывод времени на экран
    private void PrintTimer()
    {
        clockImage.fillAmount = seconds / 11;
        clockText.text = ((int)seconds).ToString();
    }
    
    // сброс таймера
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

    // остановить таймер
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
