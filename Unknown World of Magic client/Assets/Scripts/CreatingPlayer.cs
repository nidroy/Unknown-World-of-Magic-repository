using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatingPlayer : MonoBehaviour
{
    #region ClassPlayer

    public Text[] nameClassPlayer; // названия классов игрока

    // установить класс игрока
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

    // установить цвет названия класса игрока
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

    public Text defaultNamePlayer; // стандартное имя игрока

    // установить имя игрока
    private void SetPlayerName(Text namePlayer)
    {
        ConnectionServer server = new ConnectionServer();
        if (server.SendingMessage("SetPlayerName") == "SetPlayerName")
        {
            Debug.Log(server.SendingMessage(SetName(namePlayer)));
            PrintPlayerName(SetName(namePlayer));
        }
    }

    // установить стандартное или введённое имя игрока
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

    public Animator startGameAnim; // анимация начала игры

    // начать игру
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

    public Sprite[] inputClassPlayer; // изображения классов игрока
    public Sprite[] inputActionPointsLine; // изображения линий очков действий

    public Text outputNamePlayer; // окно вывода имени игрока
    public Image outputClassPlayer; // окно вывода класса игрока
    public Image outputActionPointsLine; // окно вывода линии очков действий

    // вывести на экран имя игрока
    private void PrintPlayerName(string namePlayer)
    {
        outputNamePlayer.text = namePlayer;
    }

    // вывести на экран изображение класса игрока
    private void PrintPlayerClass(int numberClassPlayer)
    {
        outputClassPlayer.sprite = inputClassPlayer[numberClassPlayer];
        PrintLineActionPoints(numberClassPlayer);
    }

    // вывести на экран изображение линии очков действий
    private void PrintLineActionPoints(int numberActionPointsLine)
    {
        outputActionPointsLine.sprite = inputActionPointsLine[numberActionPointsLine];
    }

    #endregion

    #region PlayerAttributes

    public Player player; // игрок

    // установить начальные атрибуты игрока
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

    public Characteristics characteristics; // характеристики

    // установить начальные характеристики
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

    public Locations locations; // локации

    // установить начальную информацию о локации
    private void SetInitialLocationInformation()
    {
        locations.GetNameLocation();
        locations.GetTextLocation();
    }

    #endregion

    #region StartCreatingPlayer
    
    // установить начало создания игрока
    public void SetStartCreatingPlayer()
    {
        ConnectionServer server = new ConnectionServer();
        Debug.Log(server.SendingMessage("SetStartCreatingPlayer"));
    }

    #endregion

    #region FinishCreatingPlayer

    // установить конец создания игрока
    private void SetFinishCreatingPlayer()
    {
        ConnectionServer server = new ConnectionServer();
        Debug.Log(server.SendingMessage("SetFinishCreatingPlayer"));
    }

    #endregion

    #region NPCAttributes

    public NPC npc;

    // установить начальные атрибуты NPC
    private void SetInitialAttributesNPC()
    {
        npc.PrintNPCName();
        npc.SetHealthPoints(100);
        npc.PrintNPCLevel();
        npc.SetNPCClass();
    }

    #endregion
}
