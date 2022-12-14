using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winTimerText;
    public TextMeshProUGUI loseCupCountText;
    public int loseCupCount;
    public float timer;
    public bool timeOver=false;
    public bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 90;
        timerText.text = "Time left : "+timer.ToString("00")+" sec";
    }

    // Update is called once per frame
    void Update()
    {
        if (win == false)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time left : " + timer.ToString("00") + " sec";
            if (timer < 0)
            {
                timeOver = true;
                timerText.text = "Time left : " + 0.ToString("00") + " sec";
                loseCupCountText.text = (10 - loseCupCount).ToString()+" cups left";
            }
        }
        else
        {
            winTimerText.text = (60 - timer).ToString("00")+" sec";
        }
    }
}
