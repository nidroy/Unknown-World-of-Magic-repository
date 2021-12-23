using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RegistrationMenu : MonoBehaviour
{
    public Text[] className; // имена классов
    public Text defaultPlayerName; // имя игрока по умолчанию

    public Animator gameAnim; // анимации игры
    public Player player; // игрок
    public Characteristics characteristics; // характеристики
    public Location location; // локация
    public Enemy enemy; // враг
    public GameObject MessageBox;

    // начать игру
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

    // получить атрибуты персонажа
    public void GetCharacterAttributes(string command)
    {
        Server server = new Server(); // сервер

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

    // установить цвет имени класса
    public void SetColorClassName(int numberClassName)
    {
        ResetColorClassNames();
        className[numberClassName].color = new Color(1, 0.8431373f, 0);
    }

    // обнулить цвет имён классов
    private void ResetColorClassNames()
    {
        for(int i = 0; i < className.Length; i ++)
        {
            className[i].color = new Color(0.5882353f, 0.5882353f, 0.5882353f);
        }
    }

    // установить имя игрока
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

    // установить изображение игрока
    public void SetPlayerIcon(Image classIcon)
    {
        player.SetCharacterIcon(classIcon.sprite);
    }

    // закрыть MessageBox
    public void CloseMessageBox()
    {
        MessageBox.SetActive(false);
    }
}
