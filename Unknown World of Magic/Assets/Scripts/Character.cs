using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public string characterName; // имя персонажа
    public Text characterNameText; // поле вывода имени персонажа
    public string characterGender; // пол персонажа
    public Image characterClassImage; // поле вывода класса персонажа
    public int maximumCharacterHP = 100; // максимальное HP персонажа
    public float characterHP = 100; // HP персонажа
    public Image characterHPImage; // линия HP персонажа
    public int characterLevel = 1; // уровень персонажа
    public Text characterLevelText; // поле вывода уровня персонажа
    public int characterDamage; // урон персонажа
    public bool isFight = false; // сражение
    public Location location; // локация
    public float characterXP; // XP персонажа
    public int characterMiss; // промахи персонажа 
    public Sprite[] inputCharacterFrame; // поля ввода рамок вокруг персонажа
    public Image outputCharacterFrame; // поле вывода рамки вокруг персонажа

    #region Name

    // установить имя персонажа
    public void SetNameCharacter(string name)
    {
        characterName = name;
        PrintNameCharacter(name);
    }

    // вывести имя персонажа на экран
    private void PrintNameCharacter(string name)
    {
        characterNameText.text = name;
    }

    #endregion

    #region Gender

    // установить пол персонажа
    public void SetGenderCharacter(string gender)
    {
        characterGender = gender;
    }

    #endregion

    #region Class

    // вывести класс персонажа на экран
    public void PrintClassCharacter(Image classImage)
    {
        characterClassImage.sprite = classImage.sprite;
    }

    #endregion

    #region HP

    // регенерация HP
    public void RegenerationHP(float regeneration)
    {
        if(characterHP < maximumCharacterHP && characterHPImage.fillAmount <= characterHP / maximumCharacterHP)
        {
            characterHP += regeneration;
            characterHPImage.fillAmount += regeneration / maximumCharacterHP;
        }
    }

    // понижение HP
    public void LoweringHP()
    {
        if(characterHPImage.fillAmount > characterHP / maximumCharacterHP)
        {
            characterHPImage.fillAmount -= Time.deltaTime;
        }
    }

    // установить HP персонажа
    public void SetHPCharacter(int HP)
    {
        characterHP = HP;
    }

    #endregion

    #region Level

    // установить уровень персонажа
    public void SetLevelCharacter(int level)
    {
        characterLevel = level;
        PrintLevelCharacter(level);
    }

    // вывести уровень персонажа на экран
    private void PrintLevelCharacter(int level)
    {
        characterLevelText.text = level.ToString();
    }

    #endregion

    #region Damage

    // установить урон персонажа
    public void SetDamageCharacter(int minDamage, int maxDamage)
    {
        characterDamage = Random.Range(minDamage, maxDamage);
    }

    // получить урон
    public void TakeDamage(int Damage)
    {
        characterHP -= Damage;
    }

    #endregion

    #region Miss

    // установить промахи персонажа
    public void SetMissCharacter(int miss)
    {
        characterMiss = miss;
    }

    #endregion

    #region Battle

    // начать или закончить сражение
    public void StartEndBattle(bool isStartEnd)
    {
        if (location.locationNumber != 0)
        {
            isFight = isStartEnd;
        }
    }

    #endregion

    #region Death

    // смерть персонажа
    public abstract void DeathCharacter();

    #endregion

    #region Frame

    // установить рамку персонажа в зависимости от уровня
    public void SetFrameCharacter()
    {
        if(characterLevel < 40)
        {
            outputCharacterFrame.sprite = inputCharacterFrame[0];
        }
        else if(characterLevel < 80)
        {
            outputCharacterFrame.sprite = inputCharacterFrame[1];
        }
        else
        {
            outputCharacterFrame.sprite = inputCharacterFrame[2];
        }
    }

    #endregion
}
