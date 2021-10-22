using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public string characterClass; // класс персонажа
    public int maximumCharacterXP = 100; // максимальное XP персонажа
    public Image characterXPImage; // линия XP персонажа
    public NPC npc; // неигровой персонаж
    public bool isDodgeCharacter; // возможно ли уклонение персонажа
    public bool isDodgingBlow; // возможно ли увернуться от удара врага

    private void Update()
    {
        SetMaximumHPCharacter(100 + characteristics.SetMaximumHPStrength());
        RegenerationHP(Time.deltaTime * (1 + (float)characteristics.strength / 10));
        LoweringHP();
        IncreaseLineXP();
        IncreaseLevelCharacter();
        ChangeDamageCharacter(characteristics.SetDamageCharacteristic(characterClass));
        TakeDamageEnemy(clock.seconds);
        DeathCharacter();
        SetFrameCharacter();
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

    #region Class

    // установить класс персонажа
    public void SetClassCharacter(int numberClass)
    {
        if(numberClass == 0)
        {
            characterClass = "Archer";
        }
        else if(numberClass == 1)
        {
            characterClass = "Warrior";
        }
        else if(numberClass == 2)
        {
            characterClass = "Magician";
        }
    }

    #endregion

    #region XP

    // установить XP персонажа
    public void SetXPCharacter(int XP)
    {
        characterXP += XP;
    }    

    // увеличить линию XP
    public void IncreaseLineXP()
    {
        if(characterXPImage.fillAmount < characterXP/maximumCharacterXP)
        {
            characterXPImage.fillAmount += Time.deltaTime;
        }
    }

    #endregion

    #region Level

    // повысить уровень персонажа
    public void IncreaseLevelCharacter()
    {
        if(characterXPImage.fillAmount == 1)
        {
            SetXPCharacter((int)characterXP - maximumCharacterXP);
            maximumCharacterXP *= 2;
            characterXPImage.fillAmount = 0;
            SetLevelCharacter(characterLevel + 1);
        }
    }

    #endregion

    #region Damage

    // получить урон от врага
    public void TakeDamageEnemy(float seconds)
    {
        SetMissCharacter(10);
        if(isDodgingBlow)
        {
            SetMissCharacter(50 - characteristics.miss);
        }
        if (isFight && seconds <= Random.Range(1, 8) && Random.Range(0, 100) < 100 - characterMiss)
        {
            TakeDamage(npc.characterDamage);
            isFight = false;
        }
    }

    // изменить урон персонажа
    public void ChangeDamageCharacter(int damage)
    {
        SetDamageCharacter(20 + damage, 60 + damage);
    }

    #endregion

    #region Dodge

    // увернуться от удара врага
    public void DodgeBlow()
    {
        if(isDodgeCharacter)
        {
            SetDodgeBlow(true);
            SetDodge(false);
            npc.StartEndBattle(false);
        }
    }

    // установить возможность персонажа уворачиваться 
    public void SetDodge(bool isDodge)
    {
        isDodgeCharacter = isDodge;
    }

    // установить возможность увернуться от врага
    public void SetDodgeBlow(bool isDodge)
    {
        isDodgingBlow = isDodge;
    }

    #endregion

    #region Death

    // смерть персонажа
    public override void DeathCharacter()
    {
        if (characterHPImage.fillAmount == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    #endregion
}
