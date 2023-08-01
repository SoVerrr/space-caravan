using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    [SerializeField] private PointManager pointManager;

    private Point[] pointsArray;
    private int counter = 0;
    private void OnEnable()
    {
        Timer.timeChanged += TimeCheck;
    }

    private void OnDisable()
    {
        Timer.timeChanged -= TimeCheck;
    }

    private void TimeCheck()
    {
        if (Timer.time > 1)
        {
            if (Timer.time % 40 == 0)
            {
                pointManager.GeneratePoint(pointManager.hubPoint);
            }
            else if (Timer.time % 5 == 0)
            {
                pointManager.GeneratePoint(pointsArray[counter]);
                if(counter != 2)
                    counter++;
                else
                    counter = 0;

            }
        }
    }
    private void Awake()
    {
        pointsArray = new Point[3] {pointManager.materialPoint, pointManager.processingPoint, pointManager.sellPoint};
    }
    private void Start()
    {
    }
}
