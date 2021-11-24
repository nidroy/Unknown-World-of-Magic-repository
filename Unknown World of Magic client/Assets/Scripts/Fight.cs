using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    public GameObject[] fightControlButton; // ������ ���������� ���������

    // ���������� ������ ��������
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

    // ���������� ����� ��������
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

    // ������� ������ ���������� ��������� �������
    private void MakeFightControlButtonVisible(int buttonNumber)
    {
        fightControlButton[buttonNumber].SetActive(true);
    }

    // ������� ������ ���������� ��������� ���������
    private void MakeFightControlButtonInvisible(int buttonNumber)
    {
        fightControlButton[buttonNumber].SetActive(false);
    }

    #endregion

    #region Timer

    public GameObject timer; // ������
    public Text time; // �����
    public Image timeLine; // ����� �������
    private bool isTimeReport = false; // ������ ������� �����
    private float seconds; // �������
    private int timeFight; // ����� �����
    public NPC npc; // NPC

    // ���������� ��������� �������
    private void SetTimerVisibility(bool isVisible)
    {
        timer.SetActive(isVisible);
        isTimeReport = isVisible;
    }

    // ���������� ������ �������
    private void SetTimerStart()
    {
        timeLine.fillAmount = 1;
        seconds = 10;
        time.text = ((int)seconds).ToString();
        timeFight = Random.Range(0, 10);
        NPC.isFight = true;
        Player.isFight = true;
    }

    // ���������� ������ �������
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
