using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameManager gameManager;
    public Slider timerSlider;
    public float gameTime;
    bool stopTimer;
    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameOver)
        {
            float time = gameTime - Time.time;
            if (time <= 0)
            {
                stopTimer = true;
                //gameManager.LevelOver();
            }
            if (!stopTimer)
            {
                timerSlider.value = time;
            }
        }

    }
}
