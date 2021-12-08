using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bandit : MonoBehaviour
{
    public Sprite banditIcon; // изображение бандита
    public Enemy enemy; // враг
    public Location location; // локация

    // установить изображение разбойника
    public void SetBanditIcon()
    {
        if (location.locationName.text == "Glade")
        {
            enemy.SetCharacterIcon(banditIcon);
        }
    }

    // получить атрибуты разбойника
    public void GetBanditAttributes()
    {
        if (location.locationName.text == "Glade")
        {
            Server server = new Server(); // сервер

            string[] attribute = server.SendingMessage("GetBanditAttributes").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

            enemy.GetEnemyAttributes(attribute);
        }
    }
}
