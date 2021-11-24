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
    public Animator characteristicsAnim; // анимации окна характеристик
    public Player player; // игрок

    // показать характеристики
    public void ShowCharacteristics()
    {
        ConnectionServer server = new ConnectionServer();
        Debug.Log(server.SendingMessage("ShowCharacteristics"));
    }

    // установить силу
    public void SetStrength(int numberStrength)
    {
        ConnectionServer server = new ConnectionServer();
        if(server.SendingMessage("SetStrength") == "SetNumberStrength")
        {
            Debug.Log(server.SendingMessage(numberStrength.ToString()));
            strength.text = numberStrength.ToString();
        }
    }

    // установиь ловкость
    public void SetAgility(int numberAgility)
    {
        ConnectionServer server = new ConnectionServer();
        if(server.SendingMessage("SetAgility") == "SetNumberAgility")
        {
            Debug.Log(server.SendingMessage(numberAgility.ToString()));
            agility.text = numberAgility.ToString();
        }
    }

    // установить интеллект
    public void SetIntelligence(int numberIntelligence)
    {
        ConnectionServer server = new ConnectionServer();
        if(server.SendingMessage("SetIntelligence") == "SetNumberIntelligence")
        {
            Debug.Log(server.SendingMessage(numberIntelligence.ToString()));
            intelligence.text = numberIntelligence.ToString();
        }
    }

    // скрыть характеристики
    public void HideCharacteristics()
    {
        ConnectionServer server = new ConnectionServer();
        Debug.Log(server.SendingMessage("HideCharacteristics"));
    }

    // установить видимость характеристик
    public void SetVisibilityCharacteristics()
    {
        if (characteristicsAnim.GetBool("isShow"))
        {
            characteristicsAnim.SetBool("isShow", false);
            HideCharacteristics();
        }
        else
        {
            characteristicsAnim.SetBool("isShow", true);
            ShowCharacteristics();
        }
    }

    // повысить силу
    public void UpStrength()
    {
        if (Convert.ToInt32(player.skillPoints.text) > 0)
        {
            SetStrength(Convert.ToInt32(strength.text) + 1);
            player.SetSkillPoints(Convert.ToInt32(player.skillPoints.text) - 1);
            player.SetHealthPoints(Convert.ToInt32(strength.text) * 10);
        }
    }

    // повысить ловкость
    public void UpAgility()
    {
        if (Convert.ToInt32(player.skillPoints.text) > 0)
        {
            SetAgility(Convert.ToInt32(agility.text) + 1);
            player.SetSkillPoints(Convert.ToInt32(player.skillPoints.text) - 1);
        }
    }

    // повысить интеллект
    public void UpIntelligence()
    {
        if (Convert.ToInt32(player.skillPoints.text) > 0)
        {
            SetIntelligence(Convert.ToInt32(intelligence.text) + 1);
            player.SetSkillPoints(Convert.ToInt32(player.skillPoints.text) - 1);
            player.SetActionPoints(Convert.ToInt32(intelligence.text) * 10);
        }
    }
}
