using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Text UI
public class Timer : MonoBehaviour
{
    private float time;
    //public bool timerIsRunning = true;
    private float timeRemaining = 1;
    private Text textElement;
    private Button pause;
    private Button start;
    private Button speedUp;

    private float DisplayTime;

    private float oneSecond;

    void Start()
    {
        buttons();
    }
    void Update()
    {
        oneSecondTimer();
        // oneSecond = timer(1);
        // if (oneSecond==1){
        //     DisplayTime+=1;
        //     Debug.Log(DisplayTime);
        //     textElement.text = DisplayTime.ToString();
        // }
    }


    void buttons(){
        pause.onClick.AddListener(pauseTimer);
        start.onClick.AddListener(startTimer);
        speedUp.onClick.AddListener(speedUpTimer);
        void pauseTimer(){
            Time.timeScale=0;
        }
        void startTimer(){
            Time.timeScale=1;
        }
        void speedUpTimer(){
            Time.timeScale=2;
        }
    }

    // float timer(float time){
    //     float tmp = time;
    //     if (time>0)
    //     {
    //         time-=Time.deltaTime;
    //     }
    //     else{
    //         time = tmp;           
    //     }
    //     return 1;
    // }

    void oneSecondTimer(){
        if (timeRemaining>0)
        {
            timeRemaining-=Time.deltaTime;
        }
        else{
            time+=1;
            timeRemaining=1;
            textElement.text = time.ToString();
        }
    }
}
