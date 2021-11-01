using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trading : MonoBehaviour
{
    public Animator tradingWindowAnim; // анимация окна торговли
    public NPC npc; // неигровой персонаж
    public Player player; // главный герой
    public Sprite[] itemsSoldSprite; // все предметы на продажу
    public Image[] itemsSoldImage; // поле вывода предметов на продажу
    public Text descriptionItemSold; // поле вывода описания предмета на продажу
    private int numberItemsSold; // номер выбранного продаваемого предмета
    public Sprite[] bacgroundItemsSoldSprite; // поля ввода заднего фона проданных предметов
    public Image[] bacgroundItemsSoldImage; // поле вывода заднего фона проданных предметов
    public GameObject[] itemsSold; // предметы на продажу
    private int itemPrice; // цена предмета
    public Equipment equipment; // снаряжение
    private int damage; // урон наносимый предметом
    private int protection; // защита предмета
    private int regenerationHP; // востонавление HP от предмета
    private int gold; // дополнительное золото от предмета
    private int magicalKnowledge; // дополнительные магические знания от предмета

    private void Update()
    {
        OpenTradingWindow();
    }

    #region OpenClose
    
    // открыть окно торговли
    public void OpenTradingWindow()
    {
        if(npc.isTrades)
        {
            tradingWindowAnim.SetBool("isOpen", true);
        }
    }

    // закрыть окно торговли
    public void CloseTradingWindow()
    {
        if(npc.isTrades)
        {
            npc.SetTrades(false);
            tradingWindowAnim.SetBool("isOpen", false);
        }
    }

    #endregion

    // установить предметы на продажу в зависимости от класса персонажа
    public void SetItemsSold(int numberInitialItem)
    {
        for(int i = 0; i < 8; i++)
        {
            itemsSoldImage[i].sprite = itemsSoldSprite[i + numberInitialItem];
        }
    }

    // установить задний фон проданных предметов
    public void SetBackgroundItemsSold(int numberStartItem)
    {
        bacgroundItemsSoldImage[0].sprite = bacgroundItemsSoldSprite[0 + numberStartItem];
        bacgroundItemsSoldImage[1].sprite = bacgroundItemsSoldSprite[1 + numberStartItem];
    }

    // установить полезные свойства предмета
    public void SetItemProperties(int itemDamage, int itemProtection, int itemRegenerationHP, int itemGold, int itemMagicalKnowledge)
    {
        damage = itemDamage;
        protection = itemProtection;
        regenerationHP = itemRegenerationHP;
        gold = itemGold;
        magicalKnowledge = itemMagicalKnowledge;
    }

    #region Description

    // вывести описание предмета на продажу
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

    // установить описание предмета на продажу
    public void SetItemDescription(string description)
    {
        descriptionItemSold.text = description;
    }

    #endregion

    // установить описание, цену и свойства предмета на продажу класса лучник
    private void SetItemDescriptionArcher(int numberItem)
    {
        if (numberItem == 0)
        {
            SetItemDescription("Простой капюшон, сделанный из кожи, повышает защиту персонажа. Цена предмета 400 золота.");
            SetPriceItem(400);
            SetItemProperties(0, 50, 0, 0, 0);
        }
        else if (numberItem == 1)
        {
            SetItemDescription("Простые перчатки, сделанные из кожи, повышают защиту персонажа. Цена предмета 200 золота.");
            SetPriceItem(200);
            SetItemProperties(0, 20, 0, 0, 0);
        }
        else if (numberItem == 2)
        {
            SetItemDescription("Легкий доспех, сделанный из кожи, повышает защиту персонажа. Цена предмета 800 золота.");
            SetPriceItem(800);
            SetItemProperties(0, 100, 0, 0, 0);
        }
        else if (numberItem == 3)
        {
            SetItemDescription("Простые сапоги, сделанные из кожи, повышают защиту персонажа. Цена предмета 200 золота.");
            SetPriceItem(200);
            SetItemProperties(0, 50, 0, 0, 0);
        }
        else if (numberItem == 4)
        {
            SetItemDescription("Золотое кольцо, выкованное гномами и наделённое их магией, позволяет превращать плоть в золото. Благодаря этому персонаж получает больше золота с убитых врагов. Цена предмета 500 золота.");
            SetPriceItem(500);
            SetItemProperties(0, 0, 0, 20, 0);
        }
        else if (numberItem == 5)
        {
            SetItemDescription("Золотое кольцо с рубином, наделённым магией феникса, позволяет персонажу быстрее восстанавливать здоровье. Цена предмета 500 золота.");
            SetPriceItem(500);
            SetItemProperties(0, 0, 5, 0, 0);
        }
        else if (numberItem == 6)
        {
            SetItemDescription("Простой лук, сделанный из веток ивы, повышает атаку персонажа. Цена предмета 1000 золота.");
            SetPriceItem(1000);
            SetItemProperties(20, 0, 0, 0, 0);
        }
        else if (numberItem == 7)
        {
            SetItemDescription("Стрела с широким наконечником, немного повышающим атаку персонажа. Цена предмета 400 золота.");
            SetPriceItem(400);
            SetItemProperties(10, 0, 0, 0, 0);
        }
    }

    // установить описание, цену и свойства предмета на продажу класса воин
    private void SetItemDescriptionWarrior(int numberItem)
    {
        if (numberItem == 0)
        {
            SetItemDescription("Шлем, выкованный из слитков тёмной руды, повышает защиту персонажа. Цена предмета 600 золота.");
            SetPriceItem(600);
            SetItemProperties(0, 80, 0, 0, 0);
        }
        else if (numberItem == 1)
        {
            SetItemDescription("Рукавицы, выкованные из слитков тёмной руды, повышают защиту персонажа. Цена предмета 500 золота.");
            SetPriceItem(500);
            SetItemProperties(0, 40, 0, 0, 0);
        }
        else if (numberItem == 2)
        {
            SetItemDescription("Тяжёлый доспех, выкованный из слитков тёмной руды, значительно повышает защиту персонажа. Цена предмета 1000 золота.");
            SetPriceItem(1000);
            SetItemProperties(0, 250, 0, 0, 0);
        }
        else if (numberItem == 3)
        {
            SetItemDescription("Латные сапоги, выкованные из слитков тёмной руды, повышают защиту персонажа. Цена предмета 500 золота.");
            SetPriceItem(500);
            SetItemProperties(0, 80, 0, 0, 0);
        }
        else if (numberItem == 4)
        {
            SetItemDescription("Стальное кольцо, выкованное гномами и наделённое их магией, немного повышает урон, наносимый всеми видами оружия. Цена предмета 400 золота.");
            SetPriceItem(400);
            SetItemProperties(10, 0, 0, 0, 0);
        }
        else if (numberItem == 5)
        {
            SetItemDescription("Золотое кольцо с рубином, наделённым магией феникса, позволяет персонажу быстрее восстанавливать здоровье. Цена предмета 800 золота.");
            SetPriceItem(800);
            SetItemProperties(0, 0, 5, 0, 0);
        }
        else if (numberItem == 6)
        {
            SetItemDescription("Простой меч, выкованный из стали, повышает атаку персонажа. Цена предмета 1200 золота.");
            SetPriceItem(1200);
            SetItemProperties(40, 0, 0, 0, 0);
        }
        else if (numberItem == 7)
        {
            SetItemDescription("Простой железный щит немного повышает защиту персонажа. Цена предмета 800 золота.");
            SetPriceItem(800);
            SetItemProperties(0, 20, 0, 0, 0);
        }
    }

    // установить описание, цену и свойства предмета на продажу класса маг
    private void SetItemDescriptionMagician(int numberItem)
    {
        if (numberItem == 0)
        {
            SetItemDescription("Капюшон, сделанный из кожи мантикоры, немного повышает защиту персонажа. Цена предмета 400 золота.");
            SetPriceItem(400);
            SetItemProperties(0, 20, 0, 0, 0);
        }
        else if (numberItem == 1)
        {
            SetItemDescription("Перчатки, сделанные из кожи мантикоры, немного повышают защиту персонажа. Цена предмета 300 золота.");
            SetPriceItem(300);
            SetItemProperties(0, 20, 0, 0, 0);
        }
        else if (numberItem == 2)
        {
            SetItemDescription("Накидка, сделанная из кожи мантикоры, повышает защиту персонажа. Цена предмета 600 золота.");
            SetPriceItem(600);
            SetItemProperties(0, 60, 0, 0, 0);
        }
        else if (numberItem == 3)
        {
            SetItemDescription("Сапоги, сделанные из кожи мантикоры, немного повышают защиту персонажа. Цена предмета 400 золота.");
            SetPriceItem(400);
            SetItemProperties(0, 40, 0, 0, 0);
        }
        else if (numberItem == 4)
        {
            SetItemDescription("Золотое кольцо с рубином, наделённым магией феникса, позволяет персонажу быстрее восстанавливать здоровье. Цена предмета 500 золота.");
            SetPriceItem(500);
            SetItemProperties(0, 0, 5, 0, 0);
        }
        else if (numberItem == 5)
        {
            SetItemDescription("Серебряное кольцо с сапфиром, наделённым магией луны, позволяет персонажу эффективней пользоваться магией. Цена предмета 700 золота.");
            SetPriceItem(700);
            SetItemProperties(0, 0, 0, 0, 2);
        }
        else if (numberItem == 6)
        {
            SetItemDescription("Посох с упавшей звездой позволяет персонажу наносить значительный магический урон. Цена предмета 1400 золота.");
            SetPriceItem(1400);
            SetItemProperties(50, 0, 0, 0, 0);
        }
        else if (numberItem == 7)
        {
            SetItemDescription("Книга с тайными знаниями высших магов позволяет персонажу эффективней пользоваться магией. Цена предмета 1000 золота.");
            SetPriceItem(1000);
            SetItemProperties(0, 0, 0, 0, 6);
        }
    }

    #region Buy

    // установить цену предмета
    private void SetPriceItem(int gold)
    {
        itemPrice = gold;
    }

    // купить выбранный предмет
    public void BuyItem()
    {
        if(descriptionItemSold.text != "" && player.characterGold >= itemPrice && descriptionItemSold.text != "К сожалению, у тебя не хватает золота, чтобы купить этот предмет.")
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
            SetItemDescription("К сожалению, у тебя не хватает золота, чтобы купить этот предмет.");
        }
    }

    #endregion

    // установить номер выбранного продаваемого предмета
    public void SetNumberSoldItem(int number)
    {
        numberItemsSold = number;
    }

}
