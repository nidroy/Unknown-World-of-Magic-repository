using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    public Text menuName; // �������� ����

    // ���������� �������� ����
    public void SetMenuName(string name)
    {
        menuName.text = name;
    }
}
