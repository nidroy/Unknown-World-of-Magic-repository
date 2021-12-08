using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image timeLine; // ����� �����
    public Text time; // ����� 

    void Update()
    {
        timeLine.fillAmount -= Time.deltaTime / 10f;
        time.text = ((int)(timeLine.fillAmount * 10) + 1).ToString();
    }
}
