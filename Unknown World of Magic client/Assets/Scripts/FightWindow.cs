using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightWindow : MonoBehaviour
{
    public GameObject buttonAttack; // кнопка атаки
    public GameObject buttonFight; // кнопка сражения
    public GameObject clock; // часы
    public Image timeLine; // линия времени
    public Text time; // время
    public Player player; // игрок
    public Enemy enemy; // враг
    public int timeFight; // время сражения

    // начать сражение
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
        player.SetAbilityRestoring(false);
    }

    // закончить сражение
    public void FinishFight()
    {
        clock.SetActive(false);
        timeLine.fillAmount = 1;
        time.text = 10.ToString();
        buttonAttack.SetActive(false);
        buttonFight.SetActive(true);
        player.SetAbilityFight(false);
        enemy.SetAbilityFight(false);
        player.SetAbilityRestoring(true);
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
