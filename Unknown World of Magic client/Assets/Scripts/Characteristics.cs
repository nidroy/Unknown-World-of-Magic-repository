using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Characteristics : MonoBehaviour
{
    public Text strength; // сила
    public Text agility; // ловкость
    public Text intelligence; // интеллект
    public Animator characteristicsAnim; // анимации характеристик
    public Player player; // игрок

    #region SetCharacteristics

    // установить силу игрока
    public void SetStrength(int playerStrength)
    {
        strength.text = playerStrength.ToString();
    }

    // установить ловкость игрока
    public void SetAgility(int playerAgility)
    {
        agility.text = playerAgility.ToString();
    }

    // установить интеллект игрока
    public void SetIntelligence(int playerIntelligence)
    {
        intelligence.text = playerIntelligence.ToString();
    }

    #endregion

    // показать, скрыть характеристики
    public void ShowHideCharacteristics()
    {
        characteristicsAnim.SetBool("isShow", !characteristicsAnim.GetBool("isShow"));  
    }

    // увеличить силу
    public void IncreaseStrength()
    {
        Server server = new Server(); // сервер

        string[] attribute = server.SendingMessage("IncreaseStrength").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

        SetStrength(int.Parse(attribute[0]));
        player.SetMaximumCharacterHealthPoints(int.Parse(attribute[1]));
        player.SetPlayerSkillPoints(int.Parse(attribute[2]));
    }

    // увеличить ловкость
    public void IncreaseAgility()
    {
        Server server = new Server(); // сервер

        string[] attribute = server.SendingMessage("IncreaseAgility").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

        SetAgility(int.Parse(attribute[0]));
        player.SetPlayerSkillPoints(int.Parse(attribute[1]));
    }

    // увеличить интеллект
    public void IncreaseIntelligence()
    {
        Server server = new Server(); // сервер

        string[] attribute = server.SendingMessage("IncreaseIntelligence").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

        SetIntelligence(int.Parse(attribute[0]));
        player.SetMaximumPlayerActionPoints(int.Parse(attribute[1]));
        player.SetPlayerSkillPoints(int.Parse(attribute[2]));
    }
}
