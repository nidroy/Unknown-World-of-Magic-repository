using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public Sprite[] inputSkillsSprite; // поля ввода навыков
    public Image[] outputSkillsImage; // поля вывода навыков
    public Image mainSkill; // поле вывода навыка используемого персонажем
    public int quantitySkills = 1; // количество доступных навыков
    public int newNumberSkill = 0; // номер текущего навыка
    public int oldNumberSkill = 0; // номер предыдущего навыка
    public Image[] lineSkills; // линии навыков
    public Text descriptionText; // поле вывода описания навыка
    public Player player; // главный герой
    private string[] descriptionSkills = new string[5]; // описание навыков;
    private int[] damageSkills = new int[5]; // список урона у каждого навыка;
    private int[] missSkills = new int[5]; // список промахов у каждого навыка;
    private int[] maximumHPSkills = new int[5]; // список максимального HP у каждого навыка;
    private int[] regenerationHPSkills = new int[5]; // список востановления HP у каждого навыка;
    private int[] goldSkills = new int[5]; // список золота у каждого навыка;
    public bool isDoubleAttack; // двойная атака персонажа
    public bool isTripleAttack; // тройная атака
    public bool isSecondLife; // вторая жизнь
    public int damage; // дополнительный урон от навыка
    public int miss; // дополнительные промахи от навыка
    public int maximumHP; // дополнительное максимальное HP от навыка
    public int regenerationHP; // дополнительное востановление HP от навыка
    public int gold; // дополнительное золото от навыка
    public Characteristics characteristics;

    private void Update()
    {
        SetSkillsClass();
        ReduceLineSkill();
        IncreaseLineSkill();
        PrintMainSkill();
    }

    #region Skills

    // установить навыки и их описание в зависимости от класса персонажа
    public void SetSkillsClass()
    {
        if(player.characterClass == "Archer")
        {
            SetSkills(0);
            SetDescriptionSkill(0, 5, 0, 0, 0, 0, "подожжённая стрела - стрела с наконечником из зуба дракона, наносящая дополнительный урон огнем.");
            SetDescriptionSkill(1, 0, 10, 0, 0, 0, "острый взгляд - глаз персонажа способен заметить мельчайшие движения, благодаря чему персонажу легче уворачиваться от атак.");
            SetDescriptionSkill(2, 20, 0, 0, 0, 0, "отравленная стрела - стрела пропитанная ядом гидры, наносящая значительный дополнительный урон ядом.");
            SetDescriptionSkill(3, 0, 0, 0, 0, 60, "карманник - навык, позволяющий собирать больше золота с убитых врагов.");
            SetDescriptionSkill(4, 0, 0, 0, 0, 0, "тройной выстрел - персонаж выпускает по три стрелы за раз.");
        }
        else if(player.characterClass == "Warrior")
        {
            SetSkills(5);
            SetDescriptionSkill(0, 0, 0, 10, 0, 0, "тяжёлые доспехи - навык, позволяющий надеть тяжёлую броню, благодаря чему повышается защита персонажа.");
            SetDescriptionSkill(1, 10, 0, 0, 0, 0, "пробивающие удары - удары персонажа пробивают броню противника, благодаря чему персонаж наносит дополнительный урон.");
            SetDescriptionSkill(2, 25, 0, 0, 0, 0, "критические удары - персонаж может определить уязвимые места в броне противника, благодаря чему наносит значительный дополнительный урон.");
            SetDescriptionSkill(3, 0, 0, 25, 0, 0, "зачарованный щит - персонаж зачаровывает свой щит, благодаря чему значительно повышается его защита.");
            SetDescriptionSkill(4, 50, 0, 50, 3, 0, "ликантропия - персонаж использует врождённый дар и превращается в зверя, значительно повышая свою атаку, защиту и регенерацию здоровья.");
        }
        else if(player.characterClass == "Magician")
        {
            SetSkills(10);
            SetDescriptionSkill(0, 10, 0, 0, 0, 0, "грозовой разряд - персонаж атакует врага используя стихию молнии, благодоря чему наносит дополнительный урон.");
            SetDescriptionSkill(1, 0, 0, 0, 1, 0, "быстрое лечение - здоровье персонажа восстанавливается значительно быстрее.");
            SetDescriptionSkill(2, 30, 0, 0, 0, 0, "ледяной дождь - персонаж вызывает ледяные взрывы, наносящие значительный дополнительный урон по противнику.");
            SetDescriptionSkill(3, 0, 0, 0, 0, 0, "призыв духа - персонаж призывает бесплотного духа хранителя, который начинает атаковать противников вместе с призывателем.");
            SetDescriptionSkill(4, 0, 0, 0, 0, 0, "некромантия - персонаж использует древние знания, чтобы стать нежитью и воскреснуть после смерти.");
        }
    }

    // установить навыки
    private void SetSkills(int initialSkill)
    {
        for (int i = 0; i < quantitySkills; i++)
        {
            outputSkillsImage[i].sprite = inputSkillsSprite[i + initialSkill];
        }
    }

    #endregion

    #region MainSkill

    // установить используемый персонажем навык
    public void SetMainSkill(int numberSkill)
    {
        if (numberSkill < quantitySkills)
        {
            newNumberSkill = numberSkill;
        }
    }

    // вывести используемый навык на экран
    private void PrintMainSkill()
    {
        if (lineSkills[newNumberSkill].fillAmount == 1)
        {
            mainSkill.sprite = outputSkillsImage[newNumberSkill].sprite;
            PrintDescriptionSkill();
            SetCharacterHP();
            SetBooleanSkills();
        }
    }

    #endregion

    #region LineSkill

    // увеличить линию текущего навыка
    private void IncreaseLineSkill()
    {
        if (oldNumberSkill == newNumberSkill)
        {
            lineSkills[newNumberSkill].fillAmount += Time.deltaTime * 4;
        }
    }

    // уменьшить линию предыдущего навыка
    private void ReduceLineSkill()
    {
        if (oldNumberSkill != newNumberSkill)
        {
            lineSkills[oldNumberSkill].fillAmount -= Time.deltaTime * 4;
            if(lineSkills[oldNumberSkill].fillAmount == 0)
            {
                oldNumberSkill = newNumberSkill;
            }
        }
    }

    #endregion

    #region Description

    // установить описание навыка и его бонусы
    public void SetDescriptionSkill(int numberSkill,int damageSkill, int missSkill, int maximumHPSkill, int regenerationHPSkill, int goldSkill, string description)
    {
        descriptionSkills[numberSkill] = description;
        damageSkills[numberSkill] = damageSkill;
        missSkills[numberSkill] = missSkill;
        maximumHPSkills[numberSkill] = maximumHPSkill;
        regenerationHPSkills[numberSkill] = regenerationHPSkill;
        goldSkills[numberSkill] = goldSkill;
    }

    // вывести описание навыка и его бонусы на экран
    private void PrintDescriptionSkill()
    {
        descriptionText.text = descriptionSkills[newNumberSkill];
        damage = damageSkills[newNumberSkill];
        miss = missSkills[newNumberSkill];
        maximumHP = maximumHPSkills[newNumberSkill];
        regenerationHP = regenerationHPSkills[newNumberSkill];
        gold = goldSkills[newNumberSkill];
    }

    #endregion

    #region Damage
    
    // установить урон от навыков
    public int SetDamageSkills()
    {
        int damageSkills = 0;
        if (damage != 0)
        {
            damageSkills = damage + characteristics.intelligence;
        }
        return damageSkills;
    }

    #endregion

    #region Miss

    // установить промахи от навыков
    public int SetMissSkills()
    {
        int missSkills = 0;
        if(miss != 0)
        {
            missSkills = miss + (int)((float)characteristics.intelligence / 5);
        }
        return missSkills;
    }

    #endregion

    #region HP

    // установить максимальное HP от навыков
    public int SetMaximumHPSkills()
    {
        int maximumHPSkills = 0;
        if(maximumHP != 0)
        {
            maximumHPSkills = maximumHP + characteristics.intelligence;
        }
        return maximumHPSkills;
    }

    // установить востонавление HP от навыков
    public float SetRegenerationHP()
    {
        float regenerationHPSkills = 1;
        if(regenerationHP != 0)
        {
            regenerationHPSkills = 1f + (float)regenerationHP + (float)characteristics.intelligence / 10;
        }
        return regenerationHPSkills;
    }

    // установить HP персонажа при изменении максимального HP
    private void SetCharacterHP()
    {
        if (player.characterHP > player.maximumCharacterHP)
        {
            player.SetHPCharacter(player.maximumCharacterHP);
            player.SetHPImageCharacter();
        }
    }

    #endregion

    #region Gold

    // установить количество золота от навыков
    public int SetGoldSkills()
    {
        int goldSkill = 0;
        if(gold != 0)
        {
            goldSkill = gold + characteristics.intelligence;
        }
        return goldSkill;
    }

    #endregion

    #region Boolean

    // установить множественную атаку или вторую жизнью в зависимости от выбранного навыка
    public void SetBooleanSkills()
    {
        if(player.characterClass == "Archer" && newNumberSkill == 4)
        {
            SetBoolean(false, true, false);
        }
        else if(player.characterClass == "Magician" && newNumberSkill == 3)
        {
            SetBoolean(true, false, false);
        }
        else if (player.characterClass == "Magician" && newNumberSkill == 4)
        {
            SetBoolean(false, false, true);
        }
        else
        {
            SetBoolean(false, false, false);
        }
    }

    // установить множественную атаку или вторую жизнью 
    private void SetBoolean(bool isDoubleAttackSkill, bool isTripleAttackSkill, bool isSecondLifeSkill)
    {
        isDoubleAttack = isDoubleAttackSkill;
        isTripleAttack = isTripleAttackSkill;
        isSecondLife = isSecondLifeSkill;
    }

    #endregion

}
