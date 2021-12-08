using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : Character
{
    public string playerClass; // класс игрока
    public Image playerActionPoints; // очки действий игрока
    public int maximumPlayerActionPoints; // максимальные очки действий игрока
    public Image playerExperiencePoints; // очки опыта игрока
    public int maximumPlayerExperiencePoints; // максимальные очки опыта игрока
    public Text playerSkillPoints; // очки навыков игрока
    public Text playerGold; // золото игрока
    public Enemy enemy; // враг
    public Characteristics characteristics; // характеристики
    public bool isRestoring; // восстановление очков здоровья
    private float secondsRestoringHealthPoints = 0; // секунды восстанавления очка здоровья
    private float secondsRestoringActionPoints = 0; // секудны восстановления очка действия

    #region SetPlayerAttributes

    // установить класс игрока
    public void SetPlayerClass(string characterClass)
    {
        playerClass = characterClass;
    }

    // установить очки действий игрока
    public void SetPlayerActionPoints(int actionPoints)
    {
        playerActionPoints.fillAmount = (float)actionPoints / (float)maximumPlayerActionPoints;
    }

    // установить максимальные очки действий игрока
    public void SetMaximumPlayerActionPoints(int maximumActionPoints)
    {
        maximumPlayerActionPoints = maximumActionPoints;
    }

    // установить очки опыта игрока
    public void SetPlayerExperiencePoints(int experiencePoints)
    {
        playerExperiencePoints.fillAmount = (float)experiencePoints / (float)maximumPlayerExperiencePoints;
    }

    // установить максимальные очки опыта игрока
    public void SetMaximumPlayerExperiencePoints(int maximumExperiencePoints)
    {
        maximumPlayerExperiencePoints = maximumExperiencePoints;
    }

    // установить очки навыков игрока
    public void SetPlayerSkillPoints(int skillPoints)
    {
        playerSkillPoints.text = skillPoints.ToString();
    }

    // установить золото игрока
    public void SetPlayerGold(int gold)
    {
        playerGold.text = gold.ToString();
    }

    // установить возможность восстановления
    public void SetAbilityRestoring(bool isPlayerRestoring)
    {
        isRestoring = isPlayerRestoring;
    }

    #endregion

    // атака игрока
    public override void Attack()
    {
        if(isFight)
        {
            Server server = new Server(); // сервер

            string[] attribute = server.SendingMessage("PlayerAttack").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            enemy.SetCharacterHealthPoints(int.Parse(attribute[0]));
            SetPlayerActionPoints(int.Parse(attribute[1]));

            isFight = false;
        }
    }

    // смерть игрока
    public override void Death()
    {
        if (characterHealthPoints.fillAmount == 0)
        {

        }
    }

    //увеличить уровень игрока
    public void IncreaseLevel()
    {
        if(playerExperiencePoints.fillAmount == 1)
        {
            Server server = new Server(); // сервер

            string[] attribute = server.SendingMessage("IncreaseLevel").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            SetCharacterLevel(int.Parse(attribute[0]));
            SetPlayerSkillPoints(int.Parse(attribute[1]));
            characteristics.SetStrength(int.Parse(attribute[2]));
            characteristics.SetAgility(int.Parse(attribute[3]));
            characteristics.SetIntelligence(int.Parse(attribute[4]));
            SetMaximumPlayerExperiencePoints(maximumPlayerExperiencePoints * 2);
            SetPlayerExperiencePoints(int.Parse(server.SendingMessage("ResetExperiencePoints")));
        }
    }

    // восстановление очков здоровья игрока
    public void RestoringHealthPoints()
    {
        if(isRestoring)
        {
            if (characterHealthPoints.fillAmount == 1)
            {
                isRestoring = false;
                secondsRestoringHealthPoints = 0;
            }
            else
            {
                secondsRestoringHealthPoints += Time.deltaTime;
                if (secondsRestoringHealthPoints >= 0.5)
                {
                    Server server = new Server(); // сервер
                    SetCharacterHealthPoints(int.Parse(server.SendingMessage("RestoringHealthPoints")));
                    secondsRestoringHealthPoints = 0;
                }
            }
        }
    }

    // восстановление очков действия игрока
    public void RestoringActionPoints()
    {
        if (playerActionPoints.fillAmount == 1.5)
        {
            secondsRestoringActionPoints = 0;
        }
        else
        {
            secondsRestoringActionPoints += Time.deltaTime;
            if (secondsRestoringActionPoints >= 1)
            {
                Server server = new Server(); // сервер
                SetPlayerActionPoints(int.Parse(server.SendingMessage("RestoringActionPoints")));
                secondsRestoringActionPoints = 0;
            }
        }
    }

    private void Update()
    {
        Death();
        IncreaseLevel();
        RestoringHealthPoints();
        RestoringActionPoints();
    }
}
