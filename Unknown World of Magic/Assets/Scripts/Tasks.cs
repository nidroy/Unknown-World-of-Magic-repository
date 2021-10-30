using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    public GameObject[] tasks; // задания
    public Text[] taskText; // окно вывода текста заданий
    public GameObject[] flagCompletedTask; // флаг выполненного задания
    public bool[] isStartCompletingTask; // начать выполнять задания
    public bool[] isCompletingTask; // задание выполнено
    public int numberTask; // номер задания
    public NPC npc; // неигровой персонаж
    public Player player; // главный герой
    private bool isLastTaskCompleted; // выполнение последнего задания

    private void Update()
    {
        SetVisibilityFlag();
        SetVisibilityTasks();
        SetCompletingTask();
    }

    // вывести текст задания на экран
    private void PrintTextTask(string text)
    {
        taskText[numberTask].text = text;
    }

    // установить начало выполнения задания
    public void SetStartCompletingTask()
    {
        if (npc.isGivesTasks)
        {
            isStartCompletingTask[numberTask] = true;
            npc.SetNumberKilledNPC(0);
        }
    }

    // установить видимость окон вывода заданий
    public void SetVisibilityTasks()
    {
        if (isStartCompletingTask[numberTask])
        {
            tasks[numberTask].SetActive(true);
            PrintTextTask(SetTextTask());
        }
    }

    // установить видимость флага выполенного задания
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

    // установить текст задания
    private string SetTextTask()
    {
        string text = "";
        if(numberTask == 0)
        {
            text = "Убить 10 разбойников на поляне";
        }
        else if(numberTask == 1)
        {
            text = "Убить 5 леших в лесу";
        }
        else if(numberTask == 2)
        {
            text = "Убить 20 разбойников на поляне";
        }
        return text;
    }

    // установить выполнение задания
    public void SetCompletingTask()
    {
        if (isStartCompletingTask[numberTask] && GetNumberKilledNPC())
        {
            isCompletingTask[numberTask] = true;
        }
    }

    // получить количество убитых NPC 
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

    // получить награду за выполнение задания
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
