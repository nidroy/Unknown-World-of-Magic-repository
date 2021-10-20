using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public int maximumCharacterXP = 100; // максимальное XP персонажа
    public float characterXP = 0; // XP персонажа
    public Image characterXPImage; // линия XP персонажа
    public NPC npc; // неигровой персонаж

    private void Update()
    {
        RegenerationHP(Time.deltaTime);
        LoweringHP();
        IncreaseLineXP();
        IncreaseXP();
        SetDamageCharacter(5, 10);
    }

    #region Name

    // получить имя персонажа
    public void GetNameCharacter(Text nameText)
    {
        if (nameText.text == "")
        {
            SetNameCharacter("Player name");
        }
        else
        {
            SetNameCharacter(nameText.text);
        }
    }

    #endregion

    #region XP

    // получить XP
    public void GetXP(int XP)
    {
        characterXP = XP;
    }    

    // увеличить линию XP
    public void IncreaseLineXP()
    {
        if(characterXPImage.fillAmount < characterXP/maximumCharacterXP)
        {
            characterXPImage.fillAmount += Time.deltaTime;
        }
    }

    // повысить XP персонажа
    public void IncreaseXP()
    {
        if(characterXPImage.fillAmount == 1)
        {
            maximumCharacterXP *= 2;
            characterXPImage.fillAmount = 0;
            SetLevelCharacter(characterLevel + 1);
        }
    }

    #endregion

    #region Damage

    // получить урон от врага
    public void TakeDamageEnemy()
    {
        TakeDamage(npc.characterDamage);
    }

    #endregion
}
