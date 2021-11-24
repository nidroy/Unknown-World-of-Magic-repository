using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NPC : MonoBehaviour
{
    #region SetAttributes

    // установить очки здоровья
    public void SetHealthPoints(int HP)
    {
        ConnectionServer server = new ConnectionServer();
        if(server.SendingMessage("SetNPCHealthPoints") == "SetNumberNPCHealthPoints")
        {
            Debug.Log(server.SendingMessage(HP.ToString()));
        }
        PrintHealthPoints(HP, 100);
    }

    #endregion

    #region PrintAttributes

    public Text nameNPC; // окно вывода названия NPC
    public Image healthPoints; // окно вывода очков здоровья
    public Text NPCLevel; // окно вывода уровня NPC

    // вывести название NPC
    public void PrintNPCName()
    {
        ConnectionServer server = new ConnectionServer();
        nameNPC.text = server.SendingMessage("SetNPCName");
    }

    // вывести на экран очки здоровья
    public void PrintHealthPoints(int HP, int maxHP)
    {
        healthPoints.fillAmount = (float)HP / (float)maxHP;
    }

    // вывести на экран уровень NPC
    public void PrintNPCLevel()
    {
        ConnectionServer server = new ConnectionServer();
        NPCLevel.text = server.SendingMessage("SetNPCLevel");
    }

    #endregion

    #region Fight

    public static bool isFight = false; // возможность атаковать
    public Player player; // игрок

    // атака NPC
    public void AttackNPC()
    {
        if (isFight)
        {
            if (UnityEngine.Random.Range(0, 100) < 80)
            {
                int damage = 0;
                int newHealthPoints = 0;
                ConnectionServer server = new ConnectionServer();

                damage = Convert.ToInt32(server.SendingMessage("SetNPCDamage"));
                if (server.SendingMessage("AttackNPC") == "SetDamageNPCAttack")
                {
                    newHealthPoints = (Convert.ToInt32(server.SendingMessage(damage.ToString())));
                }
                player.SetHealthPoints(newHealthPoints);
            }
            isFight = false;
        }      
    }

    // блок NPC
    public void BlockNPC()
    {
        if (isFight)
        {
            if (UnityEngine.Random.Range(0, 100) < 70)
            {
                Player.isFight = false;
                Debug.Log("атака игрока заблокированна");
            }

            isFight = false;
        }       
    }

    #endregion

    #region ClassNPC

    public Sprite[] inputClassNPC; // изображения классов NPC

    public Image outputClassNPC; // окно вывода класса игрока

    // установить класс NPC
    public void SetNPCClass()
    {
        if(nameNPC.text == "Bandit")
        {
            outputClassNPC.sprite = inputClassNPC[0];
        }
        else if(nameNPC.text == "Leshii")
        {
            outputClassNPC.sprite = inputClassNPC[1];
        }
    }

    #endregion
}
