using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Text UI
using System;
public class Timer : MonoBehaviour
{
    public static float time;
    //public bool timerIsRunning = true;
    private float timeRemaining = 1;
    public static Action timeChanged;

    [SerializeField] Text textElement;
    [SerializeField] Button pause;
    [SerializeField] Button start;
    [SerializeField] Button speedUp;
    [SerializeField] float customTime;
    private float DisplayTime;

    [SerializeField] Camera MainCamera;

    private float oneSecond;

    void Start()
    {
        buttons();
        Time.timeScale = customTime;
        MainCamera.orthographicSize = 10f;
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
            pause.interactable = false;
            start.interactable = true;
            speedUp.interactable = true;
        }
        void startTimer(){
            Time.timeScale=1;
            pause.interactable = true;
            start.interactable = false;
            speedUp.interactable = true;
        }
        void speedUpTimer(){
            Time.timeScale=2;
            pause.interactable = true;
            start.interactable = true;
            speedUp.interactable = false;
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
            timeChanged?.Invoke();
            timeRemaining =1;
            textElement.text = time.ToString();
            //MainCamera.orthographicSize += 0.005f;
        }
    }
}
