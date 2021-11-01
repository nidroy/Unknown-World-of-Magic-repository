using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trading : MonoBehaviour
{
    public Animator tradingWindowAnim; // �������� ���� ��������
    public NPC npc; // ��������� ��������
    public Player player; // ������� �����
    public Sprite[] itemsSoldSprite; // ��� �������� �� �������
    public Image[] itemsSoldImage; // ���� ������ ��������� �� �������
    public Text descriptionItemSold; // ���� ������ �������� �������� �� �������
    private int numberItemsSold; // ����� ���������� ������������ ��������
    public Sprite[] bacgroundItemsSoldSprite; // ���� ����� ������� ���� ��������� ���������
    public Image[] bacgroundItemsSoldImage; // ���� ������ ������� ���� ��������� ���������
    public GameObject[] itemsSold; // �������� �� �������
    private int itemPrice; // ���� ��������
    public Equipment equipment; // ����������
    private int damage; // ���� ��������� ���������
    private int protection; // ������ ��������
    private int regenerationHP; // ������������� HP �� ��������
    private int gold; // �������������� ������ �� ��������
    private int magicalKnowledge; // �������������� ���������� ������ �� ��������

    private void Update()
    {
        OpenTradingWindow();
    }

    #region OpenClose
    
    // ������� ���� ��������
    public void OpenTradingWindow()
    {
        if(npc.isTrades)
        {
            tradingWindowAnim.SetBool("isOpen", true);
        }
    }

    // ������� ���� ��������
    public void CloseTradingWindow()
    {
        if(npc.isTrades)
        {
            npc.SetTrades(false);
            tradingWindowAnim.SetBool("isOpen", false);
        }
    }

    #endregion

    // ���������� �������� �� ������� � ����������� �� ������ ���������
    public void SetItemsSold(int numberInitialItem)
    {
        for(int i = 0; i < 8; i++)
        {
            itemsSoldImage[i].sprite = itemsSoldSprite[i + numberInitialItem];
        }
    }

    // ���������� ������ ��� ��������� ���������
    public void SetBackgroundItemsSold(int numberStartItem)
    {
        bacgroundItemsSoldImage[0].sprite = bacgroundItemsSoldSprite[0 + numberStartItem];
        bacgroundItemsSoldImage[1].sprite = bacgroundItemsSoldSprite[1 + numberStartItem];
    }

    // ���������� �������� �������� ��������
    public void SetItemProperties(int itemDamage, int itemProtection, int itemRegenerationHP, int itemGold, int itemMagicalKnowledge)
    {
        damage = itemDamage;
        protection = itemProtection;
        regenerationHP = itemRegenerationHP;
        gold = itemGold;
        magicalKnowledge = itemMagicalKnowledge;
    }

    #region Description

    // ������� �������� �������� �� �������
    public void PrintItemDescription(int numberItem)
    {
        if(player.characterClass == "Archer")
        {
            SetItemDescriptionArcher(numberItem);
        }
        else if (player.characterClass == "Warrior")
        {
            SetItemDescriptionWarrior(numberItem);
        }
        else if (player.characterClass == "Magician")
        {
            SetItemDescriptionMagician(numberItem);
        }

        numberItemsSold = numberItem;
    }

    // ���������� �������� �������� �� �������
    public void SetItemDescription(string description)
    {
        descriptionItemSold.text = description;
    }

    #endregion

    // ���������� ��������, ���� � �������� �������� �� ������� ������ ������
    private void SetItemDescriptionArcher(int numberItem)
    {
        if (numberItem == 0)
        {
            SetItemDescription("������� �������, ��������� �� ����, �������� ������ ���������. ���� �������� 400 ������.");
            SetPriceItem(400);
            SetItemProperties(0, 50, 0, 0, 0);
        }
        else if (numberItem == 1)
        {
            SetItemDescription("������� ��������, ��������� �� ����, �������� ������ ���������. ���� �������� 200 ������.");
            SetPriceItem(200);
            SetItemProperties(0, 20, 0, 0, 0);
        }
        else if (numberItem == 2)
        {
            SetItemDescription("������ ������, ��������� �� ����, �������� ������ ���������. ���� �������� 800 ������.");
            SetPriceItem(800);
            SetItemProperties(0, 100, 0, 0, 0);
        }
        else if (numberItem == 3)
        {
            SetItemDescription("������� ������, ��������� �� ����, �������� ������ ���������. ���� �������� 200 ������.");
            SetPriceItem(200);
            SetItemProperties(0, 50, 0, 0, 0);
        }
        else if (numberItem == 4)
        {
            SetItemDescription("������� ������, ���������� ������� � ��������� �� ������, ��������� ���������� ����� � ������. ��������� ����� �������� �������� ������ ������ � ������ ������. ���� �������� 500 ������.");
            SetPriceItem(500);
            SetItemProperties(0, 0, 0, 20, 0);
        }
        else if (numberItem == 5)
        {
            SetItemDescription("������� ������ � �������, ��������� ������ �������, ��������� ��������� ������� ��������������� ��������. ���� �������� 500 ������.");
            SetPriceItem(500);
            SetItemProperties(0, 0, 5, 0, 0);
        }
        else if (numberItem == 6)
        {
            SetItemDescription("������� ���, ��������� �� ����� ���, �������� ����� ���������. ���� �������� 1000 ������.");
            SetPriceItem(1000);
            SetItemProperties(20, 0, 0, 0, 0);
        }
        else if (numberItem == 7)
        {
            SetItemDescription("������ � ������� ������������, ������� ���������� ����� ���������. ���� �������� 400 ������.");
            SetPriceItem(400);
            SetItemProperties(10, 0, 0, 0, 0);
        }
    }

    // ���������� ��������, ���� � �������� �������� �� ������� ������ ����
    private void SetItemDescriptionWarrior(int numberItem)
    {
        if (numberItem == 0)
        {
            SetItemDescription("����, ���������� �� ������� ����� ����, �������� ������ ���������. ���� �������� 600 ������.");
            SetPriceItem(600);
            SetItemProperties(0, 80, 0, 0, 0);
        }
        else if (numberItem == 1)
        {
            SetItemDescription("��������, ���������� �� ������� ����� ����, �������� ������ ���������. ���� �������� 500 ������.");
            SetPriceItem(500);
            SetItemProperties(0, 40, 0, 0, 0);
        }
        else if (numberItem == 2)
        {
            SetItemDescription("������ ������, ���������� �� ������� ����� ����, ����������� �������� ������ ���������. ���� �������� 1000 ������.");
            SetPriceItem(1000);
            SetItemProperties(0, 250, 0, 0, 0);
        }
        else if (numberItem == 3)
        {
            SetItemDescription("������ ������, ���������� �� ������� ����� ����, �������� ������ ���������. ���� �������� 500 ������.");
            SetPriceItem(500);
            SetItemProperties(0, 80, 0, 0, 0);
        }
        else if (numberItem == 4)
        {
            SetItemDescription("�������� ������, ���������� ������� � ��������� �� ������, ������� �������� ����, ��������� ����� ������ ������. ���� �������� 400 ������.");
            SetPriceItem(400);
            SetItemProperties(10, 0, 0, 0, 0);
        }
        else if (numberItem == 5)
        {
            SetItemDescription("������� ������ � �������, ��������� ������ �������, ��������� ��������� ������� ��������������� ��������. ���� �������� 800 ������.");
            SetPriceItem(800);
            SetItemProperties(0, 0, 5, 0, 0);
        }
        else if (numberItem == 6)
        {
            SetItemDescription("������� ���, ���������� �� �����, �������� ����� ���������. ���� �������� 1200 ������.");
            SetPriceItem(1200);
            SetItemProperties(40, 0, 0, 0, 0);
        }
        else if (numberItem == 7)
        {
            SetItemDescription("������� �������� ��� ������� �������� ������ ���������. ���� �������� 800 ������.");
            SetPriceItem(800);
            SetItemProperties(0, 20, 0, 0, 0);
        }
    }

    // ���������� ��������, ���� � �������� �������� �� ������� ������ ���
    private void SetItemDescriptionMagician(int numberItem)
    {
        if (numberItem == 0)
        {
            SetItemDescription("�������, ��������� �� ���� ���������, ������� �������� ������ ���������. ���� �������� 400 ������.");
            SetPriceItem(400);
            SetItemProperties(0, 20, 0, 0, 0);
        }
        else if (numberItem == 1)
        {
            SetItemDescription("��������, ��������� �� ���� ���������, ������� �������� ������ ���������. ���� �������� 300 ������.");
            SetPriceItem(300);
            SetItemProperties(0, 20, 0, 0, 0);
        }
        else if (numberItem == 2)
        {
            SetItemDescription("�������, ��������� �� ���� ���������, �������� ������ ���������. ���� �������� 600 ������.");
            SetPriceItem(600);
            SetItemProperties(0, 60, 0, 0, 0);
        }
        else if (numberItem == 3)
        {
            SetItemDescription("������, ��������� �� ���� ���������, ������� �������� ������ ���������. ���� �������� 400 ������.");
            SetPriceItem(400);
            SetItemProperties(0, 40, 0, 0, 0);
        }
        else if (numberItem == 4)
        {
            SetItemDescription("������� ������ � �������, ��������� ������ �������, ��������� ��������� ������� ��������������� ��������. ���� �������� 500 ������.");
            SetPriceItem(500);
            SetItemProperties(0, 0, 5, 0, 0);
        }
        else if (numberItem == 5)
        {
            SetItemDescription("���������� ������ � ��������, ��������� ������ ����, ��������� ��������� ����������� ������������ ������. ���� �������� 700 ������.");
            SetPriceItem(700);
            SetItemProperties(0, 0, 0, 0, 2);
        }
        else if (numberItem == 6)
        {
            SetItemDescription("����� � ������� ������� ��������� ��������� �������� ������������ ���������� ����. ���� �������� 1400 ������.");
            SetPriceItem(1400);
            SetItemProperties(50, 0, 0, 0, 0);
        }
        else if (numberItem == 7)
        {
            SetItemDescription("����� � ������� �������� ������ ����� ��������� ��������� ����������� ������������ ������. ���� �������� 1000 ������.");
            SetPriceItem(1000);
            SetItemProperties(0, 0, 0, 0, 6);
        }
    }

    #region Buy

    // ���������� ���� ��������
    private void SetPriceItem(int gold)
    {
        itemPrice = gold;
    }

    // ������ ��������� �������
    public void BuyItem()
    {
        if(descriptionItemSold.text != "" && player.characterGold >= itemPrice && descriptionItemSold.text != "� ���������, � ���� �� ������� ������, ����� ������ ���� �������.")
        {
            equipment.SetEquipmentElements(numberItemsSold, itemsSoldImage[numberItemsSold].sprite);
            player.SetGoldCharacter(-1*itemPrice);
            equipment.SetDamage(damage);
            equipment.SetMaximumHP(protection);
            if(regenerationHP != 0)
            {
                equipment.SetRegenerationHP(regenerationHP);
            }
            equipment.SetGold(gold);
            equipment.SetIntelligence(magicalKnowledge);
            itemsSold[numberItemsSold].SetActive(false);
            SetItemDescription("");
        }
        else if(descriptionItemSold.text != "" && player.characterGold <= itemPrice)
        {
            SetItemDescription("� ���������, � ���� �� ������� ������, ����� ������ ���� �������.");
        }
    }

    #endregion

    // ���������� ����� ���������� ������������ ��������
    public void SetNumberSoldItem(int number)
    {
        numberItemsSold = number;
    }

}
