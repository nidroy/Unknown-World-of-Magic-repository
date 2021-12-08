using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightWindow : MonoBehaviour
{
    public GameObject buttonAttack; // ������ �����
    public GameObject buttonFight; // ������ ��������
    public GameObject clock; // ����
    public Image timeLine; // ����� �����
    public Text time; // �����
    public Player player; // �����
    public Enemy enemy; // ����
    public int timeFight; // ����� ��������

    // ������ ��������
    public void StartFight()
    {
        timeLine.fillAmount = 1;
        time.text = 10.ToString();
        clock.SetActive(true);
        buttonAttack.SetActive(true);
        buttonFight.SetActive(false);
        player.SetAbilityFight(true);
        enemy.SetAbilityFight(true);
        timeFight = Random.Range(2, 10);
    }

    // ��������� ��������
    public void FinishFight()
    {
        clock.SetActive(false);
        timeLine.fillAmount = 1;
        time.text = 10.ToString();
        buttonAttack.SetActive(false);
        buttonFight.SetActive(true);
        player.SetAbilityFight(false);
        enemy.SetAbilityFight(false);
        player.StartRestoring();
    }

    private void Update()
    {
        if(time.text == timeFight.ToString())
        {
            enemy.Attack();
        }
        if(timeLine.fillAmount == 0)
        {
            StartFight();
        }
    }
}
