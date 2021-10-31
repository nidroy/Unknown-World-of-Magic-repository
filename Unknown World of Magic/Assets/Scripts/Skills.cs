using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public Sprite[] inputSkillsSprite; // ���� ����� �������
    public Image[] outputSkillsImage; // ���� ������ �������
    public Image mainSkill; // ���� ������ ������ ������������� ����������
    public int quantitySkills = 1; // ���������� ��������� �������
    public int newNumberSkill = 0; // ����� �������� ������
    public int oldNumberSkill = 0; // ����� ����������� ������
    public Image[] lineSkills; // ����� �������
    public Text descriptionText; // ���� ������ �������� ������
    public Player player; // ������� �����
    private string[] descriptionSkills = new string[5]; // �������� �������;
    private int[] damageSkills = new int[5]; // ������ ����� � ������� ������;
    private int[] missSkills = new int[5]; // ������ �������� � ������� ������;
    private int[] maximumHPSkills = new int[5]; // ������ ������������� HP � ������� ������;
    private int[] regenerationHPSkills = new int[5]; // ������ ������������� HP � ������� ������;
    private int[] goldSkills = new int[5]; // ������ ������ � ������� ������;
    public bool isDoubleAttack; // ������� ����� ���������
    public bool isTripleAttack; // ������� �����
    public bool isSecondLife; // ������ �����
    public int damage; // �������������� ���� �� ������
    public int miss; // �������������� ������� �� ������
    public int maximumHP; // �������������� ������������ HP �� ������
    public int regenerationHP; // �������������� ������������� HP �� ������
    public int gold; // �������������� ������ �� ������
    public Characteristics characteristics;

    private void Update()
    {
        SetSkillsClass();
        ReduceLineSkill();
        IncreaseLineSkill();
        PrintMainSkill();
    }

    #region Skills

    // ���������� ������ � �� �������� � ����������� �� ������ ���������
    public void SetSkillsClass()
    {
        if(player.characterClass == "Archer")
        {
            SetSkills(0);
            SetDescriptionSkill(0, 5, 0, 0, 0, 0, "���������� ������ - ������ � ������������ �� ���� �������, ��������� �������������� ���� �����.");
            SetDescriptionSkill(1, 0, 10, 0, 0, 0, "������ ������ - ���� ��������� �������� �������� ���������� ��������, ��������� ���� ��������� ����� ������������� �� ����.");
            SetDescriptionSkill(2, 20, 0, 0, 0, 0, "����������� ������ - ������ ����������� ���� �����, ��������� ������������ �������������� ���� ����.");
            SetDescriptionSkill(3, 0, 0, 0, 0, 60, "��������� - �����, ����������� �������� ������ ������ � ������ ������.");
            SetDescriptionSkill(4, 0, 0, 0, 0, 0, "������� ������� - �������� ��������� �� ��� ������ �� ���.");
        }
        else if(player.characterClass == "Warrior")
        {
            SetSkills(5);
            SetDescriptionSkill(0, 0, 0, 10, 0, 0, "������ ������� - �����, ����������� ������ ������ �����, ��������� ���� ���������� ������ ���������.");
            SetDescriptionSkill(1, 10, 0, 0, 0, 0, "����������� ����� - ����� ��������� ��������� ����� ����������, ��������� ���� �������� ������� �������������� ����.");
            SetDescriptionSkill(2, 25, 0, 0, 0, 0, "����������� ����� - �������� ����� ���������� �������� ����� � ����� ����������, ��������� ���� ������� ������������ �������������� ����.");
            SetDescriptionSkill(3, 0, 0, 25, 0, 0, "������������ ��� - �������� ������������ ���� ���, ��������� ���� ����������� ���������� ��� ������.");
            SetDescriptionSkill(4, 50, 0, 50, 3, 0, "����������� - �������� ���������� ��������� ��� � ������������ � �����, ����������� ������� ���� �����, ������ � ����������� ��������.");
        }
        else if(player.characterClass == "Magician")
        {
            SetSkills(10);
            SetDescriptionSkill(0, 10, 0, 0, 0, 0, "�������� ������ - �������� ������� ����� ��������� ������ ������, ��������� ���� ������� �������������� ����.");
            SetDescriptionSkill(1, 0, 0, 0, 1, 0, "������� ������� - �������� ��������� ����������������� ����������� �������.");
            SetDescriptionSkill(2, 30, 0, 0, 0, 0, "������� ����� - �������� �������� ������� ������, ��������� ������������ �������������� ���� �� ����������.");
            SetDescriptionSkill(3, 0, 0, 0, 0, 0, "������ ���� - �������� ��������� ����������� ���� ���������, ������� �������� ��������� ����������� ������ � ������������.");
            SetDescriptionSkill(4, 0, 0, 0, 0, 0, "����������� - �������� ���������� ������� ������, ����� ����� ������� � ����������� ����� ������.");
        }
    }

    // ���������� ������
    private void SetSkills(int initialSkill)
    {
        for (int i = 0; i < quantitySkills; i++)
        {
            outputSkillsImage[i].sprite = inputSkillsSprite[i + initialSkill];
        }
    }

    #endregion

    #region MainSkill

    // ���������� ������������ ���������� �����
    public void SetMainSkill(int numberSkill)
    {
        if (numberSkill < quantitySkills)
        {
            newNumberSkill = numberSkill;
        }
    }

    // ������� ������������ ����� �� �����
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

    // ��������� ����� �������� ������
    private void IncreaseLineSkill()
    {
        if (oldNumberSkill == newNumberSkill)
        {
            lineSkills[newNumberSkill].fillAmount += Time.deltaTime * 4;
        }
    }

    // ��������� ����� ����������� ������
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

    // ���������� �������� ������ � ��� ������
    public void SetDescriptionSkill(int numberSkill,int damageSkill, int missSkill, int maximumHPSkill, int regenerationHPSkill, int goldSkill, string description)
    {
        descriptionSkills[numberSkill] = description;
        damageSkills[numberSkill] = damageSkill;
        missSkills[numberSkill] = missSkill;
        maximumHPSkills[numberSkill] = maximumHPSkill;
        regenerationHPSkills[numberSkill] = regenerationHPSkill;
        goldSkills[numberSkill] = goldSkill;
    }

    // ������� �������� ������ � ��� ������ �� �����
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
    
    // ���������� ���� �� �������
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

    // ���������� ������� �� �������
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

    // ���������� ������������ HP �� �������
    public int SetMaximumHPSkills()
    {
        int maximumHPSkills = 0;
        if(maximumHP != 0)
        {
            maximumHPSkills = maximumHP + characteristics.intelligence;
        }
        return maximumHPSkills;
    }

    // ���������� ������������� HP �� �������
    public float SetRegenerationHP()
    {
        float regenerationHPSkills = 1;
        if(regenerationHP != 0)
        {
            regenerationHPSkills = 1f + (float)regenerationHP + (float)characteristics.intelligence / 10;
        }
        return regenerationHPSkills;
    }

    // ���������� HP ��������� ��� ��������� ������������� HP
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

    // ���������� ���������� ������ �� �������
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

    // ���������� ������������� ����� ��� ������ ������ � ����������� �� ���������� ������
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

    // ���������� ������������� ����� ��� ������ ������ 
    private void SetBoolean(bool isDoubleAttackSkill, bool isTripleAttackSkill, bool isSecondLifeSkill)
    {
        isDoubleAttack = isDoubleAttackSkill;
        isTripleAttack = isTripleAttackSkill;
        isSecondLife = isSecondLifeSkill;
    }

    #endregion

}
