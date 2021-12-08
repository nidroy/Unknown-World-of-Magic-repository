using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : Character
{
    public string playerClass; // ����� ������
    public Image playerActionPoints; // ���� �������� ������
    public int maximumPlayerActionPoints; // ������������ ���� �������� ������
    public Image playerExperiencePoints; // ���� ����� ������
    public int maximumPlayerExperiencePoints; // ������������ ���� ����� ������
    public Text playerSkillPoints; // ���� ������� ������
    public Text playerGold; // ������ ������
    public Enemy enemy; // ����
    public Characteristics characteristics; // ��������������
    public bool isRestoring; // �������������� ����� ��������
    private float secondsRestoringHealthPoints = 0; // ������� �������������� ���� ��������
    private float secondsRestoringActionPoints = 0; // ������� �������������� ���� ��������

    #region SetPlayerAttributes

    // ���������� ����� ������
    public void SetPlayerClass(string characterClass)
    {
        playerClass = characterClass;
    }

    // ���������� ���� �������� ������
    public void SetPlayerActionPoints(int actionPoints)
    {
        playerActionPoints.fillAmount = (float)actionPoints / (float)maximumPlayerActionPoints;
    }

    // ���������� ������������ ���� �������� ������
    public void SetMaximumPlayerActionPoints(int maximumActionPoints)
    {
        maximumPlayerActionPoints = maximumActionPoints;
    }

    // ���������� ���� ����� ������
    public void SetPlayerExperiencePoints(int experiencePoints)
    {
        playerExperiencePoints.fillAmount = (float)experiencePoints / (float)maximumPlayerExperiencePoints;
    }

    // ���������� ������������ ���� ����� ������
    public void SetMaximumPlayerExperiencePoints(int maximumExperiencePoints)
    {
        maximumPlayerExperiencePoints = maximumExperiencePoints;
    }

    // ���������� ���� ������� ������
    public void SetPlayerSkillPoints(int skillPoints)
    {
        playerSkillPoints.text = skillPoints.ToString();
    }

    // ���������� ������ ������
    public void SetPlayerGold(int gold)
    {
        playerGold.text = gold.ToString();
    }

    // ���������� ����������� ��������������
    public void SetAbilityRestoring(bool isPlayerRestoring)
    {
        isRestoring = isPlayerRestoring;
    }

    #endregion

    // ����� ������
    public override void Attack()
    {
        if(isFight)
        {
            Server server = new Server(); // ������

            string[] attribute = server.SendingMessage("PlayerAttack").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            enemy.SetCharacterHealthPoints(int.Parse(attribute[0]));
            SetPlayerActionPoints(int.Parse(attribute[1]));

            isFight = false;
        }
    }

    // ������ ������
    public override void Death()
    {
        if (characterHealthPoints.fillAmount == 0)
        {

        }
    }

    //��������� ������� ������
    public void IncreaseLevel()
    {
        if(playerExperiencePoints.fillAmount == 1)
        {
            Server server = new Server(); // ������

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

    // �������������� ����� �������� ������
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
                    Server server = new Server(); // ������
                    SetCharacterHealthPoints(int.Parse(server.SendingMessage("RestoringHealthPoints")));
                    secondsRestoringHealthPoints = 0;
                }
            }
        }
    }

    // �������������� ����� �������� ������
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
                Server server = new Server(); // ������
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
