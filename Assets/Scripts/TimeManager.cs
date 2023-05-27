using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    [SerializeField] private PointManager pointManager;

    private Point[] pointsArray;
    private PointData[] pointsDataArray = new PointData[3];
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
            if (Timer.time % 5 == 0)
            {
                pointManager.GeneratePoint(pointsArray[counter], pointsDataArray[counter]);
                if(counter != 2)
                    counter++;
                else
                    counter = 0;

            }
            if (Timer.time % 40 == 0)
            {
                pointManager.GeneratePoint(pointManager.hubPoint, new PointDataMaterial(5, "stone"));
            }

        }
    }
    private void Awake()
    {
        pointsArray = new Point[3] {pointManager.materialPoint, pointManager.processingPoint, pointManager.sellPoint};
        pointsDataArray = new PointData[3] { new PointDataMaterial(5, "stone"),new PointDataProcessing(new string[] {"stone"}, new string[] {"pickaxe"}, 3) , new PointDataMaterial(5, "stone") };
    }
    private void Start()
    {
    }
}
