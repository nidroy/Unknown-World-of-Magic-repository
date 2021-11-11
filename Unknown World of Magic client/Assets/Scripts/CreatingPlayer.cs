using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatingPlayer : MonoBehaviour
{
    #region ClassPlayer

    public Text[] nameClassPlayer; // �������� ������� ������

    // ���������� ����� ������
    public void SetPlayerClass(int numberClassPlayer)
    {
        ConnectionServer server = new ConnectionServer();
        string serverResponse = ""; // ����� �������
        serverResponse = server.SendingMessage("SetClassPlayer");
        if(serverResponse == "SetNumberClassPlayer")
        {
            Debug.Log(server.SendingMessage(numberClassPlayer.ToString()));
            PrintPlayerClass(numberClassPlayer);
            SetColourPlayerClass(numberClassPlayer);
        }
    }

    // ���������� ���� �������� ������ ������
    private void SetColourPlayerClass(int numberClassPlayer)
    {
        for(int i = 0; i < nameClassPlayer.Length; i++)
        {
            nameClassPlayer[i].color = new Color(255, 255, 255);
        }

        nameClassPlayer[numberClassPlayer].color = new Color(255, 215, 0);
    }

    #endregion

    #region PlayerName

    public Text defaultNamePlayer; // ����������� ��� ������

    // ���������� ��� ������
    public void SetPlayerName(Text namePlayer)
    {
        ConnectionServer server = new ConnectionServer();
        string serverResponse = ""; // ����� �������
        serverResponse = server.SendingMessage("SetPlayerName");
        if (serverResponse == "SetPlayerName")
        {
            Debug.Log(server.SendingMessage(SetName(namePlayer)));
            PrintPlayerName(SetName(namePlayer));
            StartGame();
        }
    }

    // ���������� ����������� ��� �������� ��� ������
    private string SetName(Text namePlayer)
    {
        if(namePlayer.text == "")
        {
            return defaultNamePlayer.text;
        }
        return namePlayer.text;
    }

    #endregion

    #region StartGame

    public Animator startGameAnim; // �������� ������ ����

    // ������ ����
    private void StartGame()
    {
        startGameAnim.SetBool("isStartGame", true);
    }

    #endregion

    #region PrintPlayer

    public Sprite[] inputClassPlayer; // ����������� ������� ������
    public Sprite[] inputActionPointsLine; // ����������� ����� ����� ��������

    public Text outputNamePlayer; // ���� ������ ����� ������
    public Image outputClassPlayer; // ���� ������ ������ ������
    public Image outputActionPointsLine; // ���� ������ ����� ����� ��������

    // ������� �� ����� ��� ������
    private void PrintPlayerName(string namePlayer)
    {
        outputNamePlayer.text = namePlayer;
    }

    // ������� �� ����� ����������� ������ ������
    private void PrintPlayerClass(int numberClassPlayer)
    {
        outputClassPlayer.sprite = inputClassPlayer[numberClassPlayer];
        PrintLineActionPoints(numberClassPlayer);
    }

    // ������� �� ����� ����������� ����� ����� ��������
    private void PrintLineActionPoints(int numberActionPointsLine)
    {
        outputActionPointsLine.sprite = inputActionPointsLine[numberActionPointsLine];
    }

    #endregion
}
