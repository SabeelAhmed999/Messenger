using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameManager gameManager;
    public Slider timerSlider;
    public float gameTime;
    bool over;
    bool stopTimer;
    // Start is called before the first frame update
    void Start()
    {
        over=false;
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!gameManager.gameOver)
        {
            if(!over)
            {
                gameTime =gameTime-Time.deltaTime;
                if (gameTime <= 0)
                {
                    over=true;
                    stopTimer = true;
                    gameManager.LevelOver("Time's Up");
                }
                if (!stopTimer)
                {
                    gameManager.gameOver=false;
                    timerSlider.value = gameTime;
                }
            }

        }


    }
}
