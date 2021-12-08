using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public Text characterName; // имя персонажа
    public Text characterLevel; // уровень персонажа
    public Image characterIcon; // иконка персонажа
    public Image characterHealthPoints; // очки здоровья персонажа
    public int maximumCharacterHealthPoints; // максимальные очки здоровья персонажа
    public bool isFight; // сражение персонажа

    #region SetCharacterAttributes

    // установить имя персонажа
    public void SetCharacterName(string name)
    {
        characterName.text = name;
    }

    // установить уровень персонажа
    public void SetCharacterLevel(int level)
    {
        characterLevel.text = level.ToString();
    }

    // установить изображение персонажа
    public void SetCharacterIcon(Sprite icon)
    {
        characterIcon.sprite = icon;
    }

    // установить очки здоровья персонажа
    public void SetCharacterHealthPoints(int healthPoints)
    {
        characterHealthPoints.fillAmount = (float)healthPoints / (float)maximumCharacterHealthPoints;
    }

    // установить максимальные очки здоровья персонажа
    public void SetMaximumCharacterHealthPoints(int maximumHealthPoints)
    {
        maximumCharacterHealthPoints = maximumHealthPoints;
    }

    // установить возможность сражаться
    public void SetAbilityFight(bool isCharacterFight)
    {
        isFight = isCharacterFight;
    }

    #endregion

    // атака персонажа
    public abstract void Attack();

    // смерть персонажа
    public abstract void Death();
}
