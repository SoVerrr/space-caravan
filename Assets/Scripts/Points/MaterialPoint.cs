using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPoint : Point
{
    public static List<GameObject> materialPointList;

    private PointDataMaterial materialData;
    public int prodRate;
    override public void InstantiatePoint(int x, int y, PointData data)
    {
        materialData = new PointDataMaterial();
        prodRate = materialData.GetProductionRate();
        Debug.Log("coords: " + x + " " + y + " type: " + materialData.GetProductionRate());
        var point = Instantiate(gameObject, new Vector3(x, 0, y), Quaternion.identity);
        materialPointList.Add(point);
    }

    static MaterialPoint()
    {
        materialPointList = new List<GameObject>();
    }
}
