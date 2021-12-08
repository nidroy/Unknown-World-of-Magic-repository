using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Characteristics : MonoBehaviour
{
    public Text strength; // ����
    public Text agility; // ��������
    public Text intelligence; // ���������
    public Animator characteristicsAnim; // �������� �������������
    public Player player; // �����

    #region SetCharacteristics

    // ���������� ���� ������
    public void SetStrength(int playerStrength)
    {
        strength.text = playerStrength.ToString();
    }

    // ���������� �������� ������
    public void SetAgility(int playerAgility)
    {
        agility.text = playerAgility.ToString();
    }

    // ���������� ��������� ������
    public void SetIntelligence(int playerIntelligence)
    {
        intelligence.text = playerIntelligence.ToString();
    }

    #endregion

    // ��������, ������ ��������������
    public void ShowHideCharacteristics()
    {
        characteristicsAnim.SetBool("isShow", !characteristicsAnim.GetBool("isShow"));  
    }

    // ��������� ����
    public void IncreaseStrength()
    {
        Server server = new Server(); // ������

        string[] attribute = server.SendingMessage("IncreaseStrength").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

        SetStrength(int.Parse(attribute[0]));
        player.SetMaximumCharacterHealthPoints(int.Parse(attribute[1]));
        player.SetPlayerSkillPoints(int.Parse(attribute[2]));
    }

    // ��������� ��������
    public void IncreaseAgility()
    {
        Server server = new Server(); // ������

        string[] attribute = server.SendingMessage("IncreaseAgility").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

        SetAgility(int.Parse(attribute[0]));
        player.SetPlayerSkillPoints(int.Parse(attribute[1]));
    }

    // ��������� ���������
    public void IncreaseIntelligence()
    {
        Server server = new Server(); // ������

        string[] attribute = server.SendingMessage("IncreaseIntelligence").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

        SetIntelligence(int.Parse(attribute[0]));
        player.SetMaximumPlayerActionPoints(int.Parse(attribute[1]));
        player.SetPlayerSkillPoints(int.Parse(attribute[2]));
    }
}
