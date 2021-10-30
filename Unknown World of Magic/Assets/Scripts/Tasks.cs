using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    public GameObject[] tasks; // �������
    public Text[] taskText; // ���� ������ ������ �������
    public GameObject[] flagCompletedTask; // ���� ������������ �������
    public bool[] isStartCompletingTask; // ������ ��������� �������
    public bool[] isCompletingTask; // ������� ���������
    public int numberTask; // ����� �������
    public NPC npc; // ��������� ��������
    public Player player; // ������� �����
    private bool isLastTaskCompleted; // ���������� ���������� �������

    private void Update()
    {
        SetVisibilityFlag();
        SetVisibilityTasks();
        SetCompletingTask();
    }

    // ������� ����� ������� �� �����
    private void PrintTextTask(string text)
    {
        taskText[numberTask].text = text;
    }

    // ���������� ������ ���������� �������
    public void SetStartCompletingTask()
    {
        if (npc.isGivesTasks)
        {
            isStartCompletingTask[numberTask] = true;
            npc.SetNumberKilledNPC(0);
        }
    }

    // ���������� ��������� ���� ������ �������
    public void SetVisibilityTasks()
    {
        if (isStartCompletingTask[numberTask])
        {
            tasks[numberTask].SetActive(true);
            PrintTextTask(SetTextTask());
        }
    }

    // ���������� ��������� ����� ����������� �������
    public void SetVisibilityFlag()
    {
        if (isCompletingTask[numberTask])
        {
            flagCompletedTask[numberTask].SetActive(true);
            GetReward();
            if (numberTask < 2)
            {
                numberTask++;
            }
        }
    }

    // ���������� ����� �������
    private string SetTextTask()
    {
        string text = "";
        if(numberTask == 0)
        {
            text = "����� 10 ����������� �� ������";
        }
        else if(numberTask == 1)
        {
            text = "����� 5 ����� � ����";
        }
        else if(numberTask == 2)
        {
            text = "����� 20 ����������� �� ������";
        }
        return text;
    }

    // ���������� ���������� �������
    public void SetCompletingTask()
    {
        if (isStartCompletingTask[numberTask] && GetNumberKilledNPC())
        {
            isCompletingTask[numberTask] = true;
        }
    }

    // �������� ���������� ������ NPC 
    private bool GetNumberKilledNPC()
    {
        bool isTaskCompleted = false;
        if(numberTask == 0 && npc.numberKilledNPC[1] >= 10)
        {
            isTaskCompleted = true;
        }
        else if(numberTask == 1 && npc.numberKilledNPC[2] >= 5)
        {
            isTaskCompleted = true;
        }
        else if (numberTask == 2 && npc.numberKilledNPC[1] >= 20)
        {
            isTaskCompleted = true;
        }
        return isTaskCompleted;
    }

    // �������� ������� �� ���������� �������
    private void GetReward()
    {
        if(numberTask == 0)
        {
            player.SetGoldCharacter(100);
            player.SetXPCharacter(200);
        }
        else if(numberTask == 1)
        {
            player.SetGoldCharacter(100);
            player.SetXPCharacter(400);
        }
        else if(numberTask == 2 && !isLastTaskCompleted)
        {
            player.SetGoldCharacter(200);
            player.SetXPCharacter(400);
            isLastTaskCompleted = true;
        }
    }
}
