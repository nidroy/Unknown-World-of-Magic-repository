using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    public GameObject[] fightControlButton; // кнопки управления сражением

    // установить начало сражения
    public void SetStartFight()
    {
        ConnectionServer server = new ConnectionServer();
        Debug.Log(server.SendingMessage("SetStartFight"));
        MakeFightControlButtonInvisible(0);
        MakeFightControlButtonVisible(1);
        MakeFightControlButtonVisible(2);
        SetTimerVisibility(true);
        SetTimerStart();
    }

    // установить конец сражения
    public void SetFinishFight()
    {
        ConnectionServer server = new ConnectionServer();
        Debug.Log(server.SendingMessage("SetFinishFight"));
        MakeFightControlButtonVisible(0);
        MakeFightControlButtonInvisible(1);
        MakeFightControlButtonInvisible(2);
        SetTimerVisibility(false);
        NPC.isFight = false;
    }

    #region VisibilityFightControlButton

    // сделать кнопку управления сражением видимой
    private void MakeFightControlButtonVisible(int buttonNumber)
    {
        fightControlButton[buttonNumber].SetActive(true);
    }

    // сделать кнопку управления сражением невидимой
    private void MakeFightControlButtonInvisible(int buttonNumber)
    {
        fightControlButton[buttonNumber].SetActive(false);
    }

    #endregion

    #region Timer

    public GameObject timer; // таймер
    public Text time; // время
    public Image timeLine; // линия времени
    private bool isTimeReport = false; // отсчет времени пошёл
    private float seconds; // секунды
    private int timeFight; // время атаки
    public NPC npc; // NPC

    // установить видимость таймера
    private void SetTimerVisibility(bool isVisible)
    {
        timer.SetActive(isVisible);
        isTimeReport = isVisible;
    }

    // установить запуск таймера
    private void SetTimerStart()
    {
        timeLine.fillAmount = 1;
        seconds = 10;
        time.text = ((int)seconds).ToString();
        timeFight = Random.Range(0, 10);
        NPC.isFight = true;
        Player.isFight = true;
    }

    // установить отсчет времени
    private void Update()
    {
        if(isTimeReport)
        {
            seconds -= Time.deltaTime;
            time.text = ((int)seconds + 1).ToString();
            timeLine.fillAmount = seconds / 10;
            if((int)seconds == timeFight)
            {
                if (Random.Range(0, 100) < 30)
                {
                    npc.BlockNPC();
                }
                else
                {
                    npc.AttackNPC();
                }
            }
            if(timeLine.fillAmount == 0)
            {
                SetTimerStart();
            }
        }
    }

    #endregion
}
