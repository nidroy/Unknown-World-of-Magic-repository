using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    #region SetAttributes

    public Characteristics characteristics; // ��������������

    // ���������� ���� ��������
    public void SetHealthPoints(int HP)
    {
        ConnectionServer server = new ConnectionServer();
        if(server.SendingMessage("SetHealthPoints") == "SetNumberHealthPoints")
        {
            Debug.Log(server.SendingMessage(HP.ToString()));
            PrintHealthPoints(HP, Convert.ToInt32(characteristics.strength.text) * 10);
        }
    }

    // ���������� ���� ��������
    public void SetActionPoints(int AP)
    {
        ConnectionServer server = new ConnectionServer();
        if(server.SendingMessage("SetActionPoints") == "SetNumberActionPoints")
        {
            Debug.Log(server.SendingMessage(AP.ToString()));
            PrintActionPoints(AP, Convert.ToInt32(characteristics.intelligence.text) * 10);
        }
    }

    // ���������� ���� �������
    public void SetSkillPoints(int SP)
    {
        ConnectionServer server = new ConnectionServer();
        if (server.SendingMessage("SetSkillPoints") == "SetNumberSkillPoints")
        {
            Debug.Log(server.SendingMessage(SP.ToString()));
        }
        PrintSkillPoints(SP);
    }

    // ���������� ���� �����
    public void SetExperiencePoints(int XP)
    {
        ConnectionServer server = new ConnectionServer();
        if (server.SendingMessage("SetExperiencePoints") == "SetNumberExperiencePoints")
        {
            Debug.Log(server.SendingMessage(XP.ToString()));
        }
        PrintExperiencePoints(XP, 100);
    }

    // ���������� ������� ������
    public void SetPlayerLevel(int level)
    {
        ConnectionServer server = new ConnectionServer();
        if(server.SendingMessage("SetPlayerLevel") == "SetLevel")
        {
            Debug.Log(server.SendingMessage(level.ToString()));
        }
        PrintPlayerLevel(level);
    }

    // ���������� ������ ������
    public void SetPlayerGold(int gold)
    {
        ConnectionServer server = new ConnectionServer();
        if (server.SendingMessage("SetPlayerGold") == "SetNumberGold")
        {
            Debug.Log(server.SendingMessage(gold.ToString()));
        }
        PrintPlayerGold(gold);
    }

    #endregion

    #region PrintAttributes

    public Image healthPoints; // ���� ������ ����� ��������
    public Image actionPoints; // ���� ������ ����� ��������
    public Text skillPoints; // ���� ������ ����� �������
    public Image experiencePoints; // ���� ������ ����� �����
    public Text playerLevel; // ���� ������ ������ ������
    public Text playerGold; // ���� ������ ������ ������

    // ������� �� ����� ���� ��������
    private void PrintHealthPoints(int HP, int maxHP)
    {
        healthPoints.fillAmount = (float)HP / (float)maxHP;
    }

    // ������� �� ����� ���� ��������
    private void PrintActionPoints(int AP, int maxAP)
    {
        actionPoints.fillAmount = (float)AP / (float)maxAP;
    }

    // ������� �� ����� ���� �������
    private void PrintSkillPoints(int SP)
    {
        skillPoints.text = SP.ToString();
    }

    // ������� �� ����� ���� �����
    private void PrintExperiencePoints(int XP, int maxXP)
    {
        experiencePoints.fillAmount = (float)XP / (float)maxXP;
    }

    // ������� �� ����� ������� ���������
    private void PrintPlayerLevel(int level)
    {
        playerLevel.text = level.ToString();
    }

    // ������� �� ����� ������ ������
    private void PrintPlayerGold(int gold)
    {
        playerGold.text = gold.ToString();
    }

    #endregion

    #region Fight

    public static bool isFight = false; // ����������� ��������� 
    public NPC npc; // NPC

    // ����� ������
    public void AttackPlayer()
    {
        if (isFight && (int)(actionPoints.fillAmount * 100) >= 10)
        {
            if (UnityEngine.Random.Range(0, 100) < 90)
            {
                int damage = 0;
                int newHealthPoints = 0;
                ConnectionServer server = new ConnectionServer();
                if (server.SendingMessage("SetPlayerDamage") == "SetNumberPlayerDamage")
                {
                    damage = Convert.ToInt32(server.SendingMessage("5"));
                }
                if (server.SendingMessage("AttackPlayer") == "SetDamagePlayerAttack")
                {
                    newHealthPoints = Convert.ToInt32(server.SendingMessage(damage.ToString()));
                }
                npc.SetHealthPoints(newHealthPoints);
            }

            SetActionPoints((int)(actionPoints.fillAmount * 100) - 10);
            isFight = false;
        }       
    }

    // ���� ������
    public void BlockPlayer()
    {
        if(isFight && (int)(actionPoints.fillAmount * 100) >= 15)
        {
            Characteristics characteristics = new Characteristics();
            if (UnityEngine.Random.Range(0, 100) < 40 + Convert.ToInt32(characteristics.agility.text))
            {
                NPC.isFight = false;
                Debug.Log("����� ����� ��������������");
            }

            SetActionPoints((int)(actionPoints.fillAmount * 100) - 15);
            isFight = false;
        }    
    }

    #endregion
}
