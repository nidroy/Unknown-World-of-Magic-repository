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
        string serverResponse = ""; // ответ сервера
        serverResponse = server.SendingMessage("SetClassPlayer");
        if(serverResponse == "SetNumberClassPlayer")
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
    public void SetPlayerName(Text namePlayer)
    {
        ConnectionServer server = new ConnectionServer();
        string serverResponse = ""; // ответ сервера
        serverResponse = server.SendingMessage("SetPlayerName");
        if (serverResponse == "SetPlayerName")
        {
            Debug.Log(server.SendingMessage(SetName(namePlayer)));
            PrintPlayerName(SetName(namePlayer));
            StartGame();
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
    private void StartGame()
    {
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
}
