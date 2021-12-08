using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Leshii : MonoBehaviour
{
    public Sprite leshiiIcon; // ����������� �����
    public Enemy enemy; // ����
    public Location location; // �������

    // ���������� ����������� �����
    public void SetLeshiiIcon()
    {
        if (location.locationName.text == "Forest")
        {
            enemy.SetCharacterIcon(leshiiIcon);
        }
    }

    // �������� �������� ������
    public void GetLeshiiAttributes()
    {
        if (location.locationName.text == "Forest")
        {
            Server server = new Server(); // ������

            string[] attribute = server.SendingMessage("GetLeshiiAttributes").Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

            enemy.GetEnemyAttributes(attribute);
        }
    }
}
