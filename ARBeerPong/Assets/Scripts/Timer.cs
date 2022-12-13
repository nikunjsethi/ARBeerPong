using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer;
    public bool timeOver=false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 20;
        timerText.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        timerText.text = timer.ToString();
        if (timer<0)
        {
            timeOver = true;
            timerText.text = 0.ToString();
        }
    }
}
