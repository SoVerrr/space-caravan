using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingPoint : Point
{
    public static List<GameObject> processingPointsList;

    private PointDataProcessing processingData;

    override public void InstantiatePoint(int x, int y, PointData data)
    {
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        processingPointsList.Add(point);

        processingData = (PointDataProcessing)data;


    }
    static ProcessingPoint()
    {
        processingPointsList = new List<GameObject>();
    }

}
