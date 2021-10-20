using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Character
{
    public Sprite[] characterClassSprite; // поля ввода классов персонажа
    public Location location; // локация
    public Player player;

    private void Update()
    {
        if(location.locationNumber == 0)
        {
            GuildHead();
        }
        else if(location.locationNumber == 1)
        {
            Outlaw();
        }
        else if(location.locationNumber == 2)
        {
            Leshii();
        }

        LoweringHP();
    }

    #region Class

    // установить класс персонажа в виде Image
    public Image SetClassCharacter(Sprite classSprite)
    {
        Image classImage = characterClassImage;
        classImage.sprite = classSprite;
        return classImage;
    }

    #endregion

    #region HP

    // установить HP NPC
    public void SetHPNPC()
    {
        if(location.locationNumber == 0)
        {
            SetHPCharacter(1000);
        }
        else if(location.locationNumber == 1)
        {
            SetHPCharacter(100);
        }
        else if(location.locationNumber == 2)
        {
            SetHPCharacter(200);
        }
        characterHPImage.fillAmount = 1;
    }

    #endregion

    #region Damage

    // получить урон от игрока
    public void TakeDamagePlayer()
    {
        TakeDamage(player.characterDamage);
    }

    #endregion

    // глава гильдии
    public void GuildHead()
    {
        SetNameCharacter("Глава гильдии");
        SetGenderCharacter("Мужчина");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[0]));
        SetLevelCharacter(100);
        maximumCharacterHP = 1000;
        RegenerationHP(Time.deltaTime * 100);
        SetDamageCharacter(800, 1000);
    }

    // разбойник
    public void Outlaw()
    {
        SetNameCharacter("Разбойник");
        SetGenderCharacter("Женщина");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[1]));
        SetLevelCharacter(5);
        maximumCharacterHP = 100;
        RegenerationHP(Time.deltaTime * 2);
        SetDamageCharacter(5, 10);
    }

    // леший
    public void Leshii()
    {
        SetNameCharacter("Леший");
        SetGenderCharacter("Мужчина");
        PrintClassCharacter(SetClassCharacter(characterClassSprite[2]));
        SetLevelCharacter(10);
        maximumCharacterHP = 200;
        RegenerationHP(Time.deltaTime * 4);
        SetDamageCharacter(10, 20);
    }
}
