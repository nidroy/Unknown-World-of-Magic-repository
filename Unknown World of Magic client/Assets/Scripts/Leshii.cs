using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Leshii : MonoBehaviour
{
    public Sprite leshiiIcon; // изображение лешия
    public Enemy enemy; // враг
    public Location location; // локация

    // установить изображение лешия
    public void SetLeshiiIcon()
    {
        if (location.locationName.text == "Forest")
        {
            enemy.SetCharacterIcon(leshiiIcon);
        }
    }

    // получить атрибуты лешего
    public void GetLeshiiAttributes()
    {
        if (location.locationName.text == "Forest")
        {
            Server server = new Server(); // сервер

            string[] attribute = server.SendingMessage("GetLeshiiAttributes").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

            enemy.GetEnemyAttributes(attribute);
        }
    }
}
