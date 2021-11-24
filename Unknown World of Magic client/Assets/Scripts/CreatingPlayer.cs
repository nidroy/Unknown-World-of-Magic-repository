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
        if(server.SendingMessage("SetClassPlayer") == "SetNumberClassPlayer")
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
    private void SetPlayerName(Text namePlayer)
    {
        ConnectionServer server = new ConnectionServer();
        if (server.SendingMessage("SetPlayerName") == "SetPlayerName")
        {
            Debug.Log(server.SendingMessage(SetName(namePlayer)));
            PrintPlayerName(SetName(namePlayer));
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
    public void StartGame(Text namePlayer)
    {
        SetPlayerName(namePlayer);
        SetInitialCharacteristics();
        SetInitialAttributesPlayer();
        SetInitialLocationInformation();
        SetInitialAttributesNPC();
        SetFinishCreatingPlayer();
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

    #region PlayerAttributes

    public Player player; // �����

    // ���������� ��������� �������� ������
    private void SetInitialAttributesPlayer()
    {
        player.SetHealthPoints(100);
        player.SetActionPoints(100);
        player.SetSkillPoints(0);
        player.SetExperiencePoints(0);
        player.SetPlayerLevel(1);
        player.SetPlayerGold(0);
    }

    #endregion

    #region Characteristics

    public Characteristics characteristics; // ��������������

    // ���������� ��������� ��������������
    private void SetInitialCharacteristics()
    {
        characteristics.ShowCharacteristics();
        characteristics.SetStrength(10);
        characteristics.SetAgility(10);
        characteristics.SetIntelligence(10);
        characteristics.HideCharacteristics();
    }

    #endregion

    #region LocationInformation

    public Locations locations; // �������

    // ���������� ��������� ���������� � �������
    private void SetInitialLocationInformation()
    {
        locations.GetNameLocation();
        locations.GetTextLocation();
    }

    #endregion

    #region StartCreatingPlayer
    
    // ���������� ������ �������� ������
    public void SetStartCreatingPlayer()
    {
        ConnectionServer server = new ConnectionServer();
        Debug.Log(server.SendingMessage("SetStartCreatingPlayer"));
    }

    #endregion

    #region FinishCreatingPlayer

    // ���������� ����� �������� ������
    private void SetFinishCreatingPlayer()
    {
        ConnectionServer server = new ConnectionServer();
        Debug.Log(server.SendingMessage("SetFinishCreatingPlayer"));
    }

    #endregion

    #region NPCAttributes

    public NPC npc;

    // ���������� ��������� �������� NPC
    private void SetInitialAttributesNPC()
    {
        npc.PrintNPCName();
        npc.SetHealthPoints(100);
        npc.PrintNPCLevel();
        npc.SetNPCClass();
    }

    #endregion
}
