using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RegistrationMenu : MonoBehaviour
{
    public Text[] className; // ����� �������
    public Text defaultPlayerName; // ��� ������ �� ���������

    public Animator gameAnim; // �������� ����
    public Player player; // �����
    public Characteristics characteristics; // ��������������
    public Location location; // �������
    public Enemy enemy; // ����
    public GameObject MessageBox;

    // ������ ����
    public void StartGame()
    {
        if (player.playerClass != "")
        {
            Server server = new Server();
            string response = server.SendingMessage("CreatePlayer");
            if (response == "PlayerExists")
            {
                MessageBox.SetActive(true);
            }
            else
            {
                gameAnim.SetBool("isShowCreatingPlayer", false);
            }
        }
    }

    // �������� �������� ���������
    public void GetCharacterAttributes(string command)
    {
        Server server = new Server(); // ������

        string[] attribute = server.SendingMessage(command).Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
       
        player.SetPlayerClass(attribute[0]);
        player.SetMaximumCharacterHealthPoints(int.Parse(attribute[1]));
        player.SetCharacterHealthPoints(int.Parse(attribute[1]));
        player.SetMaximumPlayerActionPoints(int.Parse(attribute[2]));
        player.SetPlayerActionPoints(int.Parse(attribute[2]));
        player.SetMaximumPlayerExperiencePoints(100);
        player.SetPlayerExperiencePoints(int.Parse(attribute[3]));
        player.SetPlayerSkillPoints(int.Parse(attribute[4]));
        player.SetCharacterLevel(int.Parse(attribute[5]));
        player.SetPlayerGold(int.Parse(attribute[6]));

        characteristics.SetStrength(int.Parse(attribute[7]));
        characteristics.SetAgility(int.Parse(attribute[8]));
        characteristics.SetIntelligence(int.Parse(attribute[9]));
    }

    // ���������� ���� ����� ������
    public void SetColorClassName(int numberClassName)
    {
        ResetColorClassNames();
        className[numberClassName].color = new Color(1, 0.8431373f, 0);
    }

    // �������� ���� ��� �������
    private void ResetColorClassNames()
    {
        for(int i = 0; i < className.Length; i ++)
        {
            className[i].color = new Color(0.5882353f, 0.5882353f, 0.5882353f);
        }
    }

    // ���������� ��� ������
    public void SetPlayerName(Text playerName)
    {
        Server server = new Server();
        string name = "";

        if (playerName.text == "")
        {
            name = defaultPlayerName.text;
        }
        else
        {
            name = playerName.text;
        }

        player.SetCharacterName(server.SendingMessage("SetPlayerName" + "_" + name));
    }

    // ���������� ����������� ������
    public void SetPlayerIcon(Image classIcon)
    {
        player.SetCharacterIcon(classIcon.sprite);
    }

    // ������� MessageBox
    public void CloseMessageBox()
    {
        MessageBox.SetActive(false);
    }
}
