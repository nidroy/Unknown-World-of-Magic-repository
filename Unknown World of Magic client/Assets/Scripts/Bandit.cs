using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bandit : MonoBehaviour
{
    public Sprite banditIcon; // ����������� �������
    public Enemy enemy; // ����
    public Location location; // �������

    // ���������� ����������� ����������
    public void SetBanditIcon()
    {
        if (location.locationName.text == "Glade")
        {
            enemy.SetCharacterIcon(banditIcon);
        }
    }

    // �������� �������� ����������
    public void GetBanditAttributes()
    {
        if (location.locationName.text == "Glade")
        {
            Server server = new Server(); // ������

            string[] attribute = server.SendingMessage("GetBanditAttributes").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

            enemy.GetEnemyAttributes(attribute);
        }
    }
}
