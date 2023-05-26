using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    [SerializeField] private PointManager pointManager;

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
                Debug.Log("hej minê³o 5 sekund");
                pointManager.GeneratePoint(pointManager.materialPoint,new PointDataMaterial(5, "stone"));
            }
            if (Timer.time % 10 == 0)
            {
                pointManager.GeneratePoint(pointManager.processingPoint, new PointDataProcessing(new string[] {"stone"}, new string[] {"pickaxe"}, 3));
            }
            if (Timer.time % 15 == 0)
            {
                pointManager.GeneratePoint(pointManager.sellPoint, new PointDataMaterial(5, "stone"));
            }
            if (Timer.time % 40 == 0)
            {
                pointManager.GeneratePoint(pointManager.hubPoint, new PointDataMaterial(5, "stone"));
            }

        }
    }
    private void Start()
    {
    }
}
