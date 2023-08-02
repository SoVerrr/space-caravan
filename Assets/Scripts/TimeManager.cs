using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    [SerializeField] private PointManager pointManager;
    [SerializeField] private SpaceGrid spaceGrid;
    private int roadLimit;


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
            if (Timer.time % 160 == 0)
            {
                pointManager.GeneratePoint(pointManager.hubPoint);
            }
            else if (Timer.time % 50 == 0)
            {

                roadLimit+=20;
                ReturnRoadLimit();

            }
            else if (Timer.time % 20 == 0)
            {
                pointManager.GeneratePoint(pointsArray[counter]);
                if(counter != 2)
                    counter++;
                else
                    counter = 0;

            }
        }
    }

    public int ReturnRoadLimit()
    {
        return roadLimit;
    }



    private void Awake()
    {
        pointsArray = new Point[3] {pointManager.materialPoint, pointManager.processingPoint, pointManager.sellPoint};
        roadLimit = spaceGrid.GetRoadLimit();
    }
    private void Start()
    {
        pointManager.GeneratePoint(pointManager.materialPoint);
        //roadLimit = SpaceGrid.GetRoadLimit();
    }
}
