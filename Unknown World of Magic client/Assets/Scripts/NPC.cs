using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NPC : MonoBehaviour
{
    #region SetAttributes

    // ���������� ���� ��������
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

    public Text nameNPC; // ���� ������ �������� NPC
    public Image healthPoints; // ���� ������ ����� ��������
    public Text NPCLevel; // ���� ������ ������ NPC

    // ������� �������� NPC
    public void PrintNPCName()
    {
        ConnectionServer server = new ConnectionServer();
        nameNPC.text = server.SendingMessage("SetNPCName");
    }

    // ������� �� ����� ���� ��������
    public void PrintHealthPoints(int HP, int maxHP)
    {
        healthPoints.fillAmount = (float)HP / (float)maxHP;
    }

    // ������� �� ����� ������� NPC
    public void PrintNPCLevel()
    {
        ConnectionServer server = new ConnectionServer();
        NPCLevel.text = server.SendingMessage("SetNPCLevel");
    }

    #endregion

    #region Fight

    public static bool isFight = false; // ����������� ���������
    public Player player; // �����

    // ����� NPC
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

    // ���� NPC
    public void BlockNPC()
    {
        if (isFight)
        {
            if (UnityEngine.Random.Range(0, 100) < 70)
            {
                Player.isFight = false;
                Debug.Log("����� ������ ��������������");
            }

            isFight = false;
        }       
    }

    #endregion

    #region ClassNPC

    public Sprite[] inputClassNPC; // ����������� ������� NPC

    public Image outputClassNPC; // ���� ������ ������ ������

    // ���������� ����� NPC
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
