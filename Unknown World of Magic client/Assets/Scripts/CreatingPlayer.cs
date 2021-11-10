using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatingPlayer : MonoBehaviour
{
    #region ClassPlayer

    public Text[] nameClassPlayer; // �������� ������� ������

    // ���������� ����� ������
    public void SetClassPlayer(int numberClassPlayer)
    {
        ConnectionServer server = new ConnectionServer();
        string serverResponse = ""; // ����� �������
        serverResponse = server.SendingMessage("SetClassPlayer");
        if(serverResponse == "SetNumberClassPlayer")
        {
            Debug.Log(server.SendingMessage(numberClassPlayer.ToString()));
            SetColourClassPlayer(numberClassPlayer);
        }
    }

    // ���������� ���� �������� ������ ������
    private void SetColourClassPlayer(int numberClassPlayer)
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
            HideCreatingPlayerWindow();
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

    #region HideWindow

    public GameObject windowCreatingPlayer; // ���� �������� ������

    // ������ ���� �������� ������
    private void HideCreatingPlayerWindow()
    {
        windowCreatingPlayer.SetActive(false);
    }

    #endregion
}
