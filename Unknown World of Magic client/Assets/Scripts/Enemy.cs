using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : Character
{
    public Bandit bandit; // ������
    public Leshii leshii; // �����
    public Player player; // �����
    public FightWindow fight; // ��������

    // �������� �������� �����
    public void GetEnemyAttributes(string[] attribute)
    {
        SetCharacterName(attribute[0]);
        SetMaximumCharacterHealthPoints(int.Parse(attribute[1]));
        SetCharacterHealthPoints(int.Parse(attribute[1]));
        SetCharacterLevel(int.Parse(attribute[2]));
        SetEnemyIcon();
    }

    // ���������� ����������� �����
    public void SetEnemyIcon()
    {
        bandit.SetBanditIcon();
        leshii.SetLeshiiIcon();
    }

    // ����� �����
    public override void Attack()
    {
        if(isFight)
        {
            Server server = new Server(); // ������

            player.SetCharacterHealthPoints(int.Parse(server.SendingMessage("EnemyAttack")));

            isFight = false;
        }
    }

    // ������ �����
    public override void Death()
    {
        if (characterHealthPoints.fillAmount == 0)
        {
            Server server = new Server(); // ������

            player.SetPlayerExperiencePoints(int.Parse(server.SendingMessage("IncreaseExperiencePoints")));
            player.SetPlayerGold(int.Parse(server.SendingMessage("IncreaseGold")));

            bandit.GetBanditAttributes();
            leshii.GetLeshiiAttributes();

            fight.FinishFight();
        }
    }

    private void Update()
    {
        Death();
    }
}
